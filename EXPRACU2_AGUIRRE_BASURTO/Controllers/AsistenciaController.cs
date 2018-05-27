using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class AsistenciaController : Controller
    {
        private ApplicationDbContext _context;

        public AsistenciaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //[Route("Mantenimiento/Asistencia/TomarAsistencia/{year}/{month:regex(\\d{2}):range(1,12)}/{day:regex(\\d{2}):range(1,31)}")]
        //[Route("Mantenimiento/Asistencia/TomarAsistencia/")]
        public ActionResult TomarAsistencia(string fecha)
        {
            var fechaAsistencia = !fecha.IsNullOrWhiteSpace() ? Convert.ToDateTime(fecha) : DateTime.Today;
            ViewBag.Fecha = fechaAsistencia.Date;

            var asistenciasHoy = _context.Asistencias.Include(p => p.Persona).Where(m => m.Fecha == fechaAsistencia).ToList();
            if (asistenciasHoy.Count == 0)
            {
                var personal = _context.Personal.ToList();
                var asistenciasNuevas = new List<Asistencia>();
                foreach (var p in personal)
                {
                    var asistencia = new Asistencia()
                    {
                        Fecha = fechaAsistencia,
                        PersonaId = p.Id,
                        Persona = _context.Personal.SingleOrDefault(x => x.Id == p.Id)
                    };

                    var asistenciaNueva = _context.Asistencias.Add(asistencia);
                    asistencia.Id = asistenciaNueva.Id;
                    asistenciasNuevas.Add(asistencia);
                }
                _context.SaveChanges();
                return View(asistenciasNuevas);
            }
            else
            {
                return View(asistenciasHoy);
            }
        }

        //[Route("Mantenimiento/Asistencia/Guardar")]
        public ActionResult Guardar(List<Asistencia> listaModel)
        {
            foreach (var asistencia in listaModel)
            {
                var asistenciaInDb = _context.Asistencias.Include(p => p.Persona).Include(m => m.Persona.Turno).Single(p => p.Id == asistencia.Id);
                asistenciaInDb.HoraLLegada = asistencia.HoraLLegada;
                asistenciaInDb.HoraSalida = asistencia.HoraSalida;
                _context.Entry(asistenciaInDb).State = EntityState.Modified;

                if (asistenciaInDb.HoraSalida!=null)
                {
                    if (asistenciaInDb.HoraSalida > asistenciaInDb.Persona.Turno.HoraFin)
                    {
                        var existe = _context.HorasExtra.FirstOrDefault(m => m.Fecha == asistenciaInDb.Fecha && m.PersonaId == asistenciaInDb.PersonaId);
                        if (existe == null)
                        {
                            var horasExtra = new HorasExtra()
                            {
                                PersonaId = asistenciaInDb.PersonaId,
                                Fecha = asistenciaInDb.Fecha,
                                Motivo = "Horas Extra",
                                Aumenta = true,
                                HorasCantidad = asistenciaInDb.HoraSalida - asistenciaInDb.Persona.Turno.HoraFin,
                            };
                            _context.HorasExtra.Add(horasExtra);
                        }
                        else
                        {
                            var horasExtra = _context.HorasExtra.SingleOrDefault(x => x.Id == existe.Id);
                            if (horasExtra != null)
                                horasExtra.HorasCantidad = asistenciaInDb.HoraSalida - asistenciaInDb.Persona.Turno.HoraFin;
                        }
                    }
                }

            }
            _context.SaveChanges();
            return RedirectToAction("TomarAsistencia");
        }
     }
}