using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repository
{
    public class DepartmentRespository : IDepartmentRespository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRespository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _appDbContext.Departments.ToList();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _appDbContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        }
    }
}
