using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryConcepts1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable o = new Hashtable();
            o.Add(1, "shantanu");
            o.Add(2, "Aditya");
            o.Add(3, "Vipul");
            o.Add(4, "Tony");
            o.Add(5, "Panther");
            o.Add(6, "Caption");

            o[4] = "Iron Man ";

            foreach(DictionaryEntry d in o)
            {
                Console.WriteLine(d.Key);
                Console.WriteLine(d.Value);
            }

            o.Remove(4);

            Console.WriteLine();
            foreach (DictionaryEntry d in o)
            {
                Console.WriteLine(d.Key);
                Console.WriteLine(d.Value);
            }

            Console.WriteLine();

            Console.WriteLine(o.ContainsKey(7));

            Console.WriteLine();

            Console.WriteLine(o.ContainsValue("Caption"));

            Console.WriteLine();

            Console.WriteLine(o.Count);

            Console.WriteLine();

            



            Console.ReadLine();
        }
    }
}
