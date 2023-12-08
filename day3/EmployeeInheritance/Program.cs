using System.Xml.Linq;

namespace EmployeeInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDbFunctions o = new CEO("kshitij", 2);
            IDbFunctions o2 = new GeneralManager("1000", "Hrishi", 2);
            IDbFunctions o3 = new Manager("HR", "Arbaj", 4);

            Console.WriteLine(o);
            Console.WriteLine(o2);
            Console.WriteLine(o3);

            Console.WriteLine("Name of GM: " + (o2 as GeneralManager).Name);
        
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public abstract class Employee : IDbFunctions
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
        protected decimal basic;
        //Create a abstract property for Basic salary
        public abstract decimal Basic { get; set; }

        //Create a abstract method for generating NET salary
        public abstract decimal CalcNetSalary();
       
        private static int iDGenerator = 1;


        public Employee(string name = "default", short deptNo = 1)
        {
            this.EmpNo = Employee.iDGenerator++;
            this.Name = name;
            this.DeptNo = deptNo;

        }
        public override string ToString()
        {
            return "name = " + Name +  ", Department number = " + DeptNo + " ";
        }

        public void Insert()
        {
            Console.WriteLine("insert in employee class");
        }

        public void Update()
        {
            Console.WriteLine("update in employee class");
        }

        public void Delete()
        {
            Console.WriteLine("delete in employee class");
        }
    }

    public class Manager : Employee, IDbFunctions
    {
        private string? designation;

        public string Designation { 
            get { return designation!; }
            set 
            { 
                if(string.IsNullOrEmpty(value)==false)
                    designation = value;
                else
                    Console.WriteLine("Desgination can't be blank");
            } 
        }

        public override decimal Basic { 
            get { return basic; }
            set 
            {
                if (value > 50000)
                    basic = value;
                else
                    Console.WriteLine("Salary is to low for Manager!!!");
            }
        }

        public override decimal CalcNetSalary()
        {
            return Basic + 1000;
        }
        public Manager(string designation = "default_designation", string name = "default", short deptNo = 1) : base( name, deptNo )
        {
            this.Designation = designation;
        }

        public override string ToString()
        {
            return base.ToString() + "designation = " + Designation + " ";
        }
        public new void Insert()
        {
            Console.WriteLine("insert method - Manager class");
        }

        public new void Delete()
        {
            Console.WriteLine("delete method - Manager  class");
        }

        public new void Update()
        {
            Console.WriteLine("update method - Manager  class");
        }
    }

    public class GeneralManager : Manager,IDbFunctions
    {
        public override decimal Basic 
        { 
            get { return basic; }
            set 
            {
                if (value > 100000)
                    basic = value;
                else
                    Console.WriteLine("Salary is to low for General Manager!!!");
            }
        }
        public string Perks { get; set; }
        public GeneralManager(string perks,string name = "default", short deptNo = 1) : base("GeneralManager",name,deptNo)
        {
            this.Perks = perks;
        }
        public override string ToString()
        {
            return base.ToString() + "perks = " + Perks + " ";
        }
        public new void Insert()
        {
            Console.WriteLine("insert method - General Manager class");
        }

        public new void Delete()
        {
            Console.WriteLine("delete method - General Manager  class");
        }

        public new void Update()
        {
            Console.WriteLine("update method - General Manager  class");
        }
    }

    public class CEO : Employee,IDbFunctions
    {
        public override decimal Basic 
        {
            get { return basic; }
            set
            {
                if (value > 150000)
                    basic = value;
                else
                    Console.WriteLine("Salary is to low for CEO!!!");
            }
                
        }

        public override sealed decimal CalcNetSalary()
        {
            return Basic * 2 + 1000;
        }

        public CEO(string name = "default", short deptNo = 1) : base(name,deptNo) { }
        public new void Insert()
        {
            Console.WriteLine("insert method - CEO class");
        }

        public new void Delete()
        {
            Console.WriteLine("delete method - CEO  class");
        }

        public new void Update()
        {
            Console.WriteLine("update method - CEO  class");
        }
    }
}