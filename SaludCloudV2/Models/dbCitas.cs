namespace SaludCloudV2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbCitas : DbContext
    {
        public dbCitas()
            : base("name=dbCitas")
        {
        }

        public virtual DbSet<cita> cita { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cita>()
                .Property(e => e.Nombre_Paciente)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Apellido_Paciente)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Nota)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Hora)
                .HasPrecision(6);

            modelBuilder.Entity<cita>()
                .Property(e => e.Medico)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Centro_Salud)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Estatus)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.Estatus_Correo)
                .IsUnicode(false);
        }
    }
}
