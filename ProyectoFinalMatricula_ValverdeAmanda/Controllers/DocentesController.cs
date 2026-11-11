
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalMatricula_ValverdeAmanda.Data;
using ProyectoFinalMatricula_ValverdeAmanda.Models;

namespace ProyectoFinalMatricula_ValverdeAmanda.Controllers
{
    public class DocentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Docentes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Docente docente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var docente = await _context.Docentes.FindAsync(id);
            if (docente == null) return NotFound();

            return View(docente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Docente docente)
        {
            if (id != docente.DocenteId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(docente);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var docente = await _context.Docentes.FirstOrDefaultAsync(d => d.DocenteId == id);

            if (docente == null) return NotFound();

            return View(docente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var docente = await _context.Docentes.FirstOrDefaultAsync(d => d.DocenteId == id);

            if (docente == null) return NotFound();

            return View(docente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);

            if (docente != null)
            {
                _context.Docentes.Remove(docente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
