using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] sa = new Student[5];

            for(int i = 0; i < sa.Length; i++)
            {
                Console.WriteLine("Enter name of student :");
                string n = Console.ReadLine();
                Console.WriteLine("Enter roll no of the student :");
                int r = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the marks of {0} student :",i+1);
                decimal m = Convert.ToDecimal(Console.ReadLine());

                Student s = new Student(n, r, m);
                
            }

            foreach(Student s in sa)
            {
                Console.WriteLine(s.Name + "  "+s.RollNo+" "+s.Marks );
            }

        }
    }

    public struct Student
    {
        private string name; 
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int rollNo;

        public int RollNo
        {
            get
            {
                return rollNo;
            }
            set
            {
                rollNo = value;
            }
        }

        private decimal marks;
        public decimal Marks
        {
            get
            {
                return marks;

            }
            set
            {
                marks = value;
            }
        }


        public Student(string name ="noname", int rollNo = 1,decimal marks = 0)
        {
            this.name = name;
            this.rollNo = rollNo;
            this.marks = marks;
        }

    }

}
