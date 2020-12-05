using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3,4];

            Console.WriteLine(arr.Rank);//2

            Console.WriteLine(arr.GetLength(0));//3
            Console.WriteLine(arr.GetLength(1));//4

            Console.WriteLine(arr.GetLowerBound(0));//0
            Console.WriteLine(arr.GetUpperBound(0));//2

            Console.WriteLine(arr.GetLowerBound(1));//0
            Console.WriteLine(arr.GetUpperBound(1));//3


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine("Enter marks for student {0} and subjects {1}",i+1,j+1);
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }

            }
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine("marks for student {0} and subjects {1} is {2}", i+1, j+1,arr[i,j]);
                    
                }

            }

            Console.ReadLine();

        }
    }
}
