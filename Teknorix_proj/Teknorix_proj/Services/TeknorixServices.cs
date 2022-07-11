using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Teknorix_proj.Models;

namespace Teknorix_proj.Services
{
    public class TeknorixServices
    {
        private SqlConnection _SqlConnection;
        private SqlCommand _SqlCommand;

        public TeknorixServices()
        {
            _SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TeknorixConnectionString"].ConnectionString);
            _SqlCommand = new SqlCommand();
        }
        public void Save(EmployeeModel employee)
        {
            _SqlConnection.Open();
            _SqlCommand = new SqlCommand("USP_Insert_EmpDtls", _SqlConnection);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddWithValue("@EmpID", employee.EmpID="0");
            _SqlCommand.Parameters.AddWithValue("@Fname", employee.Fname);
            _SqlCommand.Parameters.AddWithValue("@Lname", employee.Lname);
            _SqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _SqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            _SqlCommand.Parameters.AddWithValue("@PhoneNo", employee.PhoneNumber);
            _SqlCommand.Parameters.AddWithValue("@MobileNo", employee.MobileNumber);
            _SqlCommand.Parameters.AddWithValue("@desgn", employee.Designation);
            _SqlCommand.Parameters.AddWithValue("@Dept", employee.Department);
            _SqlCommand.ExecuteNonQuery();
            _SqlConnection.Close();
        }
        public void UpdateDtls(EmployeeModel UdpEmployee)
        {
            _SqlConnection.Open();
            _SqlCommand = new SqlCommand("USP_UDP_EmpDtls", _SqlConnection);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddWithValue("@EmpID", UdpEmployee.EmpID);
            _SqlCommand.Parameters.AddWithValue("@Fname", UdpEmployee.Fname);
            _SqlCommand.Parameters.AddWithValue("@Lname", UdpEmployee.Lname);
            _SqlCommand.Parameters.AddWithValue("@Gender", UdpEmployee.Gender);
            _SqlCommand.Parameters.AddWithValue("@Address", UdpEmployee.Address);
            _SqlCommand.Parameters.AddWithValue("@PhoneNo", UdpEmployee.PhoneNumber);
            _SqlCommand.Parameters.AddWithValue("@MobileNo", UdpEmployee.MobileNumber);
            _SqlCommand.Parameters.AddWithValue("@desgn", UdpEmployee.Designation);
            _SqlCommand.Parameters.AddWithValue("@Dept", UdpEmployee.Department);
            _SqlCommand.ExecuteNonQuery();
            _SqlConnection.Close();
        }
        public void DeleteDtls(EmployeeModel UdpEmployee)
        {
            _SqlConnection.Open();
            _SqlCommand = new SqlCommand("USP_DELETE_EMP_DTLS", _SqlConnection);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddWithValue("@EmpID", UdpEmployee.EmpID);
            _SqlCommand.ExecuteNonQuery();
            _SqlConnection.Close();
        }


    }
}