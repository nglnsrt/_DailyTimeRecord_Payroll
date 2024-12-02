using _DailyTimeRecord_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DailyTimeRecord_Payroll.DataAccess
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        List<Employee> GetAllEmployee();
    }
}
