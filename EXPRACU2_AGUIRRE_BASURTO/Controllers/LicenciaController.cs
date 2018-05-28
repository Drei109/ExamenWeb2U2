using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class LicenciaController : Controller
    {
        private Licencia asignacion = new Licencia();
        private Persona persona = new Persona();
        // GET: Persona
        public ActionResult Index(String criterio, Licencia persona)
        {
            if (persona.FechaInicio <= DateTime.Today && persona.FechaFin >= DateTime.Today)
            {
                persona.Estado = "A";
            }
            else
            {
                persona.Estado = "I";
            }
            if (criterio == null || criterio == "")
            {
                var per = new List<Licencia>();
                try
                {                  
                    using (var db = new ApplicationDbContext())
                    {
                        per = db.Licencias.Include(x => x.Persona).ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                return View(per);
            }
            else
            {
                return View(Buscar(criterio));
            }
        }
        public ActionResult Buscar(String criterio)
        {
            var persona1 = new List<Licencia>();
            using (var db = new ApplicationDbContext())
            {
                persona1 = db.Licencias.Include(x => x.Persona).Where(x => x.Persona.Nombres.Contains(criterio)).ToList();
            }
            return View(persona1);
        }
        public ActionResult Agregar(int id = 0)
        {
            using (var db = new ApplicationDbContext())
            {
                List<Persona> person = db.Personal.ToList();
                ViewBag.Persona = person;
                asignacion = db.Licencias.Include(x => x.Persona).Where(x => x.Id == id).SingleOrDefault();

            }
            return View(id == 0 ? new Licencia() : asignacion);
        }
        public ActionResult Guardar(Licencia persona)
        {
            if (persona.FechaInicio<=DateTime.Today && persona.FechaFin>=DateTime.Today)
            {
                persona.Estado = "A";
            }
            else
            {
                persona.Estado = "I";
            }
            using (var db = new ApplicationDbContext())
            {
                List<Persona> person = db.Personal.ToList();
                ViewBag.Persona = person;
            }
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    if (persona.Id > 0)
                    {
                        db.Entry(persona).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(persona).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
                return Redirect("~/Licencia");
            }
            else
            {
                return View("~/Views/Licencia/Agregar.cshtml", persona);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            asignacion.Id = id;
            using (var db = new ApplicationDbContext())
            {
                db.Entry(asignacion).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return Redirect("~/Licencia");
        }
    }
}