using EmployeeManagement.Api.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repository
{
    public class EmployeeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
           var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployee(int employeedId)
        {
            var employee = _context.Employees.Find(employeedId);
            if(employee != null)
            {
            _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

            }

        }

        public async Task<Employee> GetEmplpyee(int employeedId)
        {
            return await _context.Employees.FindAsync(employeedId);
        }

        public async Task<IEnumerable<Employee>> GetEmplpyees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e=>e.EmployeeId == employee.EmployeeId);
            if(result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.Photo = employee.Photo;
                result.DepartmentId = employee.DepartmentId;
                result.DateOfBirth = employee.DateOfBirth;
                await _context.SaveChangesAsync();
                return result;

            }

            return null;
        }
    }
}
