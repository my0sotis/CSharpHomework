using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数组的长度：");
            string s = Console.ReadLine();
            int Length = int.Parse(s);
            int[] a = new int[Length];
            for(int i = 0; i < Length; i++)
            {
                s = Console.ReadLine();
                a[i] = int.Parse(s);
            }

            int Maxnum = a[0];
            int Minnum = a[0];
            double sum = 0;
            for(int i = 0; i < Length; i++)
            {
                if (a[i] > Maxnum)
                    Maxnum = a[i];
                if (a[i] < Minnum)
                    Minnum = a[i];
                sum = sum + a[i];
            }
            
            double average = sum / Length;

            Console.WriteLine("最大值为" + Maxnum + "。");
            Console.WriteLine("最小值为" + Minnum + "。");
            Console.WriteLine("平均值为" + average + "。");
            Console.WriteLine("所有数字之和为" + sum + "。");
            Console.ReadLine();
        }
    }
}
