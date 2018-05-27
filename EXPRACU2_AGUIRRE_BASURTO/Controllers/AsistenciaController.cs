using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult TomarAsistencia()
        {
            //var cantidadAsistenciasHoy = _context.Asistencias.Count(f => f.Fecha == DateTime.Today);
            var asistenciasHoy = _context.Asistencias.Include(p => p.Persona).Where(m => m.Fecha == DateTime.Today).ToList();
            if (asistenciasHoy.Count == 0)
            {
                var personal = _context.Personal.ToList();
                var asistenciasNuevas = new List<Asistencia>();
                foreach (var p in personal)
                {
                    var asistencia = new Asistencia()
                    {
                        Fecha = DateTime.Today,
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

        public ActionResult Guardar(List<Asistencia> listaModel)
        {
            foreach (var asistencia in listaModel)
            {
                var asistenciaInDb = _context.Asistencias.Single(p => p.Id == asistencia.Id);
                asistenciaInDb = asistencia;
            }
            _context.SaveChanges();
            return RedirectToAction("TomarAsistencia");
        }


        //private Asistencia asistencia = new Asistencia();
            //// GET: Persona
            //public ActionResult Index(String criterio)
            //{

            //    if (criterio == null || criterio == "")
            //    {
            //        var per = new List<Asistencia>();
            //        try
            //        {
            //            using (var db = new ApplicationDbContext())
            //            {
            //                per = db.Asistencias.ToList();

            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;

            //        }
            //        return View(per);
            //    }
            //    else
            //    {

            //        return View(Buscar(criterio));
            //    }
            //}
            //public ActionResult Buscar(String criterio)
            //{
            //    var persona1 = new List<Asistencia>();
            //    using (var db = new ApplicationDbContext())
            //    {
            //        persona1 = db.Asistencias.Where(x => x.Persona.Nombres.Contains(criterio)).ToList();
            //    }
            //    return View(persona1);
            //}
            //public ActionResult Agregar(int id = 0)
            //{
            //    using (var db = new ApplicationDbContext())
            //    {
            //        asistencia = db.Asistencias.Where(x => x.Id == id).SingleOrDefault();

            //    }
            //    return View(id == 0 ? new Asistencia() : asistencia);
            //}
            //public ActionResult Guardar(Asistencia persona)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        using (var db = new ApplicationDbContext())
            //        {
            //            if (persona.Id > 0)
            //            {
            //                db.Entry(this).State = EntityState.Modified;
            //            }
            //            else
            //            {
            //                db.Entry(this).State = EntityState.Added;
            //            }
            //            db.SaveChanges();
            //        }
            //        return Redirect("~/Asistencia");
            //    }
            //    else
            //    {
            //        return View("~/Views/Asistencia/Agregar.cshtml", persona);
            //    }
            //}
            //public ActionResult Eliminar(int id = 0)
            //{
            //    asistencia.Id = id;
            //    using (var db = new ApplicationDbContext())
            //    {
            //        db.Entry(this).State = EntityState.Deleted;
            //        db.SaveChanges();
            //    }
            //    return Redirect("~/Asistencia");
            //}
        }
}