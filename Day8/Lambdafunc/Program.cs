using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> o = (a, b) => a + b;
            Console.WriteLine(o(40,40));
            Console.WriteLine();

            Func<int, int> o1 = a => a * 3;
            Console.WriteLine(o1(10));
            Console.ReadLine();


        }
    }
}
