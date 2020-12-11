﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public TransactionsController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {

            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            //var claim = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase));
            //if (claim == null)
            //{
            //    data.Remove("status");
            //    data.Add("status", "WARNING");
            //    data.Add("message", "Invalid token !");
            //    return Unauthorized(data);    
            //}

            var listTransactions = await _context.Transactions
                .Include(x => x.Provider)
                .Include(x => x.AppUser)
                .Include(x => x.VAS)
                .ToListAsync();
            data.Remove("data");
            data.Add("data", listTransactions);

            return Ok(data);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase));
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);
            if (transaction.PaymentCard.Equals(""))
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Field not null ! !");
                return BadRequest(data);
            }

            transaction.UserId = Int32.Parse(claim.Value);
            transaction.Simtype = "Postpaid";
            transaction.CreatedDate = DateTime.Now;
            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            data.Remove("data");
            data.Add("message", "Add new data is success ! !");
            data.Add("data", transaction);

            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("guest")]
        public async Task<ActionResult<GuestTransaction>> PostGuestTransaction(GuestTransaction transaction)
        {
            Dictionary<string, Object> data = new Dictionary<string, object>();
            data.Add("status", "SUCCESS");
            data.Add("data", null);

            if (transaction.PaymentCard.Equals("")
                || transaction.FirstName.Equals("")
                || transaction.LastName.Equals("")
                || transaction.PhoneNumber.Equals("")
                )
            {
                data.Remove("status");
                data.Add("status", "WARNING");
                data.Add("message", "Field not null ! !");
                return BadRequest(data);
            }

            transaction.CreatedDate = DateTime.Now;
            transaction.Simtype = "Prepay";
            _context.GuestTransactions.Add(transaction);

            await _context.SaveChangesAsync();

            data.Remove("data");
            data.Add("message", "Add new data is success ! !");
            data.Add("data", transaction);

            return Ok(data);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
