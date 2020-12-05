using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            MyPoint p = new MyPoint(23, 56);
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);


            //Display();

            Console.ReadLine();

        }

        static void Display(TimeOfDay t)
        {
            if(t==TimeOfDay.Morning)
                Console.WriteLine("Good Morning");
            else if (t== TimeOfDay.Afternoon)
                Console.WriteLine("Good Afternoon");
            else if (t== TimeOfDay.Evening)
                Console.WriteLine("Good Evening");
            else if(t== TimeOfDay.Night)
                Console.WriteLine("Good Night");


        }
    }

    public struct MyPoint
    {
        public int X, Y;
        public MyPoint(int X , int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public enum TimeOfDay
    {
        Morning = 1,
        Afternoon,
        Evening,
        Night

    }

}
