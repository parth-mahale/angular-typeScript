using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Models
{
    public class DepartmentsModel
    {
        [Key]
        public int DeptID { get; set; }

        public string DepartmentName { get; set; }
    }
}
