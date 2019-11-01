using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlaneacionDocente.Models
{
    public class Materia
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strValor { get; set; }

    }
}