using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MultiThreading_With_ThreadStart
{
    // we get more control over our thread when we use System.Threading for multi Threading
    class Program
    {
        static void Main1(string[] args)
        {
            Func1();
            Func2();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main: " + i);
            }
        }
        static void Main2(string[] args)                     // 1st thread
        {
            Thread t1 = new Thread(new ThreadStart(Func1)); // 2nd Thread  , parameter passed as delegate
            Thread t2 = new Thread(Func2);                  // 3rd Thread  , parameter passed as function both way is correct and both are equal
            
            t1.Start(); // actual execution starts from here
            t2.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main: " + i);
            }

            Console.ReadLine();
        }
        static void Main(string[] args)                   
        {
            Thread t1 = new Thread(new ThreadStart(Func1)); // state-> unstarted
            Thread t2 = new Thread(Func2);

            //t1.Priority = ThreadPriority.Highest; // providing priority
            // t1.IsBackground = true; // now t1 thread will not wait for other thread to complete , by default all thread are foreground
            // Background threads are threads which will not wait for other threads to complete its execution but foregground thread will wait
            
            t1.Start(); //state-> running
            t2.Start();//state-> running

            //t1.Abort(); terminate the thread , state-> AbortRequest -> terminating (small diff in time in calling Abort() and it's actually termination 
            // because in between AbortRequest is also there)

            bool b = t1.IsAlive; // thread is alive or not it returns boolean

           
            t1.Join();// Join() method which allows one thread to wait until previous thread completes its execution
            // unless thread t1 is over then Main Thread will not start
            // t1.Suspend(); // state -> suspendRequest -> suspended , Depreciated
            // t1.Resume(); // Depreciated
            t2.Join();

            // instead of suspend use this
            /*  WaitHandle wh = new AutoResetEvent(false);
              wh.WaitOne();

              //instead of resume use this
              ((AutoResetEvent)wh).Set();
            */
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main: " + i);
            }

            if(t1.ThreadState == ThreadState.Stopped)
            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func1: " + i);
                // Thread.Sleep(1000); -> waiting state
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine("Func2: " + i);
            }
        }
    }
}




namespace MultiThreading_With_Parameterized_ThreadStart
{
    class Program
    {
      // when we want to provide parameters to our thread then we use ParameterizedThreadStart
        static void Main4(string[] args)                     
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1)); 
            Thread t2 = new Thread(Func2);                 

            t1.Start("aman"); 
            t2.Start("Kayare");

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main: " + i);
            }

            Console.ReadLine();
        }
        // more then one parameters of  thread function 
        static void Main5(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            Thread t3 = new Thread(new ParameterizedThreadStart(Func3));

            ParametersClass paraObj = new ParametersClass();
            t1.Start("aman");
            t2.Start("Kayare");
            // t3.Start(new { Name ="Arpit" , City="Mumbai" }); here anonymous class won't work because formal para is of object type
            //and we need to cast it into ParametersClass which cant be done with anonymous class

            t3.Start(paraObj);
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main: " + i);
            }

            Console.ReadLine();
        }

        static void Func1(object o)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func1: "+o.ToString() + i);
            }
        }
        static void Func2(object o)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func2: " + o.ToString() + i);
            }
        }
        static void Func3(object o)
        {
            
            ParametersClass p = (ParametersClass)o;

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func3: " + p.Name +" ----> "+p.City+" ----> "+i);
            }
        }
    }
    class ParametersClass
    {
        private string name = "Aman";
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        private string city = "Indore";
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

    }
}
/*   
 if we want to work with async code who's return type is non void the we have to use Delegates we cant use Thread class here because Thread class is not able
to handle return values but using delegate we can handle it using callback functions as a para in BeginInvoke()
 
 */



/* 
 - When we use Multithreading using Thread class like Thread t1 = new Thread() then it creates a new Thread everytime 
 - When we use Multithreading using delegate class like objDel.BeginInvoke() then it pools a Thread from a Thread Pool (set of Threads already available in pool) 

 - No overhead of creating a new Thread when use Thread Pooling
 - Pooling thread from a thread pool reduce the waiting time 
 - Queue is maintained to provide thread from the pool (FCFS)
 - MIN-SIZE -> Minimum no of Threads always there in Pool (It can be occupied or available)
 - MAX-SIZE -> Maximum no of Threads always there in Pool (It can be occupied or available)
 
 */


namespace MultiThreading_With_Thread_Pool
{
    class Program
    {

        static void Main4(string[] args)
        {
            ThreadPool.QueueUserWorkItem (new WaitCallback(PoolFunc1),"Aman");
            ThreadPool.QueueUserWorkItem(PoolFunc1, "Aman");
            ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc2));
            /*TODO Here somewhere*/
            int workerThreads, ioThreads;
            ThreadPool.GetAvailableThreads(out workerThreads,out ioThreads);

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main: " + i);
            }

            Console.ReadLine();
        }
      
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func1: " + o.ToString() + i);
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func2: " + o.ToString() + i);
            }
        }
        static void PoolFunc3(object o)
        {

            ParametersClass p = (ParametersClass)o;

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Func3: " + p.Name + " ----> " + p.City + " ----> " + i);
            }
        }
    }
    class ParametersClass
    {
        private string name = "Aman";
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        private string city = "Indore";
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

    }
}


/*
  
                --------------------------------------------------- SYNCHRONIZATION --------------------------------------------------
  
 #Problem statment

 
 Global variable i


Thread1-> {

i = 100;
=========================>control goes from here to thread 2
j = ++i;

k = i++;

}
 
OUTPUT should be :
i -> 102
j -> 101
k -> 101




Thread2-> {


i = 100; <=========================control come here to thread 2 from thread 1 now variable i = 100



}
  
 BUT OUTPUT We are Getting :
i -> 202
j -> 201
k -> 201
 
 
1st Solution to this is using Lock statement

 
Thread1-> Lock(obj1){ 

i = 100;
=========================>now control will not allowed go into the block of code which has the same Lock Obj assigned to this
j = ++i;

k = i++;

}
 
OUTPUT should be :
i -> 102
j -> 101
k -> 101




Thread2-> Lock(Obj1){


i = 100; ,<========= control not allowed here if Lock obj is obj1 , Lock  other then obj1 can enter here



}
 
2nd Solution is Using  Monitor.Enter(obj1) and Monitor.Exit(obj1)
 // Lock is only available in c#  , for other language they use -> Monitor.Enter(obj1)=>for Opening breaket '{' and Monitor.Exit(obj1)=> For Closing Breaket '}'
 // In c# internally Lock is converted into -> Monitor.Enter(obj1) and > Monitor.Exit(obj1) by compiler therefore we can use these directly in c# code also

3rd Solution to this is using InterLock Class which containing Already synchronized Methods for Basic Mathametical operation

Interlocked.Add(ref , 10); // equivalent to i+=10
etc.. TODO -> implement all other methods and lock monitor also



 
 
 */