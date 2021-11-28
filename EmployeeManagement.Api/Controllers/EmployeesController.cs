using EmployeeManagement.Api.Repository;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;

        public EmployeesController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            try
            {
                return Ok(await _employee.GetEmplpyees());
            }
            catch (System.Exception)
            {

             return StatusCode(StatusCodes.Status500InternalServerError,"Error retriving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
               var result =  await _employee.GetEmplpyee(id);
                if(null == result)
                {
                    return NotFound();
                }
                return result;
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                
                if (employee == null)
                {
                    return BadRequest();
                }
                    var emp =  await _employee.GetEmplpyeeByEmail(employee.Email);
                if (emp != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use.");
                    return BadRequest(ModelState);
                }
                var createedEmployee = await _employee.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new {id=createedEmployee.EmployeeId},createedEmployee);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {

                if (employee.EmployeeId != employee.EmployeeId)
                {
                    return BadRequest("Employee id mismatch.");
                }
                
                var empUpdate = await _employee.GetEmplpyee(employee.EmployeeId);
                if (empUpdate == null)
                {
                  
                    return NotFound($"Employee with id = {employee.EmployeeId} not found.");
                }
                var employeeToUpdate = await _employee.GetEmplpyee(employee.EmployeeId);
                if(employeeToUpdate == null)
                {
                    return NotFound($"Employee with id = {employee.EmployeeId} not found.");
                }
                return await _employee.UpdateEmployee(employee);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
             try
            {
                var employeeToDelete = await _employee.GetEmplpyee(id);
                if(employeeToDelete == null)
                {
                    return NotFound($"Employee with id = {id} not found.");
                }

                var employee = await _employee.DeleteEmployee(id);
                return employee;

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }
        }

        [HttpDelete("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee(string search, Gender? gender)
        {
            try
            {
                var employeeToSearch = await _employee.SearchEmplpyees(search,gender);
                if (employeeToSearch.Any())
                {
                    return Ok(employeeToSearch);
                }

                
                return NotFound();

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Serching data.");
            }
        }


    }
}
