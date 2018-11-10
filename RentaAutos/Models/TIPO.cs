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
        [Display(Name = "Nombre Tipo")]
        public string NOMBRE_TIPO { get; set; }

        [Required]
        [Display(Name = "Fecha Creación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FECHA_CREACION { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool ACTIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOMOVIL> AUTOMOVIL { get; set; }
    }
}
