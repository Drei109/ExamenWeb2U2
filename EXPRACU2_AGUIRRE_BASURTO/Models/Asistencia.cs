using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Asistencias")]
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Persona Persona { get; set; }
        [Column(TypeName = "Date")]
        [Required]
        public DateTime Fecha { get; set; }
        public TimeSpan? HoraLLegada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public bool EsFinSemana { get; set; }
        public bool EsFeriado { get; set; }
        [StringLength(255)]
        public string Estado { get; set; }
        public int? PersonaId { get; set; }

    }
}