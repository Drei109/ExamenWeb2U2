using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("HorasExtra")]
    public class HorasExtra
    {
        [Key]
        public int Id { get; set; }
        public Persona Persona { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        [StringLength(255)]
        public string Motivo { get; set; }
        public bool Aumenta { get; set; }
        public TimeSpan? HorasCantidad { get; set; }
        public int? PersonaId { get; set; }
    }
}