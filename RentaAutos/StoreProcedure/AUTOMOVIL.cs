//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentaAutos.StoreProcedure
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUTOMOVIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTOMOVIL()
        {
            this.RENTA = new HashSet<RENTA>();
        }
    
        public long ID_AUTOMOVIL { get; set; }
        public string GAMA { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public long PRECIO { get; set; }
        public bool OCUPADO { get; set; }
        public bool ACTIVO { get; set; }
        public long ID_MARCA { get; set; }
        public long ID_TIPO { get; set; }
    
        public virtual MARCA MARCA { get; set; }
        public virtual TIPO TIPO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENTA> RENTA { get; set; }
    }
}
