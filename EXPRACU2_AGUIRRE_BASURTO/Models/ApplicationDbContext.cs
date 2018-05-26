using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EXPRACU2_AGUIRRE_BASURTO.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Persona> Personal { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<HorasExtra> HorasExtra { get; set; }
        public DbSet<Compensacion> Compensaciones { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<PermisoSimple> PermisosSimples { get; set; }
        public DbSet<PermisoAvanzado> PermisosAvanzados { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Licencia> Licencias { get; set; }
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}