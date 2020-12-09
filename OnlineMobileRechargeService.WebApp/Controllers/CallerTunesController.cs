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
    public class CallerTunesController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public CallerTunesController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/CallerTunes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallerTune>>> GetCallerTunes()
        {
            return await _context.CallerTunes.ToListAsync();
        }

        // GET: api/CallerTunes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CallerTune>> GetCallerTune(int id)
        {
            var callerTune = await _context.CallerTunes.FindAsync(id);

            if (callerTune == null)
            {
                return NotFound();
            }

            return callerTune;
        }

        // PUT: api/CallerTunes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCallerTune(int id, CallerTune callerTune)
        {
            if (id != callerTune.Id)
            {
                return BadRequest();
            }

            _context.Entry(callerTune).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallerTuneExists(id))
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

        // POST: api/CallerTunes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CallerTune>> PostCallerTune(CallerTune callerTune)
        {
            _context.CallerTunes.Add(callerTune);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCallerTune", new { id = callerTune.Id }, callerTune);
        }

        // DELETE: api/CallerTunes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCallerTune(int id)
        {
            var callerTune = await _context.CallerTunes.FindAsync(id);
            if (callerTune == null)
            {
                return NotFound();
            }

            _context.CallerTunes.Remove(callerTune);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CallerTuneExists(int id)
        {
            return _context.CallerTunes.Any(e => e.Id == id);
        }
    }
}
