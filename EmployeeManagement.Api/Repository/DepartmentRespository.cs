using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _appDbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await _appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        
    }
}
