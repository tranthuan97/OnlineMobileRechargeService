using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeService.Application.ViewModels.Transactions;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PBPTransactionsController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public PBPTransactionsController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/PBPTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PBPTransaction>>> GetPBPTransactions()
        {
            return await _context.PBPTransactions.ToListAsync();
        }

        // GET: api/PBPTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PBPTransaction>> GetPBPTransaction(int id)
        {
            var pBPTransaction = await _context.PBPTransactions.FindAsync(id);

            if (pBPTransaction == null)
            {
                return NotFound();
            }

            return pBPTransaction;
        }

        // PUT: api/PBPTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPBPTransaction(int id, PBPTransaction pBPTransaction)
        {
            if (id != pBPTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(pBPTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PBPTransactionExists(id))
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

        // POST: api/PBPTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PBPTransaction>> PostPBPTransaction([FromBody] PBPRequest request)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            bool regex = Regex.Match(request.PhoneNumber, @"(\+[0-9]{2}|\+[0-9]{2}\(0\)|\(\+[0-9]{2}\)\(0\)|00[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})").Success;

            if (regex == false)
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Phone number must be a number and at lest 9 characters !");

                return BadRequest(data);
            }

            PBPTransaction pBPTransaction = new PBPTransaction
            {
                CreatedDate = DateTime.Now,
                PhoneNumber = Int32.Parse(request.PhoneNumber),
                Price = Int32.Parse(request.Price),
            };

            _context.PBPTransactions.Add(pBPTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPBPTransaction", new { id = pBPTransaction.Id }, pBPTransaction);
        }

        // DELETE: api/PBPTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePBPTransaction(int id)
        {
            var pBPTransaction = await _context.PBPTransactions.FindAsync(id);
            if (pBPTransaction == null)
            {
                return NotFound();
            }

            _context.PBPTransactions.Remove(pBPTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PBPTransactionExists(int id)
        {
            return _context.PBPTransactions.Any(e => e.Id == id);
        }
    }
}
