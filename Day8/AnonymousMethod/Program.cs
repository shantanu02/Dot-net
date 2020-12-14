using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            Action o = delegate
            {
                i++; //anonymous function can access the value defined in the calling code 
                Console.WriteLine("Anonymous Method Call ----" +i);
            };
            o();
            Console.ReadLine();

        }
    }
}
