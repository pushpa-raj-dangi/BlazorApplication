using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
           await Task.Run(LoadEmployees);
           
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);
        
        Employees = new List<Employee> { 
                new Employee 
                { 
                    EmployeeId=1, 
                    FirstName="Ram",
                    DateOfBirth = DateTime.Now,
                    Email = "ram@gmail.com",
                    Gender = Gender.Male,
                    LastName = "Khatri",
                    DepartmentId= 3,
                    Photo = "images/two.png"
                },
                new Employee
                {
                    EmployeeId=2,
                    FirstName="Hari",
                    DateOfBirth = DateTime.Now,
                    Email = "hari@gmail.com",
                    Gender = Gender.Male,
                    LastName = "Khanal",
                    DepartmentId= 2,
                    Photo = "images/one.png"
                },
                new Employee
                {
                    EmployeeId=3,
                    FirstName="Chhori",
                    DateOfBirth = DateTime.Now,
                    Email = "chhori@gmail.com",
                    Gender = Gender.Female,
                    LastName = "Budhathoki",
                    DepartmentId= 5,
                    Photo = "images/three.png"
                },
                 new Employee
                {
                    EmployeeId=4,
                    FirstName="Rita",
                    DateOfBirth = DateTime.Now,
                    Email = "rita@gmail.com",
                    Gender = Gender.Female,
                    LastName = "Adhikari",
                    DepartmentId=1,
                    Photo = "images/four.png"
                }
            };
            
        }
    }
}
