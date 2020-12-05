using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add("Shantanu");
            objArrayList.Add("Vipul");
            objArrayList.Add("Aditya");
            objArrayList.Add("Tony");
            objArrayList.Add("Panther");
            objArrayList.Add(1234);
            objArrayList.Add(true);

            objArrayList.Remove(true);
            objArrayList.RemoveAt(4);

            int i = objArrayList.Count;
            Console.WriteLine("The number of elements : "+i);

            //objArrayList.AddRange(obj2);

            int pos = objArrayList.IndexOf("Shantanu");

            Console.WriteLine("Positon of Shantanu : "+pos);

            Console.WriteLine("Capacity :");
             objArrayList.Capacity = 10;

            Console.WriteLine(objArrayList.Capacity);



            Console.WriteLine();
            Console.WriteLine("ArrayList ->->-> ");
            foreach(object s in objArrayList)
            {
                Console.WriteLine(s);
            }

            //Console.WriteLine();
            //Console.WriteLine("ArrayList after clear ->->-> ");

            //objArrayList.Clear();

            //foreach (object s in objArrayList)
            //{
            //    Console.WriteLine(s);
            //}

            Console.WriteLine();

            Console.WriteLine(objArrayList.Contains("Vipul"));
            Console.WriteLine(objArrayList.Contains("xxxx"));


            Console.WriteLine();

            objArrayList.Insert(0, "Shantanu Upase");
            Console.WriteLine();
            Console.WriteLine("ArrayList ->->-> ");
            foreach (object s in objArrayList)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            //objArrayList.InsertRange(1, new ArrayList() //takes any collection);

             Object[] arr = objArrayList.ToArray();

            Console.WriteLine();
            Console.WriteLine("ArrayList to ToArray ->->-> ");
            foreach (object s in arr)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            //objArrayList.RemoveRange(3, 2);

            //Console.WriteLine();
            //Console.WriteLine("ArrayList ->->-> ");
            //foreach (object s in objArrayList)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine();

            objArrayList.TrimToSize();
            Console.WriteLine("New Capacity of after Trim to Size -->");
            Console.WriteLine(objArrayList.Capacity);



            Console.ReadLine();



                
        }
    }
}
