using Employees.Model;
using Employees.Model.type;

namespace Employees.Service
{
    public interface EmployeeService
    {
        Task<List<Object>> GetAllEmployees(bool sort);
        Task<bool> DeleteEmployeeById(int id);
        Task<List<Object>> GetEmployeesByCity(string city);
        Task<Object> AddEmployee(Object employee);
        Task<List<Object>> AddEmployees(ListEmployees employees);
    }
}
