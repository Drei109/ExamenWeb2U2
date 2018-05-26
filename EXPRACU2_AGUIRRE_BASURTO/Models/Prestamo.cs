using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    [Table("Prestamos")]
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Persona Persona { get; set; }
        [Column(TypeName = "Money")]
        public decimal Cantidad { get; set; }
        public byte Cuotas { get; set; }
        public decimal Interes { get; set; }
        [Column(TypeName = "Money")]
        public decimal Total { get; set; }
        [Column(TypeName = "Date")]
        [Required]
        public DateTime Fecha { get; set; }
        [StringLength(255)]
        public string Estado { get; set; }
    }
}