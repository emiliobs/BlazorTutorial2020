﻿using EmployeeManagement.Models;
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
        
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _httpClient.GetJsonAsync<Employee[]>("api/employees");
        }
    }
}
