using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Personal")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(255)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(255)]
        public string ApellidoMaterno { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(8)]
        public string DNI { get; set; }
        [StringLength(255)]
        public string Direccion { get; set; }
        [StringLength(255)]
        public string Telefono { get; set; }
        [StringLength(255)]
        public string EstadoCivil { get; set; }
        public byte CantHijos { get; set; }
        [StringLength(255)]
        public string Sexo { get; set; }
        [StringLength(255)]
        public string Estado { get; set; }
        public TimeSpan? HorasExtraAcumuladas { get; set; }
        public int? TurnoId { get; set; }
        public Turno Turno { get; set; }
        public virtual ICollection<Asistencia> Asistencias { get; set; }
        public virtual ICollection<Asignacion> Asignaciones { get; set; }
        public virtual ICollection<Compensacion> Compensaciones { get; set; }
        public virtual ICollection<HorasExtra> HorasExtras { get; set; }
        public virtual ICollection<Licencia> Licencias { get; set; }
        public virtual ICollection<PermisoSimple> PermisosSimples { get; set; }
        public virtual ICollection<PermisoAvanzado> PermisosAvanzados { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}