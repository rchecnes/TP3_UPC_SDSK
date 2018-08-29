using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class EncuestaController : Controller
    {
        // GET: Encuesta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Encuesta/Details/5
        public ActionResult Responder(int id)
        {
            ViewBag.TIC_ID = id;

            return View();
        }

        
    }
}
