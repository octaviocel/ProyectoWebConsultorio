using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoConsultorio.Models
{
    public class Paciente
    {
        [Key]
        public int Id_paciente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Sexo { get; set; }
        public string RFC { get; set; }
        public string TipoSangre { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }
        public bool Alcoholismo { get; set; }
        public bool Tabaquismo { get; set; }
        public bool Toxicaomania { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string CURP { get; set; }
        public string Aseguradora { get; set; }
    }
}
