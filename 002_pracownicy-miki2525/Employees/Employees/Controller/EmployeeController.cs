using Microsoft.AspNetCore.Mvc;
using Employees.Service;
using Employees.Model.type;
using Swashbuckle.AspNetCore.Annotations;
using Employees.Model;

namespace Employees.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // POST: api/Employees/
        [SwaggerOperation(Summary = "Add employee")]
        [Route("api/[controller]/addEmployee")]
        [HttpPost]
        public async Task<ActionResult<Object>> AddEmployee([SwaggerRequestBody(Description = "{\"firstName\": \"John\", \"lastName\": \"Last\", \"age\": 25,\"experience\": 10,\"streetName\": \"Street\",\"buildNumber\": 5,\"apartmentNumber\": 5,\"city\": \"City\",\"intellect\": 15 }")]
        Object employee)
        {
            Object saved = await _employeeService.AddEmployee(employee);

            if (saved != null)
            {
                return saved;

            }
            return Problem("Can't add employee");
        }

        // POST: api/Employees/
        [SwaggerOperation(Summary = "Add employees")]
        [Route("api/[controller]/addEmployees")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Object>>> AddEmployees([SwaggerRequestBody(Description ="List of Employees")] ListEmployees employees)
        {
            List<Object> list = await _employeeService.AddEmployees(employees);
            
            if (list != null)
            {
                return list;
                
            }
            return Problem("Can't add employees");
        }

        // GET: api/Employees/
        [SwaggerOperation(Summary = "Get AllEmployees")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetAllEmployees()
        {
            List<Object> employees = await _employeeService.GetAllEmployees(false);
            
            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // GET: api/Employees/sorted
        [Route("api/[controller]/sorted")]
        [SwaggerOperation(Summary = "Get AllEmployees sorted by Experience[DESC] -> Age[DESC] -> LastName[aplh]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetAllEmployeesSorted()
        {
            List<Object> employees = await _employeeService.GetAllEmployees(true);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // GET: api/Employees/city
        [SwaggerOperation(Summary = "Find Employees by City")]
        [HttpGet("{city}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetEmployeesByCity([SwaggerParameter(Description = "City")] string city)
        {

            List<Object> employees = await _employeeService.GetEmployeesByCity(city);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }


        // DELETE: api/Employees/5
        [SwaggerOperation(Summary = "Delete emploee by ID")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([SwaggerParameter(Description = "ID")] int id)
        {
            if (await _employeeService.DeleteEmployeeById(id)){
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
