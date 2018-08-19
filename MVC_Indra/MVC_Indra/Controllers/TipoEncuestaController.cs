using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class TipoEncuestaController : Controller
    {
        // GET: TipoEncuesta
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoEncuesta/Details/5
        public ActionResult Nuevo()
        {
            return View();
        }

        // GET: TipoEncuesta/Create
        public ActionResult Editar(int id)
        {
            ViewBag.TEN_ID = id;

            return View();
        }
    }
}
