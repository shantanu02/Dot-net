using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number 0f batches :");
            int nob = Convert.ToInt32(Console.ReadLine());
            int[][] arr = new int[nob][];
            
            for(int i = 0; i < nob; i++)
            {
                Console.WriteLine("Enter Student in {0} batch",i+1);
                int val = Convert.ToInt32(Console.ReadLine());
                arr[i] = new int[val];
            }

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; i <arr[i].Length; j++)
                {
                    Console.WriteLine("Enter marks for batch {0} , student {1} : ",i+1,j+1);
                    arr[i][j]= Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }




        }
    }
}
