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
    
    public partial class TblUsuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUsuarios()
        {
            this.TblPlaneacion = new HashSet<TblPlaneacion>();
        }
    
        public int id { get; set; }
        public string strMatricula { get; set; }
        public string strPassword { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idCatTipoUsuario { get; set; }
    
        public virtual CatTipoUsuario CatTipoUsuario { get; set; }
        public virtual TblPersonal TblPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPlaneacion> TblPlaneacion { get; set; }
    }
}
