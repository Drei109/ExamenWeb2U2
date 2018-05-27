using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Turnos")]
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}