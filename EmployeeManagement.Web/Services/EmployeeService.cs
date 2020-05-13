using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            return await _httpClient.PostJsonAsync<Employee>("api/employees", newEmployee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _httpClient.GetJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee editEmployee)
        {
            return await _httpClient.PutJsonAsync<Employee>("api/employees",editEmployee);
        }
    }
}
