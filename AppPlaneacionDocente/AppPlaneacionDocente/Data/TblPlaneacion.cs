//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppPlaneacionDocente.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblPlaneacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPlaneacion()
        {
            this.CatProyectos = new HashSet<CatProyectos>();
            this.TblPlanDeClase = new HashSet<TblPlanDeClase>();
        }
    
        public int id { get; set; }
        public Nullable<int> idCatMaterias { get; set; }
        public Nullable<int> idCatGrado { get; set; }
        public Nullable<int> idCatPeriodo { get; set; }
        public Nullable<int> idCatCicloEscolar { get; set; }
        public Nullable<int> idCatGrupos { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<int> idObjetosAprendizaje { get; set; }
        public string strCompetenciaDesarrollar { get; set; }
        public string strCriteriosDesempeño { get; set; }
        public string strCriteriosEvaluacion { get; set; }
        public string strInstitucion { get; set; }
        public string strTotalSesiones { get; set; }
        public string strTotalHoras { get; set; }
        public string strContextoEscuela { get; set; }
        public string strDesempeñoEstudianteConcluirBloque { get; set; }
        public string strDiagnosticoSocioEducativo { get; set; }
        public string strBloques { get; set; }
    
        public virtual CatCicloEscolar CatCicloEscolar { get; set; }
        public virtual CatGrupos CatGrupos { get; set; }
        public virtual CatMateria CatMateria { get; set; }
        public virtual CatPeriodo CatPeriodo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatProyectos> CatProyectos { get; set; }
        public virtual TblObjetosAprendizaje TblObjetosAprendizaje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPlanDeClase> TblPlanDeClase { get; set; }
        public virtual TblUsuarios TblUsuarios { get; set; }
    }
}
