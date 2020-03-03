using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework2
{
    /* 经测试为多余操作
     * class JugdePrimeNumber
     {
         public static bool ifPrimeNumber(int inputnumber)//判断输入是否为素数
         {
             for(int i=2;i<inputnumber/2;i++)
             {
                 if (inputnumber % i == 0)
                     return false;
             }
             return true;
         }
     }       
     */
    class Program
    {
        static void Getsuyinzi(int num)
        {
            for (int i = 2; i <= num; i++)
            {
                if (/*跟上文相关的多余操作JugdePrimeNumber.ifPrimeNumber(i)&&*/
                    num % i == 0)
                {
                    Console.Write(i);
                    Console.Write(",");
                    Getsuyinzi(num / i);
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {

                Console.Write("Type a number, and then press Enter: ");
                int numInput1 = int.Parse(Console.ReadLine());
                Console.Write("该数的素数因子有：");
                Getsuyinzi(numInput1);
                Console.ReadLine();//阻塞
            }
            catch (Exception e)
            {
                Console.WriteLine("非法输入！" + e.Message);
                Console.ReadLine();//阻塞
            }

        }
    }
}
