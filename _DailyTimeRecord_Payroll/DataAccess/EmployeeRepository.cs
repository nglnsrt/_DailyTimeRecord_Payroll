using _DailyTimeRecord_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _DailyTimeRecord_Payroll.DataAccess
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository()
        {
        }

        public EmployeeRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public void AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Employees(ID, FirstName, MiddleName, LastName, Address, ContactNumber, Gender, Department, Position, EmploymentType, DateOfBirth, DateOfEmployment, Photo, DailyWage)
                    VALUES (@ID, @FirstName, @MiddleName, @LastName, @Address, @ContactNumber, @Gender, @Department, @Position, @EmploymentType, @DateOfBirth, @DateOfEmployment, @Photo, @DailyWage)";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", employee.EmployeeID);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@EmployementType", employee.EmploymentType);
                command.Parameters.AddWithValue("@EmploymentDate", employee.DateOfEmployment);
                command.Parameters.AddWithValue("@DailyWage", employee.DailyWage);
                command.Parameters.AddWithValue("@EmployeePicture", employee.Photo);
                command.Parameters.AddWithValue("@DailyWage", employee.DailyWage);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployee()
        {
            var employees = new List<Employee>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "Select Id, FirstName, MiddleName, LastName, Department, EmploymentType FROM Employees";
                var command = new SqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeID = reader.IsDBNull(0)? string.Empty:reader.GetString(0),
                            FirstName = reader.GetString(1),
                            MiddleName = reader.GetString(2),
                            LastName = reader.GetString(3),
                            Department = reader.GetString(4),
                            EmploymentType = reader.GetString(5),

                        });
                    }
                }
            }
            return employees;
        }
    }
}
