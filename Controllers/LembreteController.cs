using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Database;
using ProjetoIntegrador.Models;

namespace ProjetoIntegrador.Controllers
{
    public class LembreteController : Controller
    {
        private readonly Context _context;

        public LembreteController(Context context)
        {
            _context = context;
        }

        // GET: Lembrete
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lembretes.ToListAsync());
        }

        // GET: Lembrete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes
                .FirstOrDefaultAsync(m => m.id == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // GET: Lembrete/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lembrete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,data,texto")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lembrete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lembrete);
        }

        // GET: Lembrete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete == null)
            {
                return NotFound();
            }
            return View(lembrete);
        }

        // POST: Lembrete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,data,texto")] Lembrete lembrete)
        {
            if (id != lembrete.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lembrete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LembreteExists(lembrete.id))
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
            return View(lembrete);
        }

        // GET: Lembrete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes
                .FirstOrDefaultAsync(m => m.id == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // POST: Lembrete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lembrete = await _context.Lembretes.FindAsync(id);
            _context.Lembretes.Remove(lembrete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LembreteExists(int id)
        {
            return _context.Lembretes.Any(e => e.id == id);
        }
    }
}
