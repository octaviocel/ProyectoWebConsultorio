using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoConsultorio.Data;
using ProyectoConsultorio.Models;

namespace ProyectoConsultorio.Controllers
{
    public class AreaMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreaMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AreaMedicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.AreaMedica.ToListAsync());
        }

        // GET: AreaMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaMedica = await _context.AreaMedica
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (areaMedica == null)
            {
                return NotFound();
            }

            return View(areaMedica);
        }

        // GET: AreaMedicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,Area")] AreaMedica areaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaMedica);
        }

        // GET: AreaMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaMedica = await _context.AreaMedica.FindAsync(id);
            if (areaMedica == null)
            {
                return NotFound();
            }
            return View(areaMedica);
        }

        // POST: AreaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArea,Area")] AreaMedica areaMedica)
        {
            if (id != areaMedica.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaMedicaExists(areaMedica.IdArea))
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
            return View(areaMedica);
        }

        // GET: AreaMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaMedica = await _context.AreaMedica
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (areaMedica == null)
            {
                return NotFound();
            }

            return View(areaMedica);
        }

        // POST: AreaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaMedica = await _context.AreaMedica.FindAsync(id);
            _context.AreaMedica.Remove(areaMedica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaMedicaExists(int id)
        {
            return _context.AreaMedica.Any(e => e.IdArea == id);
        }
    }
}
