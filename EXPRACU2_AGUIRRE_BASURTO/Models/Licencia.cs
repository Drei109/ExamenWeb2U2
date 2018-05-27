using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Licencias")]
    public class Licencia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Persona Persona { get; set; }
        [StringLength(255)]
        public string Tipo { get; set; }
        [Column(TypeName = "Date")]
        [Required]
        public DateTime Fecha { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaFin { get; set; }
        [StringLength(255)]
        public string Estado { get; set; }
        public int PersonaId { get; set; }
    }
}