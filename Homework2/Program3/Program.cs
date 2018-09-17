using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99];
            for(int i = 2; i <= 100; i++)
            {
                a[i - 2] = i;
            }
            for(int i = 2; i <= 50; i++)
            {
                for(int j = 0; j < 99; j++)
                {
                    int Remain = a[j] % i;
                    if (Remain == 0 && 1 != a[j] / i)
                        a[j] = 0;
                }
            }
            for(int i = 0; i < 99; i++)
            {
                if (a[i] != 0)
                    Console.Write(a[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
