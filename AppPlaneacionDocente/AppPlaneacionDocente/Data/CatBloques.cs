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
    
    public partial class CatBloques
    {
        public int id { get; set; }
        public string strValor { get; set; }
        public Nullable<int> idCatMateria { get; set; }
    
        public virtual CatMateria CatMateria { get; set; }
    }
}