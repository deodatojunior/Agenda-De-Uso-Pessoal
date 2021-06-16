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
    public class Anotacao_EventoController : Controller
    {
        private readonly Context _context;

        public Anotacao_EventoController(Context context)
        {
            _context = context;
        }

        // GET: Anotacao_Evento
        public async Task<IActionResult> Index()
        {
            var context = _context.Anotacao_Evento.Include(a => a.evento);
            return View(await context.ToListAsync());
        }

        // GET: Anotacao_Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao_Evento = await _context.Anotacao_Evento
                .Include(a => a.evento)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anotacao_Evento == null)
            {
                return NotFound();
            }

            return View(anotacao_Evento);
        }

        // GET: Anotacao_Evento/Create
        public IActionResult Create()
        {
            ViewData["eventoId"] = new SelectList(_context.Eventos, "id", "id");
            return View();
        }

        // POST: Anotacao_Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,eventoId")] Anotacao_Evento anotacao_Evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anotacao_Evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eventoId"] = new SelectList(_context.Eventos, "id", "id", anotacao_Evento.eventoId);
            return View(anotacao_Evento);
        }

        // GET: Anotacao_Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao_Evento = await _context.Anotacao_Evento.FindAsync(id);
            if (anotacao_Evento == null)
            {
                return NotFound();
            }
            ViewData["eventoId"] = new SelectList(_context.Eventos, "id", "id", anotacao_Evento.eventoId);
            return View(anotacao_Evento);
        }

        // POST: Anotacao_Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,eventoId")] Anotacao_Evento anotacao_Evento)
        {
            if (id != anotacao_Evento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anotacao_Evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Anotacao_EventoExists(anotacao_Evento.id))
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
            ViewData["eventoId"] = new SelectList(_context.Eventos, "id", "id", anotacao_Evento.eventoId);
            return View(anotacao_Evento);
        }

        // GET: Anotacao_Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao_Evento = await _context.Anotacao_Evento
                .Include(a => a.evento)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anotacao_Evento == null)
            {
                return NotFound();
            }

            return View(anotacao_Evento);
        }

        // POST: Anotacao_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anotacao_Evento = await _context.Anotacao_Evento.FindAsync(id);
            _context.Anotacao_Evento.Remove(anotacao_Evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Anotacao_EventoExists(int id)
        {
            return _context.Anotacao_Evento.Any(e => e.id == id);
        }
    }
}
