using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 求水仙花
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int i = 100; i < 999; i++)
            {
                int hundred = i / 100;
                int tens = i % 100 / 10;
                int units = i % 10;
                
                while (hundred*hundred*hundred+tens*tens*tens+units*units*units==i) {
                    Console.WriteLine("水仙花数={0}", i);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
