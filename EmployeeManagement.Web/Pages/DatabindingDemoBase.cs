using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DatabindingDemoBase  : ComponentBase
    {
        public string Name { get; set; } = "Emilio Barrera";
        public string Gender { get; set; } = "Male";
        public string Colour { get; set; } = "background-color:red";
        public string Description { get; set; } = string.Empty;
    }
}
