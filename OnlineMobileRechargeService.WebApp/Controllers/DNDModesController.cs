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
    public class DNDModesController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public DNDModesController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/DNDModes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DNDMode>>> GetDNDModes()
        {
            return await _context.DNDModes.ToListAsync();
        }

        // GET: api/DNDModes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DNDMode>> GetDNDMode(int id)
        {
            var dNDMode = await _context.DNDModes.FindAsync(id);

            if (dNDMode == null)
            {
                return NotFound();
            }

            return dNDMode;
        }

        // PUT: api/DNDModes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDNDMode(int id, DNDMode dNDMode)
        {
            if (id != dNDMode.Id)
            {
                return BadRequest();
            }

            _context.Entry(dNDMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNDModeExists(id))
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

        // POST: api/DNDModes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DNDMode>> PostDNDMode(DNDMode dNDMode)
        {
            _context.DNDModes.Add(dNDMode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDNDMode", new { id = dNDMode.Id }, dNDMode);
        }

        // DELETE: api/DNDModes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDNDMode(int id)
        {
            var dNDMode = await _context.DNDModes.FindAsync(id);
            if (dNDMode == null)
            {
                return NotFound();
            }

            _context.DNDModes.Remove(dNDMode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DNDModeExists(int id)
        {
            return _context.DNDModes.Any(e => e.Id == id);
        }
    }
}
