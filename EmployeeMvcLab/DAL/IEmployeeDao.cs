using EmployeeMvcLab.Models;

namespace EmployeeMvcLab.DAL
{
    public interface IEmployeeDao
    {
        //View All Employee
        public IEnumerable<Employee> GetAllEmployee();
        
        //Add New Employee
        public string AddEmployee(Employee employee);
        
        //Update Employee Details
        public string UpdateEmployee(int id,Employee employee);
        
        //Delete Employee
        public string DeleteEmployee(int id);

        //Details Employee
        public Employee GetEmployeeById(int id);
    }
}
