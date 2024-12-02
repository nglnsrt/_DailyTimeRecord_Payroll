using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DailyTimeRecord_Payroll.Models
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string FirstName {  get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string EmploymentType { get; set; }
        public string DailyWage { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[]Photo  { get; set; }
        
    }
}
