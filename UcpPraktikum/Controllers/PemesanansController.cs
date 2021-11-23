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
    public class PemesanansController : Controller
    {
        private readonly PenjualannnContext _context;

        public PemesanansController(PenjualannnContext context)
        {
            _context = context;
        }

        // GET: Pemesanans
        public async Task<IActionResult> Index()
        {
            var penjualannnContext = _context.Pemesanan.Include(p => p.IdBarangNavigation).Include(p => p.IdPelangganNavigation);
            return View(await penjualannnContext.ToListAsync());
        }

        // GET: Pemesanans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanan
                .Include(p => p.IdBarangNavigation)
                .Include(p => p.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pemesanan == null)
            {
                return NotFound();
            }

            return View(pemesanan);
        }

        // GET: Pemesanans/Create
        public IActionResult Create()
        {
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang");
            ViewData["IdPelanggan"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli");
            return View();
        }

        // POST: Pemesanans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPesanan,IdPelanggan,IdBarang,Jumlah,TglPemesanan")] Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang", pemesanan.IdBarang);
            ViewData["IdPelanggan"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli", pemesanan.IdPelanggan);
            return View(pemesanan);
        }

        // GET: Pemesanans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanan.FindAsync(id);
            if (pemesanan == null)
            {
                return NotFound();
            }
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang", pemesanan.IdBarang);
            ViewData["IdPelanggan"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli", pemesanan.IdPelanggan);
            return View(pemesanan);
        }

        // POST: Pemesanans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPesanan,IdPelanggan,IdBarang,Jumlah,TglPemesanan")] Pemesanan pemesanan)
        {
            if (id != pemesanan.IdPesanan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemesananExists(pemesanan.IdPesanan))
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
            ViewData["IdBarang"] = new SelectList(_context.Barang, "IdBarang", "IdBarang", pemesanan.IdBarang);
            ViewData["IdPelanggan"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli", pemesanan.IdPelanggan);
            return View(pemesanan);
        }

        // GET: Pemesanans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanan
                .Include(p => p.IdBarangNavigation)
                .Include(p => p.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pemesanan == null)
            {
                return NotFound();
            }

            return View(pemesanan);
        }

        // POST: Pemesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pemesanan = await _context.Pemesanan.FindAsync(id);
            _context.Pemesanan.Remove(pemesanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemesananExists(int id)
        {
            return _context.Pemesanan.Any(e => e.IdPesanan == id);
        }
    }
}
