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
    public class AnotacoesController : Controller
    {
        private readonly Context _context;

        public AnotacoesController(Context context)
        {
            _context = context;
        }

        // GET: Anotacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anotacao.ToListAsync());
        }

        // GET: Anotacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao = await _context.Anotacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (anotacao == null)
            {
                return NotFound();
            }

            return View(anotacao);
        }

        // GET: Anotacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anotacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao")] Anotacao anotacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anotacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anotacao);
        }

        // GET: Anotacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao = await _context.Anotacao.FindAsync(id);
            if (anotacao == null)
            {
                return NotFound();
            }
            return View(anotacao);
        }

        // POST: Anotacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao")] Anotacao anotacao)
        {
            if (id != anotacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anotacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnotacaoExists(anotacao.id))
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
            return View(anotacao);
        }

        // GET: Anotacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacao = await _context.Anotacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (anotacao == null)
            {
                return NotFound();
            }

            return View(anotacao);
        }

        // POST: Anotacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anotacao = await _context.Anotacao.FindAsync(id);
            _context.Anotacao.Remove(anotacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnotacaoExists(int id)
        {
            return _context.Anotacao.Any(e => e.id == id);
        }
    }
}
