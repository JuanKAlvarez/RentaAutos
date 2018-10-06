namespace RentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            RENTA = new HashSet<RENTA>();
        }

        [Key]
        public long ID_USUARIO { get; set; }

        [Column("USUARIO")]
        [Required]
        public string USUARIO1 { get; set; }

        [Required]
        public string CONTRASENA { get; set; }

        [Required]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        public string APELLIDO_USUARIO { get; set; }

        public DateTime FECHA_NACIMIENTO { get; set; }

        [Required]
        public string DIRECCION { get; set; }

        [Required]
        public string TELEFONO { get; set; }

        [Required]
        public string CORRECO { get; set; }

        public long ID_ROL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENTA> RENTA { get; set; }

        public virtual ROL ROL { get; set; }
    }
}
