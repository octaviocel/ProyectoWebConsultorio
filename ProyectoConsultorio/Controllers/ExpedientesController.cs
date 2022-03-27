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
    public class ExpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expediente.Include(e => e.empleado).Include(e => e.paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expedientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .Include(e => e.empleado)
                .Include(e => e.paciente)
                .FirstOrDefaultAsync(m => m.Id_expediente == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // GET: Expedientes/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "IdEmpleado", "Nombre");
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id_paciente", "Nombre");
            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_expediente,PacienteId,EmpleadoId,Presion1,Presion2,Peso,Altura,CronicoDegenerativa,Operaciones,Alergias,Reflejos,Movimientos,Observaciones")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "IdEmpleado", "Nombre", expediente.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id_paciente", "Nombre", expediente.PacienteId);
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "IdEmpleado", "Nombre", expediente.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id_paciente", "Nombre", expediente.PacienteId);
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_expediente,PacienteId,EmpleadoId,Presion1,Presion2,Peso,Altura,CronicoDegenerativa,Operaciones,Alergias,Reflejos,Movimientos,Observaciones")] Expediente expediente)
        {
            if (id != expediente.Id_expediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.Id_expediente))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "IdEmpleado", "Nombre", expediente.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id_paciente", "Nombre", expediente.PacienteId);
            return View(expediente);
        }

        // GET: Expedientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .Include(e => e.empleado)
                .Include(e => e.paciente)
                .FirstOrDefaultAsync(m => m.Id_expediente == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expediente.FindAsync(id);
            _context.Expediente.Remove(expediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expediente.Any(e => e.Id_expediente == id);
        }
    }
}
