using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class EmployeeBLL
    {
        private EmployeeDAL employeeDAL = new EmployeeDAL();

        public DataTable GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }

        public bool AddEmployee(string name, string email, string department, decimal salary)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(department))
                throw new ArgumentException("Fields cannot be empty.");

            return employeeDAL.AddEmployee(name, email, department, salary);
        }
    }
}