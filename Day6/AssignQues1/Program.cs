using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignDay61
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, Employee> objemp = new SortedList<int, Employee>();

            int key = 0;
            string ch = "yes";
            while (ch != "no")
            {
                Console.WriteLine("Enter the number of Employees");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {

                    Console.WriteLine("Enter Empid ");
                    int empid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Employee Name ");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter Employee Salary ");
                    double sal = Convert.ToInt64(Console.ReadLine());
                    objemp.Add(++key, new Employee(empid, userName, sal));

                }
                Console.WriteLine("Do you want to continue");
                ch = Console.ReadLine();
            }
            Console.WriteLine();
            foreach (KeyValuePair<int, Employee> objDic in objemp)
            {
                Console.WriteLine("Employee id is- {0} , Employee name is- {1} and Employee salary is- {2}",
                    objDic.Value.Pempid, objDic.Value.Pname, objDic.Value.Psalary);
            }

            Console.WriteLine();

            Console.WriteLine("Enter Employee ID to search Employee");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<int, Employee> objDic in objemp)
            {
                if (id == objDic.Value.Pempid)
                {
                    Console.WriteLine("Record found ");
                    Console.WriteLine("Employee id is- {0} , Employee name is- {1} and Employee salary is- {2}",
                        objDic.Value.Pempid, objDic.Value.Pname, objDic.Value.Psalary);


                }
                else
                {
                    Console.WriteLine("No record Found");
                }
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Enter number of records to display");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            foreach (KeyValuePair<int, Employee> objDic in objemp)
            {
                Console.WriteLine("Employee id is- {0} , Employee name is- {1} and Employee salary is- {2}",
                    objDic.Value.Pempid, objDic.Value.Pname, objDic.Value.Psalary);
                count++;
                if (count == n1)
                {
                    break;

                }
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
