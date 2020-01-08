﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaaClub.Data;
using GaaClub.Models;

namespace GaaClub.Controllers
{
    public class FeeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FeeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeeTypes.ToListAsync());
        }

        // GET: FeeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes
                .FirstOrDefaultAsync(m => m.FeeID == id);
            if (feeType == null)
            {
                return NotFound();
            }

            return View(feeType);
        }

        // GET: FeeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeID,Type,Description,FeeCost")] FeeType feeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feeType);
        }

        // GET: FeeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes.FindAsync(id);
            if (feeType == null)
            {
                return NotFound();
            }
            return View(feeType);
        }

        // POST: FeeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeeID,Type,Description,FeeCost")] FeeType feeType)
        {
            if (id != feeType.FeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeTypeExists(feeType.FeeID))
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
            return View(feeType);
        }

        // GET: FeeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes
                .FirstOrDefaultAsync(m => m.FeeID == id);
            if (feeType == null)
            {
                return NotFound();
            }

            return View(feeType);
        }

        // POST: FeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeType = await _context.FeeTypes.FindAsync(id);
            _context.FeeTypes.Remove(feeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeTypeExists(int id)
        {
            return _context.FeeTypes.Any(e => e.FeeID == id);
        }
    }
}
