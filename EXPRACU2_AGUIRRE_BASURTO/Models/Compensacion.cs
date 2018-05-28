using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Compensaciones")]
    public class Compensacion
    {
        [Key]
        public int Id { get; set; }
        public Persona Persona { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public TimeSpan? HorasCompensadas { get; set; }
    }
}