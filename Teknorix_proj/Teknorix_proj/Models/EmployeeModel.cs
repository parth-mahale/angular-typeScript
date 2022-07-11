using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Teknorix_proj.Services;
using System.Text;
using System.Threading.Tasks;
using static Teknorix_proj.Models.DesignationModel;
using static Teknorix_proj.Models.DepartmentModel;

namespace Teknorix_proj.Models
{
    public class EmployeeModel
    {
        public string EmpID { get; set; }

        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Designation { get; set; }
        public string Department { get; set; }


        //public List<Employee> EmployeeList { get; set; }
        public DesignationList Designations { get; set; }

        public DepartmentList Departments { get; set; }

        public void Save(EmployeeModel _employee)
        {
            TeknorixServices teknoService = new TeknorixServices();
            teknoService.Save(_employee);
        }
        public void UpdateDtls(EmployeeModel UdpEmployee)
        {
            TeknorixServices teknoService = new TeknorixServices();
            teknoService.UpdateDtls(UdpEmployee);
        }
        public void DeleteDtls(EmployeeModel UdpEmployee)
        {
            TeknorixServices teknoService = new TeknorixServices();
            teknoService.DeleteDtls(UdpEmployee);
        }

    }
    
    //public class Employees
    //{
    //    public string EmpID { get; set; }

    //    [Required]
    //    public string Fname { get; set; }
    //    [Required]
    //    public string Lname { get; set; }
    //    [Required]
    //    public string Gender { get; set; }
    //    [Required]
    //    public string Address { get; set; }
    //    [Required]
    //    public string PhoneNumber { get; set; }
    //    [Required]
    //    public string MobileNumber { get; set; }
    //    [Required]
    //    public string Designation { get; set; }
    //    public string Department { get; set; }

    //}
    //public enum Genders
    //{
    //    Male,
    //    Female
    //}

}