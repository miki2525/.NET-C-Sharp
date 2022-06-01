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
    public class TraderController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public TraderController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Trader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trader>>> GetTraders()
        {
          if (_context.Traders == null)
          {
              return NotFound();
          }
            return await _context.Traders.ToListAsync();
        }

        // GET: api/Trader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trader>> GetTrader(int id)
        {
          if (_context.Traders == null)
          {
              return NotFound();
          }
            var trader = await _context.Traders.FindAsync(id);

            if (trader == null)
            {
                return NotFound();
            }

            return trader;
        }

        // POST: api/Trader
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(Summary = "Add Trader")]
        [HttpPost]
        public async Task<ActionResult<Trader>> PostTrader(Trader trader)
        {
          if (_context.Traders == null)
          {
              return Problem("Entity set 'EmployeeContext.Traders'  is null.");
          }
            _context.Traders.Add(trader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrader", new { id = trader.Id }, trader);
        }

        // DELETE: api/Trader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrader(int id)
        {
            if (_context.Traders == null)
            {
                return NotFound();
            }
            var trader = await _context.Traders.FindAsync(id);
            if (trader == null)
            {
                return NotFound();
            }

            _context.Traders.Remove(trader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraderExists(int id)
        {
            return (_context.Traders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
