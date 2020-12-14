using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConcepts
{
    class Program
    {
        static List<Department> lstDept = new List<Department>();
        static List<Employee> lstEmp = new List<Employee>();

        static void Main(string[] args)
        {
            AddRecords();

            //var emps = from emp in lstEmp select emp;
            //foreach(var item in emps)
            //{
            //    Console.WriteLine(item.Name);
            //     Console.WriteLine(item.EmpNo);
            //    Console.WriteLine(item.Basic);
            //    Console.WriteLine();


            //}

            //var emps = from emp in lstEmp select emp.Name;

            //foreach(var item in emps)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}

            //var emps = from emp in lstEmp select new { emp.EmpNo , emp.Name , emp.Basic};

            //foreach(var item in emps)
            //{
            //    Console.WriteLine(item.EmpNo);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Basic);
            //    Console.WriteLine();
            //}

            //var emps = from emp in lstEmp orderby emp.Name ascending where (emp.Basic > 10000 && emp.Basic < 13000) select emp;

            //foreach(var item in emps)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Basic);
            //    Console.WriteLine();
            //}

            //var emps = from emp in lstEmp where emp.Name.StartsWith("Vi") select emp;

            //var emps = from emp in lstEmp where emp.Name.EndsWith("am") select emp;



            //foreach (var item in emps)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Basic);
            //    Console.WriteLine();
            //}

            var emps = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select new { emp.Name, dept.DeptName };

            foreach(var item in emps)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.DeptName);
                Console.WriteLine();
            }




            Console.ReadLine();

        }


        public static void AddRecords()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "Sales" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 13000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "shweta", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 12000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 13000, DeptNo = 30, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shradha", Basic = 11000, DeptNo = 40, Gender = "F" });


        }

    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }

    }


    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

        public int Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }


    }

   


}
