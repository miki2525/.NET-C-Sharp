using Microsoft.EntityFrameworkCore;
using Employees.DB;
using Employees.Model;
using Employees.Model.type;
using System.Text.Json;
using Employees.utils;

namespace Employees.Service
{
    public class EmployeeServiceImpl : EmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeServiceImpl(EmployeeContext context)
        {
            _context = context;
        }


        public async Task<List<Object>> GetAllEmployees(bool sort)
        {

            List<Employee> listEmpl = (List<Employee>)await GetAllEmployess();
            if (listEmpl == null)
            {
                return null;
            }

            if (sort)
            {
                listEmpl = sortList(listEmpl);
            }

            List<Object> listObj = listEmpl.ConvertAll(e => (Object)e);
            return listObj;
        }

        public async Task<object> AddEmployee(Object rawEmployee)
        {
            String typeOfObj = "";
            JsonElement jsonElement = (JsonElement)rawEmployee;
            String json = jsonElement.GetRawText();
            Employee employee = TypeProspector.ConvertJSONtoEmployee(json);

            if (employee is OfficeEmployee)
            {
                _context.OfficeEmployees.Add((OfficeEmployee)employee);
                await _context.SaveChangesAsync();
                return (OfficeEmployee)employee;
            }
            else if (employee is Trader)
            {
                _context.Traders.Add((Trader)employee);
                await _context.SaveChangesAsync();
                return (Trader)employee;
            }
            else if (employee is Workman)
            {
                _context.Workmen.Add((Workman)employee);
                await _context.SaveChangesAsync();
                return (Workman)employee;
            }
            else
            {
                return null;
            }

        }


        public async Task<List<object>> AddEmployees(ListEmployees employees)
        {
            List<Object> list = new List<Object>();
            if (employees.OfficeEmployees != null)
            {
                _context.OfficeEmployees.AddRange(employees.OfficeEmployees);
            }
            if (employees.Traders != null)
            {
                _context.Traders.AddRange(employees.Traders);
            }
            if (employees.Workmen != null)
            {
                _context.Workmen.AddRange(employees.Workmen);
            }
            await _context.SaveChangesAsync();
            list.Add(employees.OfficeEmployees.ToList().ConvertAll(e => (Object)e));
            list.Add(employees.Traders.ToList().ConvertAll(e => (Object)e));
            list.Add(employees.Workmen.ToList().ConvertAll(e => (Object)e));
            return list;
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {

            if (_context.AllEmployees == null)
            {
                return false;
            }
            var employee = await _context.AllEmployees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.AllEmployees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Object>> GetEmployeesByCity(string city)
        {
            List<Employee> listEmpl = _context.AllEmployees.Where(e => e.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            if (listEmpl == null)
            {
                return null;
            }
            List<Object> listObj = listEmpl.ConvertAll(e => (Object)e);
            return listObj;
        }

        private async Task<IEnumerable<Employee>> GetAllEmployess()
        {
            if (_context.AllEmployees == null)
            {
                return null;
            }
            return await _context.AllEmployees.ToListAsync();
        }

        //po liczbie lat doświadczenia (malejąco), następnie po wieku pracownika (rosnąco), następnie po nazwisku pracownika (zgodnie z kolejnością alfabetyczną)
        private List<Employee> sortList(List<Employee> listToSort)
        {
            return listToSort.OrderByDescending(e => e.Experience).ThenBy(e => e.Age).ThenBy(e => e.LastName).ToList();

        }


    }
    /*        public async Task<List<Object>> AddEmployees(List<Object> employees)
        {
            List<Object> list = new List<Object>();
            foreach (Object obj in employees)
            {
                String typeOfObj = "";
                JsonElement rawEmpl = (JsonElement)obj;
                String json = rawEmpl.GetRawText();
                Employee employee = TypeProspector.ConvertJSONtoEmployee(json);
                if (employee is OfficeEmployee)
                {
                    OfficeEmployee officeEmployee = employee as OfficeEmployee;
                    officeEmployee.setEmployeeValue();
                    _context.OfficeEmployees.Add(officeEmployee);
                    await _context.SaveChangesAsync();
                    list.Add(officeEmployee);
                }
                else if (employee is Workman)
                {
                    Workman workman = employee as Workman;
                    workman.setEmployeeValue();
                    _context.Workmen.Add(workman);
                    await _context.SaveChangesAsync();
                    list.Add(workman);
                }
                else if (employee is Trader)
                {
                    Trader trader = employee as Trader;
                    trader.setEmployeeValue();
                    _context.Traders.Add(trader);
                    await _context.SaveChangesAsync();
                    list.Add(trader);
                }
            }
            return list;

        }*/
}
