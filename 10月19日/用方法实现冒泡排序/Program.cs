using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 用方法实现冒泡排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 3, 5, 7, 9, 0, 2, 4, 6, 8, 10 };
            Bubble(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.ReadKey();                   
        }

        /// <summary>
        /// 实现冒泡排序
        /// </summary>
        /// <param name="num">传入参数</param>
        public static void Bubble(int[] num){
            
            for (int i = 0; i < num.Length-1; i++)//控制比较趟数，最后一趟不用交换，
            {                                     //因此需要数组.Length-1;
                for (int j = 0; j < num.Length-1-i; j++)//控制比较次数.
                {
                    if (num[j]>num[j+1]) {
                        int temp = num[j]; //两两交换，声明第三方变量
                        num[j] = num[j+1];//把更小的数往前移
                        num[j + 1] = temp;//把更大的数往后移
                    }
                }
            }   
        }

    }
}
