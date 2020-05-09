using EmployeeManagement.Models.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "FirstName must be provided")]
        public string LastName { get; set; }

        [EmailDomainValidator(AllowedDomain = "emisoft.com", ErrorMessage = "Only Emisoft.com is allowed.")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        

        public DateTime DateOfBirth{ get; set; }

        public Gender Gender { get; set; }

        
        public Department Department { get; set; } 

        public int DepartmentId { get; set; }

        public string PhotoPath { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        //public Department Department { get; set; }
    }
}
