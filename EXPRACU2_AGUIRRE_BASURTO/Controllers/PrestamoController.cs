using EXPRACU2_AGUIRRE_BASURTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class PrestamoController : Controller
    {
        private Prestamo prestamo = new Prestamo();
        private Persona persona = new Persona();
        // GET: Persona
        public ActionResult Index(String criterio)
        {

            if (criterio == null || criterio == "")
            {
                var per = new List<Prestamo>();
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        per = db.Prestamos.Include(x=>x.Persona).ToList();
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
            var persona1 = new List<Prestamo>();
            using (var db = new ApplicationDbContext())
            {
                persona1 = db.Prestamos.Include(x => x.Persona).Where(x => x.Persona.Nombres.Contains(criterio)).ToList();
            }
            return View(persona1);
        }
        public ActionResult Agregar(int id = 0)
        {
          
            using (var db = new ApplicationDbContext())
            {
                List<Persona> person = db.Personal.ToList();
                ViewBag.Persona = person;
                prestamo = db.Prestamos.Where(x => x.Id == id).SingleOrDefault();         
            }
            
            return View(id == 0 ? new Prestamo() : prestamo);
        }
        public ActionResult Guardar(Prestamo prestamo1)
        {
            prestamo1.Total = (prestamo1.Cantidad + (prestamo1.Cantidad * (prestamo1.Interes / 100)));
            using (var db = new ApplicationDbContext())
            {
                List<Persona> person = db.Personal.ToList();
                ViewBag.Persona = person;
            }
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                   
                    if (prestamo1.Id > 0)
                    {
                        db.Entry(prestamo1).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(prestamo1).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
                return Redirect("~/Prestamo");
            }
            else
            {
                return View("~/Views/Prestamo/Agregar.cshtml", prestamo);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            prestamo.Id = id;
            using (var db = new ApplicationDbContext())
            {
                db.Entry(prestamo).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return Redirect("~/Prestamo");
        }
        public ActionResult Detalles(int id)
        {
            using (var db =  new ApplicationDbContext())
            {
                prestamo = db.Prestamos.Where(x => x.Id == id).SingleOrDefault();
            }
            return View(prestamo);
            
        }
    }
}