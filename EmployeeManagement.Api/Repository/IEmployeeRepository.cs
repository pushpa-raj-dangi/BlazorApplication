using EmployeeManagement.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> SearchEmplpyees(string search, Gender? gender);
        Task<IEnumerable<Employee>> GetEmplpyees();
        Task<Employee> GetEmplpyee(int employeedId);
        Task<Employee> GetEmplpyeeByEmail(string email);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeedId);

    }
}
