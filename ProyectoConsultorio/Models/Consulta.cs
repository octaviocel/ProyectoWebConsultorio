using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoConsultorio.Models
{
    public class Consulta
    {
        [Key]
        public int Id_consulta { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public int Presion1 { get; set; }
        public int Presion2 { get; set; }
        public int Id_paciente { get; set; }
        [ForeignKey("Id_paciente")]
        public Paciente paciente { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Medicamentos { get; set; }
    }
}
