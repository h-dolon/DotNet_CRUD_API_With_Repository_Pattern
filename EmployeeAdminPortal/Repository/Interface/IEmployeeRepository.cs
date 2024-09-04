using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<EmployeeResponseDto> AddEmployee(EmployeeDto employee);
        Task<EmployeeResponseDto> UpdateEmployee(Guid id, EmployeeDto updateEmployeeDto);
        Task<EmployeeResponseDto> GetEmployeeById(Guid id);
        Task<EmployeeResponseDto> DeleteEmployeeById(Guid id);
    }
}
