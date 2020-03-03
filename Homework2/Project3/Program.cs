using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework2_3
{
    class JugdePrimeNumber
    {

        public static bool ifPrimeNumber(int inputnumber)//判断输入是否为素数
        {
            for (int i = 2; i * i <= inputnumber; i++)
            {
                if (inputnumber % i == 0)
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 100;
            bool[] A = new bool[N + 1];

            A[0] = A[1] = false;//0、1非素数
            for (int i = 2; i <= N; i++)
                A[i] = true;

            for (int i = 2; i * i <= N; i++)
            {
                if (!JugdePrimeNumber.ifPrimeNumber(i))
                    continue;
                for (int k = 2 * i; k <= N; k = k + i)
                    A[k] = false;
            }

            Console.Write("1-100的素数有：");//输出素数
            for (int i = 2; i <= N; i++)
                if (A[i])
                    Console.Write(i + ",");
            Console.Read();
        }
    }
}
