using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Sla
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sla/Details/5
        public ActionResult Nuevo()
        {
            return View();
        }

        // GET: Sla/Details/5
        public ActionResult Editar(int id)
        {
            ViewBag.CON_ID = id;

            return View();
        }
    }
}
