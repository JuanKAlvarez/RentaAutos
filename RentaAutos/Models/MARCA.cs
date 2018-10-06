namespace RentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARCA")]
    public partial class MARCA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MARCA()
        {
            AUTOMOVIL = new HashSet<AUTOMOVIL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Numero Marca")]
        public long ID_MARCA { get; set; }

        [Required]
        [Display(Name = "Nombre Marca")]
        public string NOMBRE_MARCA { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime FECHA_CREACION { get; set; }

        [Display(Name = "Activo")]
        public bool ACTIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOMOVIL> AUTOMOVIL { get; set; }
    }
}
