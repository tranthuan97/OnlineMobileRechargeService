﻿using System;
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
    public class DNDCategoriesController : ControllerBase
    {
        private readonly OMRSDbContext _context;

        public DNDCategoriesController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: api/DNDCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DNDCategory>>> GetDNDCategories()
        {
            return await _context.DNDCategories.ToListAsync();
        }

        // GET: api/DNDCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DNDCategory>> GetDNDCategory(int id)
        {
            var dNDCategory = await _context.DNDCategories.FindAsync(id);

            if (dNDCategory == null)
            {
                return NotFound();
            }

            return dNDCategory;
        }

        // PUT: api/DNDCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDNDCategory(int id, DNDCategory dNDCategory)
        {
            if (id != dNDCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(dNDCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNDCategoryExists(id))
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

        // POST: api/DNDCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DNDCategory>> PostDNDCategory(DNDCategory dNDCategory)
        {
            _context.DNDCategories.Add(dNDCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDNDCategory", new { id = dNDCategory.Id }, dNDCategory);
        }

        // DELETE: api/DNDCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDNDCategory(int id)
        {
            var dNDCategory = await _context.DNDCategories.FindAsync(id);
            if (dNDCategory == null)
            {
                return NotFound();
            }

            _context.DNDCategories.Remove(dNDCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DNDCategoryExists(int id)
        {
            return _context.DNDCategories.Any(e => e.Id == id);
        }
    }
}
