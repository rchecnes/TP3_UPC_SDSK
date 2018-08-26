using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Indra.Views
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/New
        public ActionResult Nuevo()
        {
            return View();
        }

       
        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
