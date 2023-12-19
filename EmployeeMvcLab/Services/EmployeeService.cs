using EmployeeMvcLab.DAL;
using EmployeeMvcLab.Models;

namespace EmployeeMvcLab.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDao _employeeDao;
        public EmployeeService(IEmployeeDao employeeDao) 
        {
            _employeeDao = employeeDao;
        }
        public string AddEmployee(Employee employee)
        {
            string retval = _employeeDao.AddEmployee(employee);
            return retval;
        }

        public string DeleteEmployee(int id)
        {
            string retval = _employeeDao.DeleteEmployee(id);
            return retval;

        }

        public Employee GetEmployee(int id)
        {
           return _employeeDao.GetEmployeeById(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDao.GetAllEmployee();
        }

        public string UpdateEmployee(int id, Employee employee)
        {
            string retval = _employeeDao.UpdateEmployee(id, employee);
            return retval;

        }
    }
}
