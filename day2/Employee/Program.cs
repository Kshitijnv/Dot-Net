using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Employee1
{
    internal class Program
    {

        static void Main()
        {
            Employee o1 = new Employee("Amol", 123465, 10);

            Employee o2 = new Employee("Amol", 123465);

            Employee o3 = new Employee("Amol");

            Employee o4 = new Employee();

            Console.WriteLine(o1.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o4.EmpNo);

            Console.WriteLine("Net salary of "+o1.Name+" " +o1.GetNetSalary());
            Console.WriteLine(o1);
        }
    }
    public class Employee
    {
        private string name;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name can't be blank/empty");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int EmpNo { get; set; }
        //field
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
                    Console.WriteLine("Dept. number can't be less than ZERO");
                }
            }
        }

        private decimal basic;
        public decimal Basic
        {
             get { return basic; }
            set
            {
                if (value > 10000 && value < 200000)
                    basic = value;
                else
                    Console.WriteLine("Basic salary is not in range!!!");
            }
        }
        //Create a method for generating NET salary
        public decimal GetNetSalary()
        {
            return CalculatorSalary.Class1.GetNetSalary(Basic);
        }
        private static int iDGenerator = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="basic"></param>
        /// <param name="deptNo"></param>
        public Employee(string name = "", decimal basic = 0, short deptNo = 0)
        {
            this.EmpNo = Employee.iDGenerator++;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
          
        }
        public override string ToString()
        {
            return "name = " + Name + ", basic salary = " + Basic + ", Department number = " + DeptNo + "]";
        }
    }
}