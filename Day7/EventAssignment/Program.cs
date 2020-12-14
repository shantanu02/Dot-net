using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ExceptionAssign
{

    class Program
    {
        static void Main(string[] args)
        {
                Employee e1 = new Employee("Aman", 100, 101);
                e1.InvalidBasic += InvalidBasicHandler;
                e1.InvalidDeptNo += InvalidDeptNoHandler;
                e1.InvalidName += InvalidNameHandler;
                Console.WriteLine(e1.CalacNetSalary());

           // e1.Name = "";
            e1.Basic = 99 ;
            e1.DeptNo = 0;
            e1.Name = "";
            Console.ReadLine();
           
        }
        static void InvalidNameHandler(string name)
        {
            Console.WriteLine("Invalid Name: "+name);
        }
        static void InvalidBasicHandler(decimal basic)
        {
            Console.WriteLine("Invalid Basic: " + basic);
        }
        static void InvalidDeptNoHandler(int deptNo)
        {
            Console.WriteLine("Invalid DeptNo: " + deptNo);
        }
    }

    public delegate void InvalidNameEventHandler(string Value);
    public delegate void InvalidDeptNoEventHandler(int Value);
    public delegate void InvalidBasicEventHandler(decimal Value);


    class Employee
    {
        public event  InvalidNameEventHandler InvalidName;
        public event InvalidBasicEventHandler InvalidBasic;
        public event InvalidDeptNoEventHandler InvalidDeptNo;


        #region Properties
        private static int counter = 0;
        private string name;
        public string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    //Console.WriteLine("name can't be blank");
                    if (InvalidName != null)
                        InvalidName(value);
                }
                else
                {
                    name = value;

                }
            }
            get
            {
                return name;
            }
        }
        private int empNo = 0;
        public int EmpNo
        {   // read only

            get
            {
                return empNo;
            }
            private set
            {
                empNo = value;
            }
        }
        private short deptNo;
        public short DeptNo
        {
            set
            {
                if (value <= 0)
                {
                    // Console.WriteLine("DeptNo must be > 0");
                    if (InvalidDeptNo != null)
                        InvalidDeptNo(value);
                }
                else
                {
                    deptNo = value;
                }
            }
            get
            {
                return deptNo;
            }
        }
        private decimal basic;
        public decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {   if(Basic < 100)
                {
                    // Console.WriteLine("Basic must be > 99");
                    if (InvalidBasic != null)
                        InvalidBasic(value);
                }
                else
                {
                    basic = value;

                }
            }
        }

        #endregion

        #region Constructors

        public Employee(string Name = "Default Name", decimal Basic = 51, short DeptNo = 1)
        {
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
            this.EmpNo = ++counter;

        }

        #endregion
        #region Methods
        public decimal CalacNetSalary()
        {
            return Basic + 1000;
        }

        #endregion


    }
    
}

