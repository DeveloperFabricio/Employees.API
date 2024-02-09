using Employees.API.Models;
using Employees.API.Service.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.GetEmployeeById(id);  

            return Ok(serviceResponse);
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee(EmployeeModel newEmplooyee)
        {
            return Ok(await _employeeInterface.CreateEmployee(newEmplooyee)); 
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> UpdateEmployee(EmployeeModel updateEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.UpdateEmployee(updateEmployee); 

            return Ok(serviceResponse);
        }

        [HttpPut("inactiveEmployee")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.InactiveEmployee(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.DeleteEmployee(id);

            return Ok(serviceResponse);
        }





    }
}
