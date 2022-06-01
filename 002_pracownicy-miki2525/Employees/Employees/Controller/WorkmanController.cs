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
    public class WorkmanController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public WorkmanController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Workman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workman>>> GetWorkmen()
        {
          if (_context.Workmen == null)
          {
              return NotFound();
          }
            return await _context.Workmen.ToListAsync();
        }

        // GET: api/Workman/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workman>> GetWorkman(int id)
        {
          if (_context.Workmen == null)
          {
              return NotFound();
          }
            var workman = await _context.Workmen.FindAsync(id);

            if (workman == null)
            {
                return NotFound();
            }

            return workman;
        }

        // POST: api/Workman
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(Summary = "Add Workman")]
        [HttpPost]
        public async Task<ActionResult<Workman>> PostWorkman(Workman workman)
        {
          if (_context.Workmen == null)
          {
              return Problem("Entity set 'EmployeeContext.Workmen'  is null.");
          }
            _context.Workmen.Add(workman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkman", new { id = workman.Id }, workman);
        }

        // DELETE: api/Workman/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkman(int id)
        {
            if (_context.Workmen == null)
            {
                return NotFound();
            }
            var workman = await _context.Workmen.FindAsync(id);
            if (workman == null)
            {
                return NotFound();
            }

            _context.Workmen.Remove(workman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkmanExists(int id)
        {
            return (_context.Workmen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
