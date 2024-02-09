using Employees.API.Models;

namespace Employees.API.Service.EmployeeService
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployees();
        Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee);
        Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id);
        Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel updateModel);
        Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id);
        Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id);
    }
}
