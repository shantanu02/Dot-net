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
            try
            {
                Employee e1 = new Manager("Aman", 4, "project manager", 89);
                Employee e2 = new GeneralManager("Arpit", 5, "CEO", "Ram", 50000);
                Employee e3 = new CEO("Dada", 6, 1100000);

                Console.WriteLine(e1.CalacNetSalary());
                Console.WriteLine(e2.CalacNetSalary());
                Console.WriteLine(e3.CalacNetSalary());

            }
            catch (InvalidDeptNoException ex)
            {
                Console.WriteLine("InvalidDeptNoException Occurred");
            }
            catch (InvalidBasicException ex)
            {
                Console.WriteLine("InvalidBasicException Occurred");
            }

            catch (InvalidNameException ex)
            {
                Console.WriteLine("InvalidNameException Occurred");
            }
            finally
            {
                Console.ReadLine();

            }
        }
    }


    abstract class Employee
    {

        #region Properties
        private static int counter = 0;
        private string name;
        public string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidNameException("name can't be blank");
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
        {   

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
                   throw new InvalidDeptNoException("DeptNo must be > 0");
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
        protected decimal basic;
        public abstract decimal Basic
        {
            get;
            set;
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
        public abstract decimal CalacNetSalary();

        #endregion


    }
    class Manager : Employee
    {
        private string designation;

        public string Designation
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidNameException("name can't be blank");
                }
                else
                {
                    designation = value;

                }
            }
            get
            {
                return designation;
            }
        }
        public override decimal Basic
        {
            get
            {

                return basic;
            }
            set
            {
                if(value <= 99)
                {
                    throw new InvalidBasicException("Basic cant be less then 100");
                }
                basic = value;
            }
        }
        public Manager(string Name, short DeptNo, string Designation = "manager", decimal Basic = 0) : base(Name, Basic, DeptNo)
        {

            this.Designation = Designation;

        }
        public override decimal CalacNetSalary()
        {

            return Basic + 10;
        }
    }

    class GeneralManager : Manager
    {
        private string perks;

        public string Perks
        {
            set
            {
                perks = value;

            }
            get
            {
                return perks;
            }
        }
        public override decimal Basic
        {
            set
            {
                basic = value;
            }
            get
            {
                return basic;
            }
        }

        public GeneralManager(string Name, short DeptNo, string Designation, string Perks, decimal Basic) : base(Name, DeptNo, Designation, Basic)
        {
            this.Perks = Perks;
        }
        public override decimal CalacNetSalary()
        {
            return Basic + 20;

        }
    }

    class CEO : Employee
    {
        public override decimal Basic
        {
            set
            {
                basic = value;
            }
            get
            {
                return basic;
            }
        }
        public CEO(string Name, short DeptNo, decimal Basic) : base(Name, DeptNo)
        {
            this.Basic = Basic;
        }
        public sealed override decimal CalacNetSalary()
        {
            return Basic + 30;

        }
    }

    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string message) : base(message)
        {

        }
    }
    public class InvalidRollNoException : ApplicationException
    {
        public InvalidRollNoException(string message) : base(message)
        {

        }
    }
    public class InvalidBasicException : ApplicationException
    {
        public InvalidBasicException(string message) : base(message)
        {

        }
    }
    public class InvalidDeptNoException : ApplicationException
    {
        public InvalidDeptNoException(string message) : base(message)
        {

        }
    }

}
