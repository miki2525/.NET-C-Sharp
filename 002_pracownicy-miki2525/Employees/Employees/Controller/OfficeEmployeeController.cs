using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employees.DB;
using Employees.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace Employees.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeEmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public OfficeEmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/OfficeEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeEmployee>>> GetOfficeEmployees()
        {
          if (_context.OfficeEmployees == null)
          {
              return NotFound();
          }
            return await _context.OfficeEmployees.ToListAsync();
        }

        // GET: api/OfficeEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeEmployee>> GetOfficeEmployee(int id)
        {
          if (_context.OfficeEmployees == null)
          {
              return NotFound();
          }
            var officeEmployee = await _context.OfficeEmployees.FindAsync(id);

            if (officeEmployee == null)
            {
                return NotFound();
            }

            return officeEmployee;
        }


        // POST: api/OfficeEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(Summary = "Add OfficeEmployee")]
        [HttpPost]
        public async Task<ActionResult<OfficeEmployee>> PostOfficeEmployee(OfficeEmployee officeEmployee)
        {
          if (_context.OfficeEmployees == null)
          {
              return Problem("Entity set 'EmployeeContext.OfficeEmployees'  is null.");
          }
            _context.OfficeEmployees.Add(officeEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeEmployee", new { id = officeEmployee.Id }, officeEmployee);
        }

        // DELETE: api/OfficeEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeEmployee(int id)
        {
            if (_context.OfficeEmployees == null)
            {
                return NotFound();
            }
            var officeEmployee = await _context.OfficeEmployees.FindAsync(id);
            if (officeEmployee == null)
            {
                return NotFound();
            }

            _context.OfficeEmployees.Remove(officeEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeEmployeeExists(int id)
        {
            return (_context.OfficeEmployees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
