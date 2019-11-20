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
            //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionStr);
            ////////////////////////////////////
            ConnectionStringSettingsCollection list = ConfigurationManager.ConnectionStrings;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["myConnectionString"];
            Console.WriteLine("The connection strings value is : "+ list);
            using IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            return db.Query<Employee> ("Select * From Employee").ToList();
        }
    }
}
