using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update(int USUS_ID, string USUS_Login, string USUS_Nombre, int USUS_CAR_ID, string USUS_CAR_Nombre, string USUS_Tipo)
        {
            System.Configuration.ConfigurationManager.AppSettings["USUS_ID"] = USUS_ID.ToString();
            System.Configuration.ConfigurationManager.AppSettings["USUS_Login"] = USUS_Login.ToString();
            System.Configuration.ConfigurationManager.AppSettings["USUS_Nombre"] = USUS_Nombre.ToString();
            System.Configuration.ConfigurationManager.AppSettings["USUS_CAR_ID"] = USUS_CAR_ID.ToString();
            System.Configuration.ConfigurationManager.AppSettings["USUS_CAR_Nombre"] = USUS_CAR_Nombre.ToString();
            System.Configuration.ConfigurationManager.AppSettings["USUS_Tipo"] = USUS_Tipo.ToString();

            return Redirect("/Home/Index"); ;
        }
    }
}
