using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackConcepts
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack s = new Stack();
            s.Push(1000);
            s.Push(2000);
            s.Push(4500);

            Console.WriteLine(s.Pop());

            Console.WriteLine(s.Peek());


            Queue q = new Queue();
            q.Enqueue(245);
            q.Enqueue(246);
            q.Enqueue(645);
            q.Enqueue(845);
            q.Enqueue(445);

            Console.WriteLine(q.Dequeue());

            Console.WriteLine(q.Peek());

        }
    }
}
