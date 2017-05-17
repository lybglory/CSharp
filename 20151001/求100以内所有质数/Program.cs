using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 求100以内所有质数
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 100; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i%j==0)
                    {
                        b = false;
                        break;//不是质数
                    }
                }
                if (b) {
                    Console.WriteLine("质数：{0}", i);
                }
                
            }
            Console.ReadKey();
        }
    }
}
