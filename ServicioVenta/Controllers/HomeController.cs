using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioVenta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Cerrar()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Index");
        }


    }
}