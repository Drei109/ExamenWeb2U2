using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class PermisoSimpleController : Controller
    {
        private PermisoSimple permiso = new PermisoSimple();
        // GET: Persona
        public ActionResult Index(String criterio)
        {

            if (criterio == null || criterio == "")
            {
                var per = new List<PermisoSimple>();
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        per = db.PermisosSimples.ToList();

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
            var persona1 = new List<PermisoSimple>();
            using (var db = new ApplicationDbContext())
            {
                persona1 = db.PermisosSimples.Where(x => x.Persona.Nombres.Contains(criterio)).ToList();
            }
            return View(persona1);
        }
        public ActionResult Agregar(int id = 0)
        {
            using (var db = new ApplicationDbContext())
            {
                permiso = db.PermisosSimples.Where(x => x.Id == id).SingleOrDefault();

            }
            return View(id == 0 ? new PermisoSimple() : permiso);
        }
        public ActionResult Guardar(PermisoSimple persona)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    if (persona.Id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
                return Redirect("~/PermisoSimple");
            }
            else
            {
                return View("~/Views/PermisoSimple/Agregar.cshtml", persona);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            permiso.Id = id;
            using (var db = new ApplicationDbContext())
            {
                db.Entry(this).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return Redirect("~/PermisoSimple");
        }
    }
}