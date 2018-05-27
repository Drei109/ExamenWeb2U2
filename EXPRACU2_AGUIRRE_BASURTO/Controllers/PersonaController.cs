using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU2_AGUIRRE_BASURTO.Models;
using System.Data.Entity;
using AutoMapper;
using EXPRACU2_AGUIRRE_BASURTO.ViewModels;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
   
    public class PersonaController : Controller
    {

        private ApplicationDbContext _context;

        public PersonaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Mantenimiento/Persona/Listar")]
        public ActionResult ListarPersonal()
        {
            var Personal = _context.Personal.ToList();
            return View(Personal);
        }


        [Route("Mantenimiento/Persona/Agregar")]
        public ActionResult AgregarPersonal()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Agregar(AgregarPersonalViewModel model)
        {
            var Persona = Mapper.Map<AgregarPersonalViewModel, Persona>(model);
            if (!ModelState.IsValid)
            {
                _context.Personal.Add(Persona);
                _context.SaveChanges();
                return RedirectToAction("ListarPersonal");
            }
            return View("AgregarPersonal");
        }


        //private Persona persona = new Persona();
        //// GET: Persona
        //public ActionResult Index(String criterio)
        //{

        //    if (criterio == null || criterio == "")
        //    {
        //        var per = new List<Persona>();
        //        try
        //        {
        //            using (var db = new ApplicationDbContext())
        //            {
        //                per = db.Personal.ToList();

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
        //    var persona1 = new List<Persona>();
        //    using (var db = new ApplicationDbContext())
        //    {
        //        persona1 = db.Personal.Where(x => x.Nombres.Contains(criterio)).ToList();
        //    }
        //    return View(persona1);
        //}
        //public ActionResult Agregar(int id = 0)
        //{
        //    using (var db = new ApplicationDbContext())
        //    {
        //        persona = db.Personal.Where(x => x.Id == id).SingleOrDefault();

        //    }
        //    return View(id == 0 ? new Persona() : persona);
        //}
        //public ActionResult Guardar(Persona persona)
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
        //        return Redirect("~/Persona");
        //    }
        //    else
        //    {
        //        return View("~/Views/Persona/Agregar.cshtml", persona);
        //    }
        //}
        //public ActionResult Eliminar(int id = 0)
        //{
        //    persona.Id = id;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Entry(this).State = EntityState.Deleted;
        //        db.SaveChanges();
        //    }
        //    return Redirect("~/Persona");
        //}

    }

}