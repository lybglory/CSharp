using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations;
namespace _01计算器
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个操作数");
            int n1 = IsNumber(Console.ReadLine());
            Console.WriteLine("请输入第二个操作数");
            int n2 = IsNumber(Console.ReadLine());
            Console.WriteLine("请输入操作符");
            string opCharacter = IsOperCharacter(Console.ReadLine());
            FatherOper character = GetResult(n1, n2, opCharacter);
            int result = character.GetResult();
            Console.WriteLine("{0}{1}{2}={3}",n1,opCharacter,n2,result);
            Console.ReadKey();

        }

        static FatherOper GetResult(int n1,int n2,string oper) {
            FatherOper character = null;
            switch (oper) {
                case "+" : character = new AddOperation(n1, n2);
                    break;
                case "-" : character = new Subtraction(n1, n2);
                    break;
                case "*" : character = new Multiplication(n1,n2);
                    break;
                case "/" : character = new Division(n1, n2);
                    break;
            }
            return character;
        }

        //判断操作符
        public static string IsOperCharacter(string oper) {
            while (true) {
                if (oper == "+" || oper == "-" || oper == "*" || oper == "/")
                {
                    return oper;
                }
                else {
                    Console.WriteLine("操作符输入有误，重新输入！！");
                    oper = Console.ReadLine();
                }
            }
           
                   
                  
           
        }
        //判断输入的是否是数字
        public static int IsNumber(string strNum) {
            while (true) {
                try {
                    int num = int.Parse(strNum);
                    return num;
                } catch {
                    Console.WriteLine("操作数输入有误，请重新输入");
                    strNum = Console.ReadLine();
                }
            }
        }
    }
}
