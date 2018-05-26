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
        [Required]
        public Persona Persona { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        [StringLength(255)]
        public string Motivo { get; set; }
        public bool Aumenta { get; set; }
        public byte HorasCantidad { get; set; }
        
    }
}