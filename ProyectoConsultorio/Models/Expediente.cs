using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoConsultorio.Models
{
    public class Expediente
    {
        [Key]
        public int Id_expediente { get; set; }
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente paciente { get; set; }
        public int EmpleadoId{ get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado empleado { get; set; }
        public int Presion1 { get; set; }
        public int Presion2 { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public string CronicoDegenerativa { get; set; }
        public string Operaciones { get; set; }
        public string Alergias { get; set; }
        public string Reflejos { get; set; }
        public string Movimientos { get; set; }
        public string Observaciones { get; set; }
    }
}
