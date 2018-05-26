using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Asignaciones")]
    public class Asignacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Persona Persona { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Mes { get; set; }
        [Column(TypeName = "Money")]
        public decimal Total { get; set; }
        [StringLength(255)]
        public string Estado { get; set; }
        
        

    }
}