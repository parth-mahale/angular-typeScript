using EmployeeDetails.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<EmployeeModel>> GetAllEmployeeList();
        public Task<EmployeeModel> GetEmployeeDtlsByID(int id);
        public Task<ResultDto> AddEmployees(EmployeeModel emp);
        public Task<ResultDto> EditEmployees(EmployeeModel emp); 
        public Task<ResultDto> DeleteEmployeeDtls(int id);
        public Task<List<EmployeeModel>> GetEmployeeForSearch(string searchBy, string searchTxt);
        //public Task<DepartmentsModel> GetDrpDwnList();
       
    }
}
