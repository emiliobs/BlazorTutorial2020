using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Repository;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRespository _departmentRespository;

        public DepartmentsController(IDepartmentRespository departmentRespository)
        {
            this._departmentRespository = departmentRespository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDepartment()
        {
            try
            {
                return Ok(await _departmentRespository.GetAllDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var result = await _departmentRespository.GetDepartmentById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                
            }
        }
    }
}
