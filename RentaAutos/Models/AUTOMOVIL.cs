namespace RentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUTOMOVIL")]
    public partial class AUTOMOVIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTOMOVIL()
        {
            RENTA = new HashSet<RENTA>();
        }

        [Key]
        public long ID_AUTOMOVIL { get; set; }

        [Required]
        public string GAMA { get; set; }

        public DateTime FECHA_CREACION { get; set; }

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
