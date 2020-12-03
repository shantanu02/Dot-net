using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Employee e1 = new Manager("A",10,2000,"tech manager");
            Employee e2 = new GeneralManager("B",20,5000,"HR manager","xyz");
            Employee e3 = new CEO("C",30,10000);
            Console.WriteLine(e3.CalacNetSalary());//50000
            Console.WriteLine(e2.CalacNetSalary());//15000

            Console.WriteLine(e1.CalacNetSalary());//4000
           
            Console.ReadLine();

        }
    }

    public abstract class Employee
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

        private static int lastEmpNo = 0;

        private int empNo;

        public int Empno
        {
            get { return empNo; }
            private set
            {
                empNo = value;
            }
        }

        private short deptNo;

        public short DeptNo
        {
            get
            {
                return deptNo;
            }

            set
            {
                if (value > 0)
                {
                    deptNo = value;
                }
                else
                {
                    Console.WriteLine("department number should be greater than 0");
                }
            }
        }

        public Employee(string name = "noname", short deptNo = 1, decimal basic = 0)
        {
            empNo = ++lastEmpNo;
            this.name = name;
            this.deptNo = deptNo;
            this.basic = basic;
        }


        protected decimal basic;
        public abstract decimal Basic
        {
            get;
            set;
        }

        public abstract decimal CalacNetSalary();


    }

    public class Manager : Employee
    {
        private string designation;
        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value;
            }
        }

        //private decimal basic;
        public override decimal Basic
        {
            get
            {
              
                return basic;
            }
            set
            {
              
                basic = value;
            }
        }

        public Manager(string name, short deptNo,  decimal basic,string designation = "manager") : base(name, deptNo,basic)
        {
            
            //this.basic = basic;
            this.designation = designation;

        }



        public override decimal CalacNetSalary()
        {
            
            return Basic*2;
        }
    }

    public class GeneralManager : Manager
    {
        private string perks;

        public string Perks
        {
            get
            {
                return perks;
            }
            set
            {
                perks = value;
            }
        }
        //private decimal basic;

        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                basic = value;
            }
        }

        public GeneralManager(string name, short deptNo, decimal basic, string designation,  string perks ) : base(name, deptNo,basic, designation)
        {
            //this.basic = basic;
            this.perks = perks;
        }

        public override decimal CalacNetSalary()
        {
            return Basic*3;
        }


    }

    public class CEO : Employee
    {

        //private decimal basic;
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                basic = value;
            }
        }

        public override sealed decimal CalacNetSalary()
        {
            return Basic*5;
        }

        public CEO(string name, short deptNo, decimal basic) : base(name, deptNo,basic)
        {
            //this.basic = basic;
        }
    }


}
