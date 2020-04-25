﻿using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repository
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployeeById(int employeeId);
    }
}
