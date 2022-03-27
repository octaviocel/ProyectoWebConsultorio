using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoConsultorio.Models
{
    public class Cita
    {
        [Key]
        public int IdCitas { get; set; }
        public int Id_AreaMedica { get; set; }
        [ForeignKey("Id_AreaMedica")]
        public AreaMedica AreaMedica { get; set; }

        [DataType(DataType.Date)]//[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        // public string fecha1 { get; set; }
        [DataType(DataType.Time)]
        ///[DisplayFormat(DataFormatString = "{HH:mm}")]
        public DateTime Hora { get; set; }
        public int Id_paciente { get; set; }
        [ForeignKey("Id_paciente")]
        public Paciente paciente { get; set; }
        
    }
}
