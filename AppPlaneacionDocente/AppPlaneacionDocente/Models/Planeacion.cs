using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlaneacionDocente.Models
{
    public class Planeacion
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idCatMateria { get; set; }

        [Display(Name = "Grado")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idCatGrado { get; set; }

        [Display(Name = "Periodo")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idCatPeriodo { get; set; }

        [Display(Name = "Ciclo Escolar")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idCatCicloEscolar { get; set; }

        [Display(Name = "Grupos")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idCatGrupos { get; set; }

        [Display(Name = "Plan de Clase")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idPlanClase { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idUsuario { get; set; }

        [Display(Name = "Objetivos de Aprendizaje")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public int idObjetosAprendizaje { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Competencias a Desarrollar")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strCompetenciaDesarrollar { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Criterios de Desempeño")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strCriteriosDesempeño { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Criterios de Evaluación")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strCriteriosEvaluacion { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Institución")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strInstitucion { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Total de Sesiones")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strTotalSesiones { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Total de Horas")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strTotalHoras { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Contexto de la Escuela")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strContextoEscuela { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Desempeño del Estudiante al Concluir el Bloque")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strDesempeñoEstudianteConcluirBloque { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Diagnostico Socio Educativo")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strDiagnosticoSocioEducativo { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Bloques")]
        [Required(ErrorMessage = "Esta Campo es Requerido")]
        public string strBloques { get; set; }


        public Materia materia { get; set; }
        public Grado grado { get; set; }
        public Periodo periodo { get; set; }
        public CicloEscolar cicloEscolar { get; set; }
        public Grupo grupo { get; set; }
        public ObjetosAprendizaje objetosAprendizaje { get; set; }


       
    }
}