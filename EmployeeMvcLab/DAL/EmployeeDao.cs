using EmployeeMvcLab.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeMvcLab.DAL
{
    public class EmployeeDao : IEmployeeDao
    {
        public List<Employee> employees = new List<Employee>();
        public string AddEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab;Integrated Security=True";
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();

            SqlCommand InsertCmd = new SqlCommand();
            InsertCmd.Connection = conn;
            InsertCmd.Transaction = tx;
            InsertCmd.CommandType = System.Data.CommandType.StoredProcedure;
            InsertCmd.CommandText = "InsertEmployee";
            InsertCmd.Parameters.AddWithValue("@Name", employee.Name);
            InsertCmd.Parameters.AddWithValue("@City", employee.City);
            InsertCmd.Parameters.AddWithValue("@Address", employee.Address);
            try
            { 
                InsertCmd.ExecuteNonQuery();
                tx.Commit();
                return "Employee Added Successfully!!";
            }catch (Exception)
            {
                tx.Rollback();
                throw new Exception("Employee Added Failed!!");
            }
        }

        public string DeleteEmployee(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab;Integrated Security=True";
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();

            SqlCommand deleteCmd = new SqlCommand();
            deleteCmd.Connection = conn;
            deleteCmd.Transaction = tx;
            deleteCmd.CommandType = System.Data.CommandType.Text;
            deleteCmd.CommandText = "DELETE FROM emps WHERE Id = @Id";
            deleteCmd.Parameters.AddWithValue("@Id", id);
            try
            {
                deleteCmd.ExecuteNonQuery();
                tx.Commit();
                return "Employee Deleting Success!!";
            }
            catch (Exception)
            {
                tx.Rollback();
                throw new Exception("Employee Deleting Failed!!"); ;
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab;Integrated Security=True";
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.Transaction = tx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from emps";
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                employees.Add(new Employee {Id = dr.GetInt32(0),Name = dr.GetString(1),City = dr.GetString(2),Address = dr.GetString(3)});
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab;Integrated Security=True";
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.Transaction = tx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from emps where Id =@id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            return new Employee { Id = dr.GetInt32(0), Name = dr.GetString(1), City = dr.GetString(2), Address = dr.GetString(3) };

            return null;
        }

        public string UpdateEmployee(int id,Employee employee)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab;Integrated Security=True";
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();

            SqlCommand InsertCmd = new SqlCommand();
            InsertCmd.Connection = conn;
            InsertCmd.Transaction = tx;
            InsertCmd.CommandType = System.Data.CommandType.StoredProcedure;
            InsertCmd.CommandText = "UpdateEmployee";
            InsertCmd.Parameters.AddWithValue("@id", employee.Id);
            InsertCmd.Parameters.AddWithValue("@Name", employee.Name);
            InsertCmd.Parameters.AddWithValue("@City", employee.City);
            InsertCmd.Parameters.AddWithValue("@Address", employee.Address);
            try
            {
                InsertCmd.ExecuteNonQuery();
                tx.Commit();
                return "Employee Updated Successfully!!";
            }
            catch (Exception)
            {
                tx.Rollback();
                throw new Exception("Employee Updated Failed!!");
            }
        }
    }
}
