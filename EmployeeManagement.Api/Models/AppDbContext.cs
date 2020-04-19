using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Department Table
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Admin" });

            //Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Emilio",
                LastName = "Barrera",
                Email = "emilio@gmail.com",
                DateOfBirth = new DateTime(1975,04,09),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png",
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Mary",
                LastName = "Torrez",
                Email = "mary@gmail.com",
                DateOfBirth = new DateTime(1985, 04, 09),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/mary.png",
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Sam",
                LastName = "Botero",
                Email = "sam@gmail.com",
                DateOfBirth = new DateTime(2000, 04, 09),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/sam.png",
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Linda",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1995, 04, 09),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/sara.png",
            });

        }
    }
}
