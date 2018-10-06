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
        public long ID_RENTA { get; set; }

        public long PRECIO { get; set; }

        public DateTime FECHA_ALQUILER { get; set; }

        public long ID_AUTOMOVIL { get; set; }

        public long ID_USUARIO { get; set; }

        public virtual AUTOMOVIL AUTOMOVIL { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
