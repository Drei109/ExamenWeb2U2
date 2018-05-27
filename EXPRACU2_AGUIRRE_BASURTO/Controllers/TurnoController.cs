using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class TurnoController : Controller
    {
        private Turno turno = new Turno();
        //GET: Turno
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                var per = new List<Turno>();
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        per = db.Turnos.ToList();

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
            var persona1 = new List<Turno>();
            using (var db = new ApplicationDbContext())
            {
                persona1 = db.Turnos.Where(x => x.Descripcion.Contains(criterio)).ToList();
            }
            return View(persona1);
        }
        public ActionResult Agregar(int id = 0)
        {
            using (var db = new ApplicationDbContext())
            {
                turno = db.Turnos.Where(x => x.Id == id).SingleOrDefault();

            }
            return View(id == 0 ? new Turno() : turno);
        }
        public ActionResult Guardar(Turno tur)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    if (tur.Id > 0)
                    {
                        db.Entry(tur).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(tur).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
                return Redirect("~/Turno");
            }
            else
            {
                return View("~/Views/Persona/Agregar.cshtml", tur);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            turno.Id = id;
            using (var db = new ApplicationDbContext())
            {
                db.Entry(this).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return Redirect("~/Turno");
        }
    }
}