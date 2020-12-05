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
    public class VASController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public VASController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/VAS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VAS>>> GetVAS()
        {
            return await _context.VAS.ToListAsync();
        }

        // GET: api/VAS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VAS>> GetVAS(int id)
        {
            var vAS = await _context.VAS.FindAsync(id);

            if (vAS == null)
            {
                return NotFound();
            }

            return vAS;
        }

        // PUT: api/VAS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVAS(int id, VAS vAS)
        {
            if (id != vAS.Id)
            {
                return BadRequest();
            }

            _context.Entry(vAS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VASExists(id))
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

        // POST: api/VAS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VAS>> PostVAS(VAS vAS)
        {
            _context.VAS.Add(vAS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVAS", new { id = vAS.Id }, vAS);
        }

        // DELETE: api/VAS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVAS(int id)
        {
            var vAS = await _context.VAS.FindAsync(id);
            if (vAS == null)
            {
                return NotFound();
            }

            _context.VAS.Remove(vAS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VASExists(int id)
        {
            return _context.VAS.Any(e => e.Id == id);
        }
    }
}
