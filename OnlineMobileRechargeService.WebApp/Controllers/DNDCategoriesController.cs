using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeService.Data.EF;
using OnlineMobileRechargeService.Data.Entities;

namespace OnlineMobileRechargeService.WebApp.Controllers
{
    public class DNDCategoriesController : Controller
    {
        private readonly OMRSDbContext _context;

        public DNDCategoriesController(OMRSDbContext context)
        {
            _context = context;
        }

        // GET: DNDCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.DNDCategories.ToListAsync());
        }

        // GET: DNDCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dNDCategory = await _context.DNDCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dNDCategory == null)
            {
                return NotFound();
            }

            return View(dNDCategory);
        }

        // GET: DNDCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DNDCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Status")] DNDCategory dNDCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dNDCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dNDCategory);
        }

        // GET: DNDCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dNDCategory = await _context.DNDCategories.FindAsync(id);
            if (dNDCategory == null)
            {
                return NotFound();
            }
            return View(dNDCategory);
        }

        // POST: DNDCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Status")] DNDCategory dNDCategory)
        {
            if (id != dNDCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dNDCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DNDCategoryExists(dNDCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dNDCategory);
        }

        // GET: DNDCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dNDCategory = await _context.DNDCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dNDCategory == null)
            {
                return NotFound();
            }

            return View(dNDCategory);
        }

        // POST: DNDCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dNDCategory = await _context.DNDCategories.FindAsync(id);
            _context.DNDCategories.Remove(dNDCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DNDCategoryExists(int id)
        {
            return _context.DNDCategories.Any(e => e.Id == id);
        }
    }
}
