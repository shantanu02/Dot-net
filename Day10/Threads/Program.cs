using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WorkingWithThreads
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Priority = ThreadPriority.Highest;

            //t1.IsBackground = true;



            t1.Start();
            t2.Start();

            //Func1();
            //Func2();

            //t1.Abort();
            //t1.IsAlive();

            //t1.Join();//when t1 over then only the main thread start itd execution 

            //t1.Name

            //if(t1.ThreadState == ThreadState.)



            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main "+i);
                Thread.Sleep(1000);
            }

            Console.ReadLine();

        }


        static void Func1()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Func1 "+i);
                Thread.Sleep(1000); //pauses execution for that time 

            }
        }

        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Func2 " + i);
                Thread.Sleep(1000);
            }
        }


    }
}
