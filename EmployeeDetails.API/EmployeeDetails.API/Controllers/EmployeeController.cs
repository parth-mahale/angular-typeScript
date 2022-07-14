using EmployeeDetails.API.Data;
using EmployeeDetails.API.Models;
using EmployeeDetails.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _Db;
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context, IEmployeeRepository Db)
        {
            _context = context;
            _Db = Db;
        }

        //public EmployeeController(IEmployeeRepository Db)
        //{
        //    _Db = Db;
        //}        //public EmployeeController(IEmployeeRepository Db)
        //{
        //    _Db = Db;
        //}

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _Db.GetAllEmployeeList());
        }

        [HttpGet]
        [Route("GetEmployeeDtlsByID")]
        //[Route("GetEmployeeDtlsByID/{id}")]              
        public async Task<IActionResult> GetEmployeeDtlsByID(int id)
        {
            return Ok(await _Db.GetEmployeeDtlsByID(id));
        }
                                 
        [HttpPost]       
        [Route("AddEmployees")]
        public async Task<IActionResult> AddEmployees(EmployeeModel emp)
        {
            return Ok(_Db.AddEmployees(emp));
        }
        [HttpPost]
        [Route("EditEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> EditEmployees(int id, EmployeeModel employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }                        
             
            var EmployeeData = await _context.Employees.FindAsync(id);
            if (EmployeeData == null)
            {
                return NotFound();
            }      
                                     
            EmployeeData.FirstName = employee.FirstName;
            EmployeeData.LastName = employee.LastName;
            EmployeeData.Gender = employee.Gender;
            EmployeeData.Address = employee.Address;
            EmployeeData.PhoneNumber = employee.PhoneNumber;
            EmployeeData.MobileNumber = employee.MobileNumber;
            EmployeeData.DeptID = employee.DeptID;
            await _context.SaveChangesAsync();
            return await _context.Employees.ToListAsync();

        }
        //public async Task<ActionResult<IEnumerable<EmployeeModel>>> EditEmployees(int id, EmployeeModel emp)
        //{
        //    return Ok(_Db.EditEmployees(id, emp));
        //}
                                                
        [HttpPost]
        [Route("DeleteEmployeeDtls")]
        public async Task<IActionResult> DeleteEmployeeDtls(int id)
        {
            return Ok(_Db.DeleteEmployeeDtls(id));
        }

        [HttpGet]
        [Route("GetEmployeeForSearch/{searchBy}/{searchTxt}")]
        public async Task<IActionResult> GetEmployeeForSearch(string searchBy, string searchTxt)
        {
            return Ok(await _Db.GetEmployeeForSearch(searchBy, searchTxt));
        }

        [HttpGet]
        [Route("GetDrpDwnList")]
        public DepartmentsModel[] GetDrpDwnList()
        {
            try
            {
                var deptList = _context.Department.ToList();  
                return deptList.ToArray();
            }
            catch
            {

            }
            return null;
        }
                          
    }
}
