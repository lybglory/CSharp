using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算任意多个数之间的最大值
{
    class Program
    {
        static void Main(string[] args)
        {
            //params可变参数，会自动把实参当成形参类型使用
            int maxNum = GetMax(8, 43, 10, 30, 3);
            Console.WriteLine("任意数的最大值：{0}",maxNum);
            Console.ReadKey();
        }

        /// <summary>
        /// 求任意数的最大值
        /// </summary>
        /// <param name="n">传入数组</param>
        /// <returns>返回最大值</returns>
        public static int GetMax(params int[] n) {
            int max = n[0];//用来存储最大值
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i]>max) {
                    max = n[i];
                }
            }
            return max;
        }
    }
}
