using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {


        [Inject]
        public IEmployeeService EmployeeService { get; set; }


        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected int SelectedEmployeeCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            //await Task.Run(LoadEmployees);
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
        }
        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
        }

        protected void EmployeeSelectionChange(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeeCount++;
            }
            else
            {
                SelectedEmployeeCount--;
            }
        }


        private void LoadEmployees()
        {

            System.Threading.Thread.Sleep(3000);

            Employee employee1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Emilio",
                LastName = "Barrera",
                Email = "emilio@gmail.com",
                DateOfBirth = new DateTime(1975, 04, 09),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png",
            };

            Employee employee2 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "emilio@gmail.com",
                DateOfBirth = new DateTime(1985, 04, 25),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/sam.jpg",
            };

            Employee employee3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBirth = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/mary.png"
            };

            Employee employee4 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBirth = new DateTime(1978, 09, 12),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> { employee1, employee2, employee3, employee4 };

        }





    }
}
