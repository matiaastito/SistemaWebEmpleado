using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVCSistemaWebTransportes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToString();
            ViewBag.Message = "Bienvenido al Sitio Web";
            return View();
        }

    }
}