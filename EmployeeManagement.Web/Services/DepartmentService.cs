using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient client;

        public DepartmentService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await client.GetJsonAsync<Department>($"api/departments/{id}");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await client.GetJsonAsync<Department[]>("api/departments");
        }

       
    }
}
