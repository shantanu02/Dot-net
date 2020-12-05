using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Del1 objDel = new Del1(Display);
            objDel();

            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine("Display");
        }
    }

    public delegate void Del1(); 

    /*
    Delegates:
       ( like functions pointers in cpp )

    --Delegate is a class and using this class we casll a functionb indirectly

    steps :
    1.create a delegate class
    2.we can write it in class or namespace
    3.create a delegate having the same signature as the function which is to be called
    4.create a delegate object and pass the function to be called 
    5.call the function via delegate object --> objDel()
    */
}


