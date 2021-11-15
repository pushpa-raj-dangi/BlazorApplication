using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repository
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetEmplpyees();
        Task<Employee> GetEmplpyee(int employeedId);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> AddEmployee(Employee employee);
        void DeleteEmployee(int employeedId);

    }
}
