namespace SaludCloudV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cita")]
    public partial class cita
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre_Paciente { get; set; }

        [Required]
        [StringLength(255)]
        public string Apellido_Paciente { get; set; }

        [Column(TypeName = "text")]
        public string Motivo { get; set; }

        [StringLength(255)]
        public string Nota { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        [Required]
        [StringLength(255)]
        public string Medico { get; set; }

        [Required]
        [StringLength(255)]
        public string Centro_Salud { get; set; }

        [Required]
        [StringLength(255)]
        public string Estatus { get; set; }

        [StringLength(255)]
        public string Estatus_Correo { get; set; }
    }
}
