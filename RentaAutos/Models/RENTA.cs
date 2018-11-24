namespace RentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RENTA")]
    public partial class RENTA
    {
        [Key]
        [Required]
        [Display(Name = "Renta")]
        public long ID_RENTA { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public long PRECIO { get; set; }

        [Required]
        [Display(Name = "Fecha Alquiler")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FECHA_ALQUILER { get; set; }

        [Required]
        [Display(Name = "Automovil")]
        public long ID_AUTOMOVIL { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public long ID_USUARIO { get; set; }

        public virtual AUTOMOVIL AUTOMOVIL { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
