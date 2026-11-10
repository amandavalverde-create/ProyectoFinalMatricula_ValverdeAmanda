
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalMatricula_ValverdeAmanda.Models;
using ProyectoFinalMatricula_ValverdeAmanda.Data;

public class CarrerasController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarrerasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CARRERAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Carreras.ToListAsync());
    }

    // GET: CARRERAS/Details/5
    public async Task<IActionResult> Details(int? carreraid)
    {
        if (carreraid == null)
        {
            return NotFound();
        }

        var carrera = await _context.Carreras
            .FirstOrDefaultAsync(m => m.CarreraId == carreraid);
        if (carrera == null)
        {
            return NotFound();
        }

        return View(carrera);
    }

    // GET: CARRERAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CARRERAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CarreraId,Nombre,Descripcion,Estado")] Carrera carrera)
    {
        if (ModelState.IsValid)
        {
            _context.Add(carrera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(carrera);
    }

    // GET: CARRERAS/Edit/5
    public async Task<IActionResult> Edit(int? carreraid)
    {
        if (carreraid == null)
        {
            return NotFound();
        }

        var carrera = await _context.Carreras.FindAsync(carreraid);
        if (carrera == null)
        {
            return NotFound();
        }
        return View(carrera);
    }

    // POST: CARRERAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? carreraid, [Bind("CarreraId,Nombre,Descripcion,Estado")] Carrera carrera)
    {
        if (carreraid != carrera.CarreraId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(carrera);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarreraExists(carrera.CarreraId))
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
        return View(carrera);
    }

    // GET: CARRERAS/Delete/5
    public async Task<IActionResult> Delete(int? carreraid)
    {
        if (carreraid == null)
        {
            return NotFound();
        }

        var carrera = await _context.Carreras
            .FirstOrDefaultAsync(m => m.CarreraId == carreraid);
        if (carrera == null)
        {
            return NotFound();
        }

        return View(carrera);
    }

    // POST: CARRERAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? carreraid)
    {
        var carrera = await _context.Carreras.FindAsync(carreraid);
        if (carrera != null)
        {
            _context.Carreras.Remove(carrera);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CarreraExists(int? carreraid)
    {
        return _context.Carreras.Any(e => e.CarreraId == carreraid);
    }
}
