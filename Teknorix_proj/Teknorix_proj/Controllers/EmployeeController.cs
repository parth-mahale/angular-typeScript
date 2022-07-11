using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Teknorix_proj.Models;

namespace Teknorix_proj.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult SearchDtls()
        {
            List<EmployeeModel> employee = new List<EmployeeModel>();
            return View(employee);
        }
        public ActionResult View()
        {
            List<EmployeeModel> _employee = new List<EmployeeModel>();
            //return View(_employee);
            String constring = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=Tenorix_temp; Integrated Security=true";
            SqlConnection sqlcon = new SqlConnection(constring);
            String SPName = "USP_GET_EMPLOYEE_DTLS"; ;
            sqlcon.Open();
            SqlCommand comm = new SqlCommand(SPName, sqlcon);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = comm.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);

            while (dr.Read())
            {
                EmployeeModel empDtls = new EmployeeModel();
                empDtls.EmpID = dr["emp_id"].ToString();
                empDtls.Fname = dr["emp_fname"].ToString();
                empDtls.Lname = dr["emp_lname"].ToString();
                empDtls.Gender = dr["emp_gender"].ToString();
                empDtls.Address = dr["emp_address"].ToString();
                empDtls.PhoneNumber = dr["emp_phone_no"].ToString();
                empDtls.MobileNumber = dr["emp_mobile_no"].ToString();
                empDtls.Designation = dr["Desgn_name"].ToString();
                empDtls.Department = dr["dept_name"].ToString();
                _employee.Add(empDtls);
            }
            return View(_employee);
        }
        [HttpPost]
        public JsonResult Save(EmployeeModel _employee)
        {
            _employee.Save(_employee);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(_employee);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddDetails()
        {
            EmployeeModel empDtls = new EmployeeModel();
            return View(empDtls);
        }
        public ActionResult GetDtlsByID(string ID)
        {
            List<EmployeeModel> _employee = new List<EmployeeModel>();
            String constring = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=Tenorix_temp; Integrated Security=true";
            SqlConnection sqlcon = new SqlConnection(constring);
            String SPName = "USP_GET_EMPLOYEE_DTLS_BY_ID"; ;
            sqlcon.Open();
            SqlCommand comm = new SqlCommand(SPName, sqlcon);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@EmpID", ID);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                EmployeeModel empDtls = new EmployeeModel();
                empDtls.EmpID = dr["emp_id"].ToString();
                empDtls.Fname = dr["emp_fname"].ToString();
                empDtls.Lname = dr["emp_lname"].ToString();
                empDtls.Gender = dr["emp_gender"].ToString();
                empDtls.Address = dr["emp_address"].ToString();
                empDtls.PhoneNumber = dr["emp_phone_no"].ToString();
                empDtls.MobileNumber = dr["emp_mobile_no"].ToString();
                empDtls.Designation = dr["emp_desgn_id"].ToString();
                _employee.Add(empDtls);

            }
            return View(_employee);
        }
        public JsonResult UpdateDtls(EmployeeModel UdpEmployee)
        {
            UdpEmployee.UpdateDtls(UdpEmployee);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(UdpEmployee);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteDtls(EmployeeModel DelEmployee)
        {
            DelEmployee.DeleteDtls(DelEmployee);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(DelEmployee);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult SearchEmp(string DeptID)
        //{
        //    List<EmployeeModel> _employee = new List<EmployeeModel>();
        //    String constring = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=Tenorix_temp; Integrated Security=true";
        //    SqlConnection sqlcon = new SqlConnection(constring);
        //    String SPName = "USP_SEARCH_EMPLOYEE"; ;
        //    sqlcon.Open();
        //    SqlCommand comm = new SqlCommand(SPName, sqlcon);
        //    comm.CommandType = CommandType.StoredProcedure;
        //    comm.Parameters.AddWithValue("@DeptID", DeptID);
        //    SqlDataReader dr = comm.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        EmployeeModel empDtls = new EmployeeModel();
        //        empDtls.EmpID = dr["emp_id"].ToString();
        //        empDtls.Fname = dr["emp_fname"].ToString();
        //        empDtls.Lname = dr["emp_lname"].ToString();
        //        empDtls.Gender = dr["emp_gender"].ToString();
        //        empDtls.Address = dr["emp_address"].ToString();
        //        empDtls.PhoneNumber = dr["emp_phone_no"].ToString();
        //        empDtls.MobileNumber = dr["emp_mobile_no"].ToString();
        //        empDtls.Designation = dr["emp_desgn_id"].ToString();
        //        _employee.Add(empDtls);

        //    }
        //    return View();
        //}
    }
}