using EmployeeDetails.API.Data;
using EmployeeDetails.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {        
        private readonly ApplicationDbContext _Db;
        public EmployeeRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
           
        public async Task<List<EmployeeModel>> GetAllEmployeeList()
        {
            var EmpList = _Db.Employees.Include(d => d.Department).ToList();
            return EmpList;
        }
                                       
        public async Task<EmployeeModel> GetEmployeeDtlsByID(int id)
        {
            try
            {
                EmployeeModel Emp = _Db.Employees.Where(a => a.ID == id).SingleOrDefault();
                var temp = _Db.Employees.Find(id);

                return new EmployeeModel
                {
                    ID = temp.ID,
                    FirstName = temp.FirstName,
                    LastName = temp.LastName,
                    Gender = temp.Gender,
                    Address = temp.Address,
                    PhoneNumber = temp.PhoneNumber,
                    MobileNumber = temp.MobileNumber,
                    DeptID = temp.DeptID
                };
            }                    
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResultDto> AddEmployees(EmployeeModel emp)
        {
            try
            {
                _Db.Employees.Add(emp);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return new ResultDto()
            {
                Result = true,
                ResultMessage = "Success",
                Status = HttpStatusCode.OK
            };
        }
                           
        public async Task<ResultDto> EditEmployees(EmployeeModel emp)
        {
            try
            {
                _Db.Entry(emp).State = EntityState.Modified;
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return new ResultDto()
            {
                Result = true,
                ResultMessage = "Success",
                Status = HttpStatusCode.OK
            };              
        }

        public async Task<ResultDto> DeleteEmployeeDtls(int id)
        {
            try
            {
                var emp = _Db.Employees.Find(id);
                if (emp != null)
                {
                    _Db.Employees.Remove(emp);
                    _Db.SaveChanges();
                }
                return new ResultDto()
                {
                    Result = true,
                    ResultMessage = "Successful",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {    
                   
                throw;
            }
        }
       
        public async Task<List<EmployeeModel>> GetEmployeeForSearch(string searchBy, string searchTxt)
        {
            if (searchBy == "Firstname")
            {
                return (_Db.Employees.Where(x => x.FirstName.StartsWith(searchTxt) || searchTxt == null).ToList());
            }
            else          
            {
                return (_Db.Employees.Where(x => x.LastName.StartsWith(searchTxt) || searchTxt == null).ToList());
            }
        }

        //public async Task<DepartmentsModel> GetDrpDwnList()
        //{
        //    var DropDownList = _Db.Department.ToList();
        //    return DropDownList.ToArray();
        //}
    }
}
