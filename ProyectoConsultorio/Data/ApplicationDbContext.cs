using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoConsultorio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Expediente> Expediente { get; set; }        
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<AreaMedica> AreaMedica { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
