using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> l = new List<int>();
            l.Add(34);
            l.Add(44);
            l.Add(54);
            l.Add(64);
            l.Add(74);
            l.Add(94);

            foreach(int i in l)
            {
                Console.WriteLine(i);
            }



        }
    }
}
