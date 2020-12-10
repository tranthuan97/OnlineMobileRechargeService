using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimTypesController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public SimTypesController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/SimTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimType>>> GetSimTypes()
        {
            return await _context.SimTypes.ToListAsync();
        }

        // GET: api/SimTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SimType>> GetSimType(int id)
        {
            var simType = await _context.SimTypes.FindAsync(id);

            if (simType == null)
            {
                return NotFound();
            }

            return simType;
        }

        // PUT: api/SimTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSimType(int id, SimType simType)
        {
            if (id != simType.Id)
            {
                return BadRequest();
            }

            _context.Entry(simType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SimTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SimType>> PostSimType(SimType simType)
        {
            _context.SimTypes.Add(simType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSimType", new { id = simType.Id }, simType);
        }

        // DELETE: api/SimTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSimType(int id)
        {
            var simType = await _context.SimTypes.FindAsync(id);
            if (simType == null)
            {
                return NotFound();
            }

            _context.SimTypes.Remove(simType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SimTypeExists(int id)
        {
            return _context.SimTypes.Any(e => e.Id == id);
        }
    }
}
