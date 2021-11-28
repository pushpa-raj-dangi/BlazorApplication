using EmployeeManagement.Api.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Employee> DeleteEmployee(int employeedId)
        {
            var employee = _context.Employees.Find(employeedId);
            if(employee != null)
            {
            _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            return employee;

            }
            return null;

        }

        public async Task<Employee> GetEmplpyee(int employeedId)
        {
            return await _context.Employees.Include(x=>x.Department).SingleOrDefaultAsync(e => e.EmployeeId == employeedId);
        }

        public async Task<Employee> GetEmplpyeeByEmail(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
    }

        public async Task<IEnumerable<Employee>> GetEmplpyees()
        {
            return await _context.Employees.Include(x=>x.Department).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchEmplpyees(string search, Gender? gender)
        {
            IQueryable<Employee> query = _context.Employees;
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e => e.FirstName == search || e.LastName.Contains(search));
            }

            if(gender != null)
            {
                query = query.Where(a=>a.Gender == gender);
            }
            return await query.ToListAsync();
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
