using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class TipoSolucionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            ViewBag.SOL_ID = id;

            return View();
        }
    }
}
