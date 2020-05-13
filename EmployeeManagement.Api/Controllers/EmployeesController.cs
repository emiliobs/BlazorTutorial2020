using EmployeeManagement.Api.Repository;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                IEnumerable<Employee> result = await _employeeRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployee()
        {
            try
            {
                return Ok(await _employeeRepository.GetAllEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                Employee result = await _employeeRepository.GetEmployeeById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

               var existEmployee = await _employeeRepository.GetEmployeeByEmail(employee.Email);

                if (existEmployee != null)
                {
                    ModelState.AddModelError("Email", "Employee email already in use.");
                    return BadRequest(ModelState);
                }
                else
                {
                   

                    var createEmployee = await _employeeRepository.AddEmployee(employee);

                    return CreatedAtAction(nameof(GetEmployeeById), new { id = createEmployee.EmployeeId }, createEmployee);
                }

               

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        //[HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                //if (id != employee.EmployeeId)
                //{
                //    return BadRequest("Employee Id mismatch");
                //}

                Employee employeeUpdate = await _employeeRepository.GetEmployeeById(employee.EmployeeId);

                if (employeeUpdate == null)
                {
                    return NotFound($"Employee wint Id = {employee.EmployeeId} not found.");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Update Data.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                Employee employeeToDelete = await _employeeRepository.GetEmployeeById(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found.");
                }

                return await _employeeRepository.DeleteEmployeeById(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data.");
            }
        }

    }
}
