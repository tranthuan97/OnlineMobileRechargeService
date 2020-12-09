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
    public class DNDTransactionsController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public DNDTransactionsController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/DNDTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DNDTransaction>>> GetDNDTransactions()
        {
            return await _context.DNDTransactions.ToListAsync();
        }

        // GET: api/DNDTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DNDTransaction>> GetDNDTransaction(int id)
        {
            var dNDTransaction = await _context.DNDTransactions.FindAsync(id);

            if (dNDTransaction == null)
            {
                return NotFound();
            }

            return dNDTransaction;
        }

        // PUT: api/DNDTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDNDTransaction(int id, DNDTransaction dNDTransaction)
        {
            if (id != dNDTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(dNDTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNDTransactionExists(id))
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

        // POST: api/DNDTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DNDTransaction>> PostDNDTransaction(DNDTransaction dNDTransaction)
        {
            _context.DNDTransactions.Add(dNDTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDNDTransaction", new { id = dNDTransaction.Id }, dNDTransaction);
        }

        // DELETE: api/DNDTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDNDTransaction(int id)
        {
            var dNDTransaction = await _context.DNDTransactions.FindAsync(id);
            if (dNDTransaction == null)
            {
                return NotFound();
            }

            _context.DNDTransactions.Remove(dNDTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DNDTransactionExists(int id)
        {
            return _context.DNDTransactions.Any(e => e.Id == id);
        }
    }
}
