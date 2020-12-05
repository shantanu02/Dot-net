using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 100;
            Object o;
            o = i; //Boxing

            //Storing a value type to the reference type
            //value type on the stact is copied to the heap and ref to that is created

            int j;
            j = (int)o;//Unboxing

            //Getting the value from the boxed ref type is called Unboxing
            //the box value is copied from the heap to the stack 


            //Boxing and Unboxing should be avoided as far as possible because it makes it slow to transer from stact to heap 



        }
    }
}
