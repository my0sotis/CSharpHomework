using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Program1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1)
                startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);        // 加入初始页面

            new Thread(myCrawler.Crawl).Start();        // 开始爬行
        }

        private void Crawl()
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("开始爬行了...");
            while(true)
            {
                string current = null;

                // 创建一个供Foreach查询的表单
                IEnumerable<string> urlList = from string s in urls.Keys
                                              select s;
                // 通过Parallel的Foreach方法对原有的foreach优化
                Parallel.ForEach(urlList, (string url, ParallelLoopState state) =>
                {
                    if ((bool)urls[url])
                    {
                        state.Break();
                        return;
                    }
                    current = url;
                });

                // 原来的foreach
                //foreach (string url in urls.Keys)        // 找到一个还没下载过的链接
                //{
                //    if ((bool)urls[url])                // 已经下载过的，不再下载
                //        continue;
                //    current = url;
                //}

                if (current == null || count >= 10) break;

                Console.WriteLine("爬行" + current + "页面！");

                string html = Download(current);        // 下载

                urls[current] = true;
                count++;

                Parse(html);
            }
            Console.WriteLine("爬行结束");
            TimeSpan a = DateTime.Now - start;
            Console.WriteLine(a);
            Console.ReadLine();
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            // 创建一个供Foreach查询的表单
            IEnumerable<Match> matchList = from Match m in matches
                                          select m;
            // 通过Parallel的Foreach方法对原有的foreach优化
            Parallel.ForEach(matchList, match =>
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                if (strRef.Length != 0)
                {
                    if (urls[strRef] == null) urls[strRef] = false;
                }
            });

            // 原来的foreach
            //foreach(Match match in matches)
            //{
            //    strRef = match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\'','#',' ','>');
            //    if (strRef.Length == 0) continue;

            //    if (urls[strRef] == null) urls[strRef] = false;
            //}
        }
    }
}
