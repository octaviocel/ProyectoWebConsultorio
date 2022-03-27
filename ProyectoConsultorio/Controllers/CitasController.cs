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
    public class CitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cita.Include(c => c.AreaMedica).Include(c => c.paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Cita.Include(c => c.AreaMedica).Include(c => c.paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.AreaMedica)
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.IdCitas == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["Id_AreaMedica"] = new SelectList(_context.AreaMedica, "IdArea", "Area");
            ViewData["Id_paciente"] = new SelectList(_context.Paciente, "Id_paciente", "Nombre");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCitas,Id_AreaMedica,Fecha,Hora,Id_paciente")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_AreaMedica"] = new SelectList(_context.AreaMedica, "IdArea", "IdArea", cita.Id_AreaMedica);
            ViewData["Id_paciente"] = new SelectList(_context.Paciente, "Id_paciente", "Id_paciente", cita.Id_paciente);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["Id_AreaMedica"] = new SelectList(_context.AreaMedica, "IdArea", "IdArea", cita.Id_AreaMedica);
            ViewData["Id_paciente"] = new SelectList(_context.Paciente, "Id_paciente", "Id_paciente", cita.Id_paciente);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCitas,Id_AreaMedica,Fecha,Hora,Id_paciente")] Cita cita)
        {
            if (id != cita.IdCitas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.IdCitas))
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
            ViewData["Id_AreaMedica"] = new SelectList(_context.AreaMedica, "IdArea", "IdArea", cita.Id_AreaMedica);
            ViewData["Id_paciente"] = new SelectList(_context.Paciente, "Id_paciente", "Id_paciente", cita.Id_paciente);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.AreaMedica)
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.IdCitas == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.IdCitas == id);
        }
    }
}
