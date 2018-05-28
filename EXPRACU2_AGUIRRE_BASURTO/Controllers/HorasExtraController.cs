using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class HorasExtraController : Controller
    {
        private ApplicationDbContext _context;

        public HorasExtraController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult ListarHorasExtra()
        {
            ActualizarHoras();
            var horasExtra = _context.HorasExtra.Include(m => m.Persona).ToList();
            return View(horasExtra);
        }

        private void ActualizarHoras()
        {
            var personas = _context.Personal.ToList();
            foreach (var per in personas)
            {
                var persona = _context.Personal.SingleOrDefault(m => m.Id == per.Id);
                var horasExtraPersona = _context.HorasExtra.Where(m => m.PersonaId == persona.Id);
                TimeSpan? total = TimeSpan.Zero;
                foreach (var horasExtra in horasExtraPersona)
                {
                    if (horasExtra.Aumenta)
                        total += horasExtra.HorasCantidad;
                    else
                        total -= horasExtra.HorasCantidad;
                }
                persona.HorasExtraAcumuladas = total;
            }
            _context.SaveChanges();
        }
    }
}