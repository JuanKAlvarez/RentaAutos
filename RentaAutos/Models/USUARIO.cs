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
        [Display(Name = "usuario")]
        public string USUARIO1 { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string CONTRASENA { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string APELLIDO_USUARIO { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime FECHA_NACIMIENTO { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string DIRECCION { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string TELEFONO { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string CORREO { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool ACTIVO { get; set; }

        [Display(Name = "Rol")]
        public long ID_ROL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENTA> RENTA { get; set; }

        public virtual ROL ROL { get; set; }
    }
}
