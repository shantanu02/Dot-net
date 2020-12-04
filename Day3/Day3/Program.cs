using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void OldMain(string[] args)
        {
            //Manager m1 = new Manager();
            //m1.Display();
            //m1.Display("shantanu");
            // m1.Display1();
            //m1.Display2();
            Employee e = new Manager();

            e.Display1(); //decided by the reference name  at compile time
            e.Display2(); //depends upon the created object at runtime

            Console.ReadLine();
        
        }
    }

    public class Employee
    {
        public void Display()
        {
            Console.WriteLine("Display:Emp");
        }
        public void Display1()
        {
            Console.WriteLine("Display1:Emp");
        }

        public virtual void Display2()
        {
            Console.WriteLine("Display2:Emp");
        }



    }

    public class Manager : Employee
    {   
        //overloading
        public void Display(String name)
        {
            Console.WriteLine("Display :" + name);
        }

        //hiding
        public new void Display1()
        {
            Console.WriteLine("Display1:Manager");
        }

        //override
        public override void Display2()
        {
            Console.WriteLine("Display2:Manager");
        }

        
    }

    public class AreaManager : Manager
    {
        public override void Display2()
        {
            Console.WriteLine("Display2 : AreaManager");
        }
    }

    public class CountryManager : AreaManager
    {
        public override sealed void Display2()
        {
            Console.WriteLine("Display2 : CountryManager");
        }


    }

}
namespace AbstractConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.ReadLine();

        }
    }

    public abstract class A
    {
        public abstract void Display();

        public abstract void show();
        
    }

    public abstract class B : A
    {
        public override void Display()
        {
            Console.WriteLine("Override of Abstract A");
        }
    }

    public class C : B
    {
        public override void show()
        {
            Console.WriteLine("Show overriden of A ");
        }
    }

}