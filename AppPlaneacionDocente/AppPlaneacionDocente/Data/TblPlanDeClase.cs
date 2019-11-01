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
    
    public partial class TblPlanDeClase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPlanDeClase()
        {
            this.TblPlaneacion = new HashSet<TblPlaneacion>();
        }
    
        public int id { get; set; }
        public Nullable<int> idActividadesEnseñanzaAprendizaje { get; set; }
        public Nullable<int> idTiempo { get; set; }
        public Nullable<int> idAtributos { get; set; }
        public Nullable<int> idEvidenciaAprendizaje { get; set; }
        public Nullable<int> idInstrumentosEvaluacion { get; set; }
        public Nullable<int> idEstrategiasIntervencion { get; set; }
        public Nullable<int> idMateriasRecursosDidacticos { get; set; }
        public string strBibliografia { get; set; }
        public string strObservaciones { get; set; }
    
        public virtual TblActividadesEnseñanzaAprendizaje TblActividadesEnseñanzaAprendizaje { get; set; }
        public virtual TblAtributos TblAtributos { get; set; }
        public virtual TblEstrategiasIntervencion TblEstrategiasIntervencion { get; set; }
        public virtual TblEvidenciaAprendizaje TblEvidenciaAprendizaje { get; set; }
        public virtual TblInstrumentosEvaluacion TblInstrumentosEvaluacion { get; set; }
        public virtual TblMaterialRecursosDidacticos TblMaterialRecursosDidacticos { get; set; }
        public virtual TblTiempo TblTiempo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPlaneacion> TblPlaneacion { get; set; }
    }
}