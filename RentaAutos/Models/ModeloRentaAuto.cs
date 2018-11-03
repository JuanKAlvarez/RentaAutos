namespace RentaAutos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloRentaAuto : DbContext
    {
        public ModeloRentaAuto()
            : base("name=ModeloRentaAuto")
        {
        }

        public virtual DbSet<AUTOMOVIL> AUTOMOVIL { get; set; }
        public virtual DbSet<MARCA> MARCA { get; set; }
        public virtual DbSet<RENTA> RENTA { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<TIPO> TIPO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTOMOVIL>()
                .Property(e => e.GAMA)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOMOVIL>()
                .HasMany(e => e.RENTA)
                .WithRequired(e => e.AUTOMOVIL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MARCA>()
                .Property(e => e.NOMBRE_MARCA)
                .IsUnicode(false);

            modelBuilder.Entity<MARCA>()
                .HasMany(e => e.AUTOMOVIL)
                .WithRequired(e => e.MARCA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.NOMBRE_ROL)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.ROL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIPO>()
                .Property(e => e.NOMBRE_TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO>()
                .HasMany(e => e.AUTOMOVIL)
                .WithRequired(e => e.TIPO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USUARIO1)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CONTRASENA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CORREO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.RENTA)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);
        }
    }
}
