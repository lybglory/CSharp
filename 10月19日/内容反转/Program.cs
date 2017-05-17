using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内容反转
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] country = { "中国", "美国", "巴西", "澳大利亚", "加拿大" };
            Reverse(ref country);
            //string[] newCountry = Reverse(country);
            for (int i = 0; i < country.Length; i++)
            {
                Console.WriteLine(country[i]);
            }
            
            Console.WriteLine(4/2);
            Console.ReadKey();
        }

        /// <summary>
        /// 实现数组元素反转
        /// </summary>
        /// <param name="ct">传入数组</param>
        /// <returns>返回反转数组</returns>
        public static void Reverse(ref string[] ct) {
        //public static string[] Reverse(string[] ct){}   
            for (int i = 0; i < ct.Length/2; i++)//交换次数就是长度/2
            {
                string temp = ct[i];//两两交换，声明第三方变量
                ct[i] = ct[ct.Length - 1-i];//一头一尾交换，最后的交换到了前面
                ct[ct.Length - 1 - i] = temp;//把最前面元素与最后的元素交换
            }
            //return ct;
        }
    }
}
