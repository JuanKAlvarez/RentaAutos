namespace RentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIPO")]
    public partial class TIPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO()
        {
            AUTOMOVIL = new HashSet<AUTOMOVIL>();
        }

        [Key]
        public long ID_TIPO { get; set; }

        [Required]
        public string NOMBRE_TIPO { get; set; }

        public DateTime FECHA_CREACION { get; set; }

        public bool ACTIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOMOVIL> AUTOMOVIL { get; set; }
    }
}
