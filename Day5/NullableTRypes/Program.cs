using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? i = 0;
            i = null;

            int j = 1;

            if(i != null)
            {

                j = (int)i;
            }
            else
            {
                j = 0; 
            }

            if (i.HasValue)
                j = i.Value;
            else
                j = 0;

            j = i.GetValueOrDefault();
            j = i.GetValueOrDefault(10);
            j = i ?? 10; //null coalescing operator

            //i = j; 

            Console.WriteLine(j);

            Console.ReadLine();

        }
    }
}
