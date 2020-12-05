using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortedList
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedList<int, string> s = new SortedList<int, string>();

            s.Add(1, "A");
            s.Add(2, "AA");
            s.Add(3, "AAA");
            s.Add(4, "AAAA");
            s.Add(5, "AAAAAA");

            foreach(KeyValuePair<int , string> i in s)
            {
                Console.WriteLine(i.Key);
                Console.WriteLine(i.Value);
            }

            Console.WriteLine();

            Console.ReadLine();



        }
    }
}
