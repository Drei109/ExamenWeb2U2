using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU2_AGUIRRE_BASURTO.Models;
using EXPRACU2_AGUIRRE_BASURTO.ViewModels;
using AutoMapper;

namespace EXPRACU2_AGUIRRE_BASURTO.Controllers
{
    public class MantenimientoController : Controller
    {
        private ApplicationDbContext _context;

        public MantenimientoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Mantenimiento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarPersonal()
        {
            return View();
        }

        public ActionResult AgregarPersonal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPersonal(AgregarPersonalViewModel model)
        {
            //var Persona = Mapper.Map<AgregarPersonalViewModel, Persona>(model);
            //_context.Personal.Add(Persona);
            //_context.SaveChanges();
            return View();
        }


    }
}