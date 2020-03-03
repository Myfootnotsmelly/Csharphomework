using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHomework2_2
{
    class ArrayMethods
    {
        public static int getMax(int[] A)
        {
            Array.Sort(A);
            return A.Last();
        }
        public static int getMin(int[] A)
        {
            Array.Sort(A);
            return A.First();
        }
        public static int getSum(int[] A)
        {
            int sum = 0;
            foreach (int i in A)
            {
                sum += i;
            }
            return sum;
        }
        public static double getAverage(int[] A)
        {
            if (A.Length == 0)
                return 0;
            else
                return (double)getSum(A) / A.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[] { 2, 8, 6, 9, 15, 6, 10, 20, 45 };

            Console.Write(Array.Length);
            Console.Write("该数组最大值为：" + ArrayMethods.getMax(Array) + "最小值：" + ArrayMethods.getMin(Array) + "总和为:" + ArrayMethods.getSum(Array) + "平均值为:" + ArrayMethods.getAverage(Array));
            Console.Read();
        }
    }
}
