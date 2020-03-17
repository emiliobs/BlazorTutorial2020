using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase  : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override Task OnInitializedAsync()
        {

            LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {

            var employee1 = new Employee 
            {
                EmployeeId = 1,
                FirstName = "Emilio",
                LastName = "Barrera",
                Email = "emilio@gmail.com",
                DateOfBirth = new DateTime(1975,04,09),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 1, DepartmentName = "IT", },
                PhotoPath = "images/john.png",
            };

            var employee2 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "emilio@gmail.com",
                DateOfBirth = new DateTime(1985,04,25),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 1, DepartmentName = "HR", },
                PhotoPath = "images/sam.jpg",
            };

            var employee3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBirth = new DateTime( 1979, 11, 11),
                Gender = Gender.Female,
                Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/mary.png"
            };

            var employee4 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBirth = new DateTime(1978,09, 12),
                Gender = Gender.Female,
                Department = new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> {employee1,employee2,employee3,employee4 };

        }

    }
}
