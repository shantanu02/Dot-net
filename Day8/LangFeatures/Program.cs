using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    class Program
    {
        //Implicit Variables
        static void Main1(string[] args)
        {
            int i = 10;

            var i2 = 100;

            Console.WriteLine(i2.GetType().ToString());

            Console.WriteLine();

            SortedList<int, string> obj= new SortedList<int, string>();

            foreach(var itm in obj)
            {

            }


            Console.ReadLine();


        }

        //Anonymous Types
        static void Main2(string[] args)
        {

            var myCar = new {Color = "Red" , Model ="Ferrari" ,Currentspeed = 56 };


            var myCar2 = new { Color = "Black", Model = "Merc" };


            Console.WriteLine("{0} ,  {1} , {2}",myCar.Color , myCar.Model , myCar.Currentspeed);

            Console.WriteLine();

            Console.WriteLine("{0} ,  {1} ", myCar2.Color, myCar2.Model);

            Console.WriteLine();


            Console.WriteLine(myCar.GetType().ToString());
            
            
            Console.WriteLine(myCar2.GetType().ToString());

            Console.ReadLine();

        }





    }

   
    //Extension Methods

   public static class Class1
    {

        //Extension methods
        static void Main1(string[] ags)
        {
            string s = "shantanu";

            Console.WriteLine(s.Display("Upase"));

            Console.ReadLine();

        }

        public static string Display(this string s,string a)
        {
            return s + a;
        }
    }


    public interface Ifunc
    {
        int Add();
    }

    public class Imple : Ifunc
    {
        public int Add()
        {
            return 1000000;
        }
    }


    public static class Program3
    {

        public static void Main5(string [] args)
        {
            Ifunc c = new Imple();
            c.Display1();
            Console.ReadLine();

        }

        public static void Display1(this Ifunc o)
        {
            Console.WriteLine(o.Add());

        }

    }

    






}
