using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.Write("请输入第一个数字：");
            string s1 = Console.ReadLine();
            int a = int.Parse(s1);
            Console.Write("请输入第二个数字：");
            string s2 = Console.ReadLine();
            int b = int.Parse(s2);
            Console.WriteLine("这两个数的积为{0}。", a * b);
            Console.ReadLine();
        }
    }
}
