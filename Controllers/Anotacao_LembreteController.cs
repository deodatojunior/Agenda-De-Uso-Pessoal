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
    public class Anotacao_LembreteController : Controller
    {
        private readonly Context _context;

        public Anotacao_LembreteController(Context context)
        {
            _context = context;
        }

        // GET: Anotacao_Lembrete
        public async Task<IActionResult> Index()
        {
            var context = _context.Anotacao_Lembrete.Include(a => a.lembrete);
            return View(await context.ToListAsync());
        }

        // GET: Anotacao_Lembrete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao_Lembrete = await _context.Anotacao_Lembrete
                .Include(a => a.lembrete)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anotacao_Lembrete == null)
            {
                return NotFound();
            }

            return View(anotacao_Lembrete);
        }

        // GET: Anotacao_Lembrete/Create
        public IActionResult Create()
        {
            ViewData["lembreteId"] = new SelectList(_context.Lembretes, "id", "id");
            return View();
        }

        // POST: Anotacao_Lembrete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,lembreteId")] Anotacao_Lembrete anotacao_Lembrete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anotacao_Lembrete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["lembreteId"] = new SelectList(_context.Lembretes, "id", "id", anotacao_Lembrete.lembreteId);
            return View(anotacao_Lembrete);
        }

        // GET: Anotacao_Lembrete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao_Lembrete = await _context.Anotacao_Lembrete.FindAsync(id);
            if (anotacao_Lembrete == null)
            {
                return NotFound();
            }
            ViewData["lembreteId"] = new SelectList(_context.Lembretes, "id", "id", anotacao_Lembrete.lembreteId);
            return View(anotacao_Lembrete);
        }

        // POST: Anotacao_Lembrete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,lembreteId")] Anotacao_Lembrete anotacao_Lembrete)
        {
            if (id != anotacao_Lembrete.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anotacao_Lembrete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Anotacao_LembreteExists(anotacao_Lembrete.id))
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
            ViewData["lembreteId"] = new SelectList(_context.Lembretes, "id", "id", anotacao_Lembrete.lembreteId);
            return View(anotacao_Lembrete);
        }

        // GET: Anotacao_Lembrete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao_Lembrete = await _context.Anotacao_Lembrete
                .Include(a => a.lembrete)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anotacao_Lembrete == null)
            {
                return NotFound();
            }

            return View(anotacao_Lembrete);
        }

        // POST: Anotacao_Lembrete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anotacao_Lembrete = await _context.Anotacao_Lembrete.FindAsync(id);
            _context.Anotacao_Lembrete.Remove(anotacao_Lembrete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Anotacao_LembreteExists(int id)
        {
            return _context.Anotacao_Lembrete.Any(e => e.id == id);
        }
    }
}
