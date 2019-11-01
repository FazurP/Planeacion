using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlaneacionDocente.Models
{
    public class ObjetosAprendizaje
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string strAprendizajeEsperado { get; set; }
    }
}