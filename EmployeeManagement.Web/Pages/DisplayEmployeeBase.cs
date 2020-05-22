using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {


        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }



        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool IsSelected { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }


        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }


        protected async Task CheckBoxChange(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnEmployeeSelection.InvokeAsync(IsSelected);
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
           // NavigationManager.NavigateTo("/", true);
        }

    }
}
