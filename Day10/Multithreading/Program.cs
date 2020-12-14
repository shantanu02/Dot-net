using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaing2
{
    class Program
    {
        static void Main1(string[] args)
        {
        //    Console.WriteLine("Before");
        //    Func<string, string> o = Display;
        //    o.BeginInvoke("Shantanu", delegate (IAsyncResult ar)
        //     {
        //         string returnedValue = o.EndInvoke(ar);

        //         Console.WriteLine("ReturnedValue : " + returnedValue);
        //     },null);

        //    Console.WriteLine("After");
        //    Console.ReadLine();


             Console.WriteLine("Before");
            Func<string, string> o = Display;
            //IAsyncResult ar = o.BeginInvoke("Shantanu",CallBack ,"Shantanu -- 2");
            IAsyncResult ar = o.BeginInvoke("Shantanu", CallBack, o);
            Console.WriteLine("After");
            Console.ReadLine();


        }

        static string Display(string s )
        {
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Display() : "+s);
            return s.ToUpper();

        }
        static void CallBack(IAsyncResult ar)
        {
            Console.WriteLine("CallBack()");
            //string extraData = ar.AsyncState.ToString();
            //Console.WriteLine(extraData);

            Func<string, string> o = (Func<string, string>)ar.AsyncState;
            string retValue = o.EndInvoke(ar);
            Console.WriteLine(retValue);
        }


    }
}

namespace Multithreaing3
{
    class Program1
    {
        static void Main2(string[] args)
        {
            //    Console.WriteLine("Before");
            //    Func<string, string> o = Display;
            //    o.BeginInvoke("Shantanu", delegate (IAsyncResult ar)
            //     {
            //         string returnedValue = o.EndInvoke(ar);

            //         Console.WriteLine("ReturnedValue : " + returnedValue);
            //     },null);

            //    Console.WriteLine("After");
            //    Console.ReadLine();


            Console.WriteLine("Before");
            Func<string, string> o = Display;
            //IAsyncResult ar = o.BeginInvoke("Shantanu",CallBack ,"Shantanu -- 2");
            IAsyncResult ar = o.BeginInvoke("Shantanu", CallBack, null);
            Console.WriteLine("After");
            Console.ReadLine();


        }

        static string Display(string s)
        {
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Display() : " + s);
            return s.ToUpper();

        }
        static void CallBack(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;

             Console.WriteLine("CallBack()");
            //string extraData = ar.AsyncState.ToString();
            //Console.WriteLine(extraData);

            //Func<string, string> o = (Func<string, string>)ar.AsyncState;
            //string retValue = o.EndInvoke(ar);
            //Console.WriteLine(retValue);

            Func<string, string> o = (Func<string, string>)result.AsyncDelegate;
            string retValue = o.EndInvoke(ar);
            Console.WriteLine(retValue);

        }


    }
}

namespace Multithreaing4
{
    class Program1
    {
        static void Main(string[] args)
        {
           

            Console.WriteLine("Before");
            Action o = Display;
            IAsyncResult ar = o.BeginInvoke(null,null);
            Console.WriteLine("After");
            //Console.ReadLine();

            //while (!ar.IsCompleted) ;

            ar.AsyncWaitHandle.WaitOne();

        }

        static void Display()
        {
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Display() : ");
           

        }
      


    }
}