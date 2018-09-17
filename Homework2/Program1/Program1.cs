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
            Console.Write("请输入一个数字：");
            string s = Console.ReadLine();
            int x = int.Parse(s);
            Program1 p = new Program1();
            for (int i = 1; i <= x; i++)
            {
                if (x % i == 0)
                    p.ClarifyPrimeNum(i);
            }
            Console.ReadLine();
        }
        public void ClarifyPrimeNum(int x)
        {
            if (x == 1)
                return;
            for(int i = 2;i * i <= x;i++)
            {
                if (x % i == 0)
                    return;
            }
            Console.Write(x + " ");
        }
    }
}
