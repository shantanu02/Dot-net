using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMultiCast
{
    class Program
    {
        static void Main(string[] args)
        {

            //Del1 d1 = new Del1(Display);
            //d1();
            //Console.WriteLine();
            //d1 += new Del1(Show);
            //d1();
            //Console.WriteLine();
            //d1 += new Del1(Display);
            //d1();
            //Console.WriteLine();
            //d1 -= new Del1(Display);
            //d1();

            ////optimize syntax 
            //Console.WriteLine();
            //d1 -= Show;
            //d1();
            //Console.WriteLine();
            //d1 += Show;
            //d1();

            //Delegate.CreateDelegate(); -- not i csharp


            Del1 d = (Del1)Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            d();

            Console.WriteLine();
            d = (Del1)Delegate.Remove(d, new Del1(Display));

            d();


        }
        static void Display()
        {
            Console.WriteLine("Display");
        }

        static void Show()
        {
            Console.WriteLine("Show");
        }
    }
    public delegate void Del1();
}
