using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAssign
{
    class Program
    {
        static void Main(string[] args)
        {  //Q1
            Func<decimal, decimal, decimal, decimal> simpleIntrest = (decimal p, decimal n, decimal r) => (p*n*r) / 100;
            Console.WriteLine("simpleIntrest(1000,2,5): "+ simpleIntrest(1000, 2, 5));

            //Q2
            Func<int, int,bool> isGreat = (int a, int b) => a > b; // cant use predicate as predicate won't allow 2 parametrs
            Console.WriteLine("isGreat(10,20): "+isGreat(10,20));

            //Q3
            Func<Employee, decimal> getBasic = (Employee e) => e.getBasic(e);
            Employee emp = new Employee();
            Console.WriteLine("Basic: "+getBasic(emp));

            //Q4
            Predicate<int> isEven = (int num) => (num % 2 == 0)?true:false;
            Console.WriteLine("isEven(10): "+ isEven(1));

            //Q5
            Predicate<Employee> IsGreaterThan1000 = (Employee e) => e.IsGreaterThan10000(e) ? true : false;
            Console.WriteLine("IsGreaterThan1000(emp): " + IsGreaterThan1000(emp));
            Console.ReadLine();

        }
    }
    class Employee
    {
        public decimal basic = 11000;

        public decimal getBasic(Employee emp)
        {
            return emp.basic;
        }

        public bool IsGreaterThan10000(Employee emp1)
        {
            return emp1.basic > 10000;
        }
    }
}
