using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。

namespace Homework4
{
    class Program
    {
        // 链表节点
        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }

            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }

        //泛型链表类
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;

            public GenericList()
            {
                tail = head = null;
            }

            public Node<T> Head
            {
                get { return head; }
            }

            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
            public void ForEach(Action<T> action)
            {
                for (Node<T> x = head; x != null; x = x.Next)
                    action(x.Data);
            }
        }

       
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for (int i = 0; i < 10; i++)
                list.Add(i);
            int sum = 0;int max = int.MinValue;int min = int.MaxValue;
            list.ForEach(t => sum += t);
            list.ForEach(t => max = t > max ? t : max);
            list.ForEach(t =>min=t<min? t : min);
            Console.WriteLine($"the maxvalue of list is:{max}");
            Console.WriteLine($"the minvalue of list is:{min}");
            Console.WriteLine($"the sum of list is:{sum}");

        }
    }
}
