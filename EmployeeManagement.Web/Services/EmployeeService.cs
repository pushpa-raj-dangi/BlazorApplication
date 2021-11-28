using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient client;

        public EmployeeService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await client.PostJsonAsync<Employee>("api/employees", employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await client.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await client.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await client.GetJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee updateEmployee)
        {
            return await client.PutJsonAsync<Employee>("api/employees", updateEmployee);
        }
    }
}
