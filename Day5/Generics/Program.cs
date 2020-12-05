using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> o = new MyStack<string>(3);
            o.Push("Shantanu");
            o.Push("Vipul");
            o.Push("Aditya");

            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());

            Console.ReadLine();



        }
    }

    class MyStack<T>
    //where T : struct
    //where T : class
    //where T : ClassName
    //where T : InterfaceName
    //where T : new()

    {
        T[] arr;

        public MyStack(int size)
        {
            arr = new T[size];
        }

        int pos = -1;

        public void Push(T item)
        {
            if (pos == (arr.Length - 1))
                throw new Exception("Stack Full");

            arr[++pos] = item;
        }

        public T Pop()
        {
            if (pos == -1)
                throw new Exception("Stack is Empty");
            return arr[pos--];
        }


    }



}
