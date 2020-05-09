using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel : Employee
    {

        [Required(ErrorMessage = "Confirm Email is mandatory.")]
        [EmailAddress]
        [CompareProperty("Email", ErrorMessage = "Email and Confirm Email must match.")]
        public string ConfirmEmail { get; set; }

        [ValidateComplexType]
        public Department Department { get; set; } = new Department();

        public int DepartmentId { get; set; }



    }
}
