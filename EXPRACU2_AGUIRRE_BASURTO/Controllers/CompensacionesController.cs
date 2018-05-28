using EXPRACU2_AGUIRRE_BASURTO.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EXPRACU2_AGUIRRE_BASURTO.ViewModels;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class CompensacionesController : Controller
    {
        private ApplicationDbContext _context;

        public CompensacionesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Procesos/Compensacion/Listar")]
        public ActionResult ListarCompensaciones()
        {
            var compensaciones = _context.Compensaciones.Include(m => m.Persona).ToList();
            return View(compensaciones);
        }

        [Route("Procesos/Compensacion/Agregar/{id?}")]
        public ActionResult AgregarCompensacion(int id=0)
        {
            if (id == 0)
            {
                var viewModel = new CompensacionViewModel()
                {
                    Personas = _context.Personal.ToList()
                };
                return View(viewModel);
            }
            else
            {
                var compensacionInBd = _context.Compensaciones.Single(p => p.Id == id);
                var viewModelInDb = new CompensacionViewModel();
                viewModelInDb.Compensacion = compensacionInBd;
                viewModelInDb.Personas = _context.Personal.ToList();
                return View(viewModelInDb);
            }
        }

        [HttpPost]
        public ActionResult Agregar(CompensacionViewModel model)
        {
            var compensacion = model.Compensacion;
            ModelState.Remove("Persona");
            var persona = _context.Personal.FirstOrDefault(p => p.Id == compensacion.PersonaId);

            if (compensacion.HorasCompensadas<=persona.HorasExtraAcumuladas)
            {
                if (compensacion.Id == 0)
                {
                    _context.Compensaciones.Add(compensacion);

                    var horasExtra = new HorasExtra()
                    {
                        PersonaId = compensacion.PersonaId,
                        Fecha = compensacion.Fecha,
                        Motivo = "Compensación",
                        Aumenta = false,
                        HorasCantidad = compensacion.HorasCompensadas
                    };
                    _context.HorasExtra.Add(horasExtra);
                }
                else
                {
                    var compensacionInDb = _context.Compensaciones.Single(p => p.Id == model.Compensacion.Id);
                    compensacionInDb.Fecha = compensacion.Fecha;
                    compensacionInDb.HorasCompensadas = compensacion.HorasCompensadas;
                    compensacionInDb.PersonaId = compensacion.PersonaId;

                    var horasExtraInDb = _context.HorasExtra.FirstOrDefault(p => p.Fecha == compensacion.Fecha && p.PersonaId == compensacion.Id);
                    if (horasExtraInDb != null)
                    {
                        horasExtraInDb.PersonaId = compensacion.PersonaId;
                        horasExtraInDb.Fecha = compensacion.Fecha;
                        horasExtraInDb.Motivo = "Compensación";
                        horasExtraInDb.Aumenta = false;
                        horasExtraInDb.HorasCantidad = compensacion.HorasCompensadas;
                    }
                }
                _context.SaveChanges();
                var compensaciones = _context.Compensaciones.Include(m => m.Persona).ToList();
                return View("ListarCompensaciones", compensaciones);
            }
            
            var viewModel = new CompensacionViewModel()
            {
                Personas = _context.Personal.ToList()
            };
            return View ("AgregarCompensacion", viewModel);
        }
    }
}