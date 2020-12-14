using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlingConcept
{
    class Program
    {
        //user code
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            c.invalidInputEventHandler += InvalidInputHandler;
            c.Input = 100;
            Console.WriteLine();
            c.del1 += Demo;
            c.Input = 100;


            Console.WriteLine();
            Console.ReadLine();

        }

        //event handler function
        static void InvalidInputHandler()
        {
            
            Console.WriteLine("Invalid Input Handler Handled...");
        }
        static void ApplicationHandler()
        {
            Console.WriteLine("Application Handler Handled....");
        }

        static void Demo(int value)
        {
            Console.WriteLine("Invalid value "+value);
        }


    }





    //Programmer code 
    public delegate void InvalidInputEventHandler();

    public delegate void Del1(int Value);
    class Class1
    {
        public event InvalidInputEventHandler invalidInputEventHandler;
        public event Del1 del1;
        private int input;
        public int Input
        {
            get
            {
                return input;
            }
            set
            {
                if(value < 100)
                {
                    input = value;
                }
                else
                {
                    //raise event here
                    if(invalidInputEventHandler != null)
                    {
                        invalidInputEventHandler();
                    }

                    if(del1 != null)
                    {
                        del1(value);
                    }

                }
            }
        }



    }

    




}
