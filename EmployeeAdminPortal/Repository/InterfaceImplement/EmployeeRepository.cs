using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repository.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBcontext context;

        public EmployeeRepository(ApplicationDBcontext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await context.Employees.ToListAsync();
            
        }
        public async Task<EmployeeResponseDto> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                salary = employeeDto.salary
            };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            var employeeResponse = new EmployeeResponseDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                salary = employee.salary
            };

            return employeeResponse;
        }
        public async Task<EmployeeResponseDto> UpdateEmployee(Guid id, EmployeeDto updateEmployeeDto)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return null;
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.salary = updateEmployeeDto.salary;

            context.SaveChanges();

            var employeeResponse = new EmployeeResponseDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                salary = employee.salary
            };

            return employeeResponse;
        }

        public async Task<EmployeeResponseDto> GetEmployeeById(Guid id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return null;
            }

            var employeeResponse = new EmployeeResponseDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                salary = employee.salary
            };

            return employeeResponse;
        }

        public async Task<EmployeeResponseDto> DeleteEmployeeById(Guid id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return null;
            }

            var employeeResponse = new EmployeeResponseDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                salary = employee.salary
            };

            context.Employees.Remove(employee);
            context.SaveChanges();

            return employeeResponse;
        }

    }
}
