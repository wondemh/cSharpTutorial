using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    class EmployeeDAO
    {
        public List<Employee> GetAllEmployees()
        {            
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["myConnectionString"];
            using IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return conn.Query<Employee> ("Select * From Employee").ToList();
        }

        public Employee GetEmployee(string uid)
        {
            string sql = "SELECT * FROM Employee WHERE UID = @EmployeeUID; SELECT * FROM EmployeeReview WHERE EmployeeUID = @EmployeeUID ;";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple(sql, new { EmployeeUID = uid }))
                {
                    var employee = multi.Read<Employee>().First();
                    var employeeReviews = multi.Read<EmployeeReview>().ToList();

                    employee.Reviews = employeeReviews;
                    return employee;
                }
            }
            //return null;
        }
    }
}
