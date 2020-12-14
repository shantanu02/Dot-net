using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Class1 c = new Class1();
                int j = Convert.ToInt32(Console.ReadLine());
                c.I = j;
                Console.WriteLine(c.I);
                
            }
            catch(InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine("Clean Up code Here : finally executed ");
                Console.ReadLine();
            }
            Console.ReadLine();

        }
    }


    class Class1
    {
        private int i; 
        public int I
        {
            get
            {
                return i; 
            }
            set
            {
                //i = value;

                if(value < 100)
                {
                    i = value;
                }
                else
                {
                   Exception ex = new InvalidInputException("Invalid Exception");
                    throw ex;                 
                }
            }
        }
    }

    class InvalidInputException : ApplicationException
    {
        public InvalidInputException(string message) : base(message)
        {

        }
    }

}
