using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoConsultorio.Models
{
    public class AreaMedica
    {
        [Key]
        public int IdArea { get; set; }

        public string Area { get; set; }
    }
}
