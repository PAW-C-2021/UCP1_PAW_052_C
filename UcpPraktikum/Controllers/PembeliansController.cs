using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UcpPraktikum.Models;

namespace UcpPraktikum.Controllers
{
    public class PembeliansController : Controller
    {
        private readonly PenjualannnContext _context;

        public PembeliansController(PenjualannnContext context)
        {
            _context = context;
        }

        // GET: Pembelians
        public async Task<IActionResult> Index()
        {
            var penjualannnContext = _context.Pembelian.Include(p => p.IdBarangNavigation).Include(p => p.IdSuplierNavigation);
            return View(await penjualannnContext.ToListAsync());
        }

        // GET: Pembelians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembelian = await _context.Pembelian
                .Include(p => p.IdBarangNavigation)
                .Include(p => p.IdSuplierNavigation)
                .FirstOrDefaultAsync(m => m.IdPembelian == id);
            if (pembelian == null)
            {
                return NotFound();
            }

            return View(pembelian);
        }

        // GET: Pembelians/Create
        public IActionResult Create()
        {
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang");
            ViewData["IdSuplier"] = new SelectList(_context.Suplier, "IdSuplier", "IdSuplier");
            return View();
        }

        // POST: Pembelians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembelian,IdBarang,IdSuplier,Jumlah,TglPembelian")] Pembelian pembelian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembelian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang", pembelian.IdBarang);
            ViewData["IdSuplier"] = new SelectList(_context.Suplier, "IdSuplier", "IdSuplier", pembelian.IdSuplier);
            return View(pembelian);
        }

        // GET: Pembelians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembelian = await _context.Pembelian.FindAsync(id);
            if (pembelian == null)
            {
                return NotFound();
            }
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang", pembelian.IdBarang);
            ViewData["IdSuplier"] = new SelectList(_context.Suplier, "IdSuplier", "IdSuplier", pembelian.IdSuplier);
            return View(pembelian);
        }

        // POST: Pembelians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembelian,IdBarang,IdSuplier,Jumlah,TglPembelian")] Pembelian pembelian)
        {
            if (id != pembelian.IdPembelian)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembelian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembelianExists(pembelian.IdPembelian))
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
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang", pembelian.IdBarang);
            ViewData["IdSuplier"] = new SelectList(_context.Suplier, "IdSuplier", "IdSuplier", pembelian.IdSuplier);
            return View(pembelian);
        }

        // GET: Pembelians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembelian = await _context.Pembelian
                .Include(p => p.IdBarangNavigation)
                .Include(p => p.IdSuplierNavigation)
                .FirstOrDefaultAsync(m => m.IdPembelian == id);
            if (pembelian == null)
            {
                return NotFound();
            }

            return View(pembelian);
        }

        // POST: Pembelians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembelian = await _context.Pembelian.FindAsync(id);
            _context.Pembelian.Remove(pembelian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembelianExists(int id)
        {
            return _context.Pembelian.Any(e => e.IdPembelian == id);
        }
    }
}
