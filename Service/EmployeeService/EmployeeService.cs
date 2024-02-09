using Employees.API.DataContext;
using Employees.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Employees.API.Service.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                if(newEmployee == null) 
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Sucess = false;
                }
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
            }
            catch(Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não localizado!";
                    serviceResponse.Sucess = false;
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();


            }catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if(employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não localizado!";
                    serviceResponse.Sucess = false; 
                }
                serviceResponse.Data = employee;
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Data = _context.Employees.ToList();
                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não localizado!";
                    serviceResponse.Sucess = false;
                }

                employee.Active = false;
                employee.ChangeDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel updateEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == updateEmployee.Id);

                if (updateEmployee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não localizado!";
                    serviceResponse.Sucess = false;
                }

                employee.ChangeDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(updateEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;

            }

            return serviceResponse;
        }
    }
}
