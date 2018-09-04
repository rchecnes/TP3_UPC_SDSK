using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class MonitoreoController : Controller
    {
        // GET: Sla
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sla/Details/5
        public ActionResult Consultar(int id)
        {
            ViewBag.CON_ID = id;
            return View();
        }

    }
}
