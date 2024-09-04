using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repository.Interface;
using EmployeeAdminPortal.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepo) 
        {
            this.employeeRepository = employeeRepo;
        }
        [HttpGet]
        public async Task< IActionResult> GetAllEmployees()
        {
            var allEmployees = await employeeRepository.GetAllEmployees();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employee)
        {
            var employeeResponseDto = await employeeRepository.AddEmployee(employee);
            return Ok(employeeResponseDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeDto updateEmployeeDto)
        {
            var employee = employeeRepository.UpdateEmployee(id, updateEmployeeDto);
            if (employee.Result != null)
            {
                return Ok(employee.Result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult>DeleteEmployee(Guid id)
        {
            var employee = employeeRepository.DeleteEmployeeById(id);
            if (employee.Result != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
