
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalMatricula_ValverdeAmanda.Models;
using ProyectoFinalMatricula_ValverdeAmanda.Data;

namespace ProyectoFinalMatricula_ValverdeAmanda.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR CURSOS
        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos
                .Include(c => c.Carrera)
                .ToListAsync();

            return View(cursos);
        }

        // VER DETALLES
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var curso = await _context.Cursos
                .Include(c => c.Carrera)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (curso == null) return NotFound();

            return View(curso);
        }

        // MOSTRAR FORMULARIO DE CREACIÓN
        public IActionResult Create()
        {
            ViewBag.CarreraId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Carreras, "CarreraId", "Nombre");

            return View();
        }

        // GUARDAR NUEVO CURSO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CursoId,Nombre,Descripcion,Creditos,CarreraId,Estado")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CarreraId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Carreras, "CarreraId", "Nombre", curso.CarreraId);

            return View(curso);
        }

        // MOSTRAR FORMULARIO DE EDICIÓN
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null) return NotFound();

            ViewBag.CarreraId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Carreras, "CarreraId", "Nombre", curso.CarreraId);

            return View(curso);
        }

        // GUARDAR CAMBIOS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("CursoId,Nombre,Descripcion,Creditos,CarreraId,Estado")] Curso curso)
        {
            if (id != curso.CursoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoId))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CarreraId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Carreras, "CarreraId", "Nombre", curso.CarreraId);

            return View(curso);
        }

        // MOSTRAR CONFIRMACIÓN DE ELIMINACIÓN
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var curso = await _context.Cursos
                .Include(c => c.Carrera)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (curso == null) return NotFound();

            return View(curso);
        }

        // CONFIRMAR ELIMINACIÓN
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(c => c.CursoId == id);
        }
    }
}
