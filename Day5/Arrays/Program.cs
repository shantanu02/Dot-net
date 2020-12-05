using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            //System.Array (Abstreact Class)
            //int[] derived from the Array class
            //we can't do it explicitly
 
            int[] arr = new int[5];
            
            arr[0] = 101;
            /*
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("enter element no {0}",i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            
            }

            //read only loop 
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
            */

            Console.WriteLine("------------");

            int[] ar = new int[5];
            int[] ar1 = new int[5];
            int[] ar2 = new int[5];

            Array.Clear(ar, 0, 5);
            Array.Copy(ar, ar1, 3);
            //Array.ConstrainedCopy(ar,ar2,5);
            //int pos = Array.IndexOf(ar, 3);
            //return -1 if not found 

            int pos = Array.LastIndexOf(ar, 5);
            //start looking from the end of the array 

            //array should bew sorted in thew case of binary search
            int pos1 = Array.BinarySearch(ar, 4);

            Array.Reverse(ar);

            Array.Sort(ar);

            

            foreach (int i in ar)
            {
                Console.WriteLine(i);
            }





            Console.ReadLine();

        }
    }
}
