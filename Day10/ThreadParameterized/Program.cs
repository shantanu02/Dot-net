using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadWithParameterized
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            t1.Start("Shantanu");
            t2.Start("Darkai");

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main  "+i);
            }

            Console.ReadLine();

        }

        static void Func1(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Func1 " + i + o.ToString());
                Thread.Sleep(1000); //pauses execution for that time 

            }
        }

        static void Func2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Func2 " + i + o.ToString());
                Thread.Sleep(1000);
            }
        }
    }
}
