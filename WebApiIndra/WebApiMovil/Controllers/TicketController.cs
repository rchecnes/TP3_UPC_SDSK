using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApi.Controllers
{
    public class TicketController : System.Web.Http.ApiController
    {
        TicketService ticketService;

        public TicketController()
        {
            ticketService = new TicketService();
        }

        [HttpPost]
        [ActionName("ListadoEstado")]
        public List<GM_Estado> ListadoEstado()
        {
            try
            {
                return ticketService.ListadoEstado();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoTicket")]
        public List<GM_Ticket> ListadoTicket(GM_Ticket entidad)
        {
            try
            {
                return ticketService.ListadoTicket(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoServicio")]
        public List<GM_Empleado> ListadoServicio()
        {
            try
            {
                return ticketService.ListadoServicio();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoTipoProblema")]
        public List<GM_Empleado> ListadoTipoProblema()
        {
            try
            {
                return ticketService.ListadoTipoProblema();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoPrioridad")]
        public List<GM_Prioridad> ListadoPrioridad()
        {
            try
            {
                return ticketService.ListadoPrioridad();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarTicket")]
        public void InsertarTicket(GM_Ticket entidad)
        {
            try
            {
                ticketService.InsertarTicket(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarTicket")]
        public List<GM_Ticket> EditarTicket(GM_Ticket entidad)
        {
            try
            {
                return ticketService.EditarTicket(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarTicket")]
        public void ActualizarTicket(GM_Ticket entidad)
        {
            try
            {
                ticketService.ActualizarTicket(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
