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
        [Display(Name = "Gama")]
        public string GAMA { get; set; }

        [Required]
        [Display(Name = "Fecha Creación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FECHA_CREACION { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public long PRECIO { get; set; }

        [Required]
        [Display(Name = "Ocupado")]
        public bool OCUPADO { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool ACTIVO { get; set; }

        public long ID_MARCA { get; set; }

        public long ID_TIPO { get; set; }

        public virtual MARCA MARCA { get; set; }

        public virtual TIPO TIPO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENTA> RENTA { get; set; }
    }
}
