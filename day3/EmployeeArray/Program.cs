namespace EmployeeArray
{
    internal class Program
    {
        static void Main()
        {
            /*
             * 2. Create an array of Employee class objects
            Accept details for all Employees
            Display the Employee with highest Salary
            Accept EmpNo to be searched. Display all details for that employee.
             */

            //Create an array of Employee class objects
            Console.WriteLine("Enter the number of employees");
            Employee[] employees = new Employee[Convert.ToInt32(Console.ReadLine())];

            //Accept details for all Employees
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine("Enter the name of employee : ");
                string? name = Console.ReadLine();
                Console.WriteLine("Enter the basic salary of employee : ");
                decimal salary = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter the department number : ");
                short deptNo = Convert.ToInt16(Console.ReadLine());
                employees[i] = new Employee(name!,salary,deptNo);
                Console.WriteLine(employees[i].EmpNo);
            }
            decimal maxSalary = 10000;
            int highestEmp = 0; ;
            // Display the Employee with highest Salary
            for(int i = 0;i < employees.Length;i++) {
                if (employees[i].Basic> maxSalary) { 
                    maxSalary = employees[i].Basic;
                    highestEmp = i;
                }
            }
            Console.WriteLine(employees[highestEmp]);
            //Accept EmpNo to be searched. Display all details for that employee.
            Console.WriteLine("Enter employee Number: ");
            Console.WriteLine(employees[Convert.ToInt32(Console.ReadLine())+1]);
        }


    }
    public class Employee
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
                if (value >= 10000 && value < 200000)
                    basic = value;
                else
                    Console.WriteLine("Basic salary is not in range!!!");
            }
        }
        //Create a method for generating NET salary
        public decimal GetNetSalary()
        {
            return 0/*CalculatorSalary.Class1.GetNetSalary(Basic)*/;
        }
        private static int iDGenerator = 1;

       
        public Employee(string name = "default", decimal basic = 10000, short deptNo = 1)
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