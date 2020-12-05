using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignDay6_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee[] empArr = new Employee[5];

            for(int i = 0; i < empArr.Length; i++)
            {
                Console.WriteLine("Enter Empid ");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name ");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary ");
                double sal = Convert.ToInt64(Console.ReadLine());

                empArr[i] = new Employee(empid, userName, sal);


            }

            List<Employee> el = new List<Employee>(empArr);
            
            foreach(Employee e in el)
            {
                Console.WriteLine(e.Pempid);
                Console.WriteLine(e.Pname);
                Console.WriteLine(e.Psalary);
            }


            Console.ReadLine();
        }
    }

    public class Employee
    {
        private int empid;
        private string ename;
        private double salary;
        public int Pempid
        {
            get
            {
                return empid;
            }
        }
        public string Pname
        {
            get
            {
                return ename;
            }
        }
        public double Psalary
        {
            get
            {
                return salary;
            }
        }
        public Employee()
        {

        }

        public Employee(int id, string name, double salary)
        {
            empid = id;
            ename = name;
            this.salary = salary;
        }

    }
}
