using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EXPRACU2_AGUIRRE_BASURTO.Models;

namespace EXPRACU2_AGUIRRE_BASURTO.ViewModels
{
    public class AgregarPersonalViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Este campo es obligatorio")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name = "Fecha  de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(8)]
        public string DNI { get; set; }

        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(255)]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(255)]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Cantidad de Hijos")]
        public byte CantHijos { get; set; }

        [StringLength(255)]
        public string Sexo { get; set; }

        [StringLength(255)]
        public string Estado { get; set; }

        public int TurnoId { get; set; }

        public enum SexoEnum
        {
            Masculino,
            Femenino
        }

        public IEnumerable<Turno> Turnos { get; set; }
        //public Turno Turno { get; set; }
    }

    public class CompensacionViewModel
    {
        public Compensacion Compensacion { get; set; }
        public IEnumerable<Persona> Personas { get; set; }
    }

}