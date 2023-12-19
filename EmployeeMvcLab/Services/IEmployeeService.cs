using EmployeeMvcLab.DAL;
using EmployeeMvcLab.Models;

namespace EmployeeMvcLab.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        string AddEmployee(Employee employee);
        string UpdateEmployee(int id,Employee employee);
        string DeleteEmployee(int id);

        Employee GetEmployee(int id);

    }
}
