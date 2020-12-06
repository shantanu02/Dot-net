using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Demo(Add, 30, 50));//80
            Console.WriteLine();
            Console.WriteLine(Demo(Sub, 130, 50));//80
            Console.WriteLine();
            Console.WriteLine(Demo(Mul, 3, 20));//60
            Console.WriteLine();
            Console.WriteLine(Demo(Quot, 100, 5));//20
            Console.WriteLine();
            Console.WriteLine(Demo(Rem, 5,2));//1
            
            /*
            Console.WriteLine();
            Console.WriteLine("----------------------");
            */

           // Console.WriteLine();

            /*
            Operation o;
            o = Add;
            //Console.WriteLine("Add---"+o(3,7)); //call 
            //Console.WriteLine();
            o += Sub;
            o += Mul;
            Console.WriteLine(o(10,4));//calls only the last method , override the previous one 
            */
            Console.ReadLine();

        }

        static int Add(int a , int b)
        {
            Console.WriteLine("Add");
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            return a + b;
        }

        static int Sub(int a, int b)
        {
            Console.WriteLine("Sub");
            return a - b;
        }

        static int Mul(int a, int b)
        {
            Console.WriteLine("MUL");
            return a * b;
        }

        static int Quot(int a, int b)
        {
            Console.WriteLine("Quot");
            return a / b;
        }

        static int Rem(int a, int b)
        {
            Console.WriteLine("Rem");
            return a % b;
        }

        static int Demo(Operation o, int a , int b)
        {
            return o(a, b);
        }


    }

    public delegate int Operation(int a, int b);
}
