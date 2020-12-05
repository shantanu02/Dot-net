using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] empArray = new Employee[3];

            for (int i = 0; i < empArray.Length; i++)
            {
                Console.WriteLine("Enter ID : ");
                int id  =Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Email : ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Marks : ");
                int marks = Convert.ToInt32(Console.ReadLine());

                empArray[i] = new Employee(id, name, email,marks);

            }

            int max_marks = empArray[0].Marks;
            int flag = 0;
            for(int i = 0; i < empArray.Length; i++)
            {
                if (empArray[i].Marks > max_marks)
                {
                    max_marks = empArray[i].Marks;
                    flag = i;

                }
                   
            }
            Console.WriteLine("Details of highest marks student : ");
            Console.WriteLine("Name : "+ empArray[flag].Name);
            Console.WriteLine("Email : " + empArray[flag].Email);
            Console.WriteLine("Marks : " + empArray[flag].Marks);

            Console.WriteLine();

            Console.WriteLine("Enter ID to search : ");
            int sid = Convert.ToInt32(Console.ReadLine());
            int s_id = 0 ;
            for(int i = 0; i < empArray.Length; i++)
            {
                if(empArray[i].Id == sid)
                {
                    s_id = empArray[i].Id;
                    break;
                }
            }
            Console.WriteLine("Details of {0} student Id : ",sid);
            Console.WriteLine("Name : " + empArray[s_id].Name);
            Console.WriteLine("Email : " + empArray[s_id].Email);
            Console.WriteLine("Marks : " + empArray[s_id].Marks);


        }

       

    }

    public class Employee
    {

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

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

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        private int marks;

        public int Marks
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

        public Employee(int id = 1, string name = "noname" , string email = "noemail", int marks = 0 )
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.marks = marks;
        }


    }
}
