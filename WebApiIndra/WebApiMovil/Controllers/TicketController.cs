using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Services;
using WebApiMovil.Models;
using WebApiIndra.Services;

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
        [ActionName("ListadoTicket")]
        public List<Ticket> ListadoTicket(Ticket entidad)
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
        [ActionName("ListadoPrioridad")]
        public List<Prioridad> ListadoPrioridad()
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
        [ActionName("ListadoEstado")]
        public List<Estado> ListadoEstado()
        {
            try
            {
                return ticketService.ListadoEstado();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoSolucion")]
        public List<TipoSolucion> ListadoSolucion()
        {
            try
            {
                return ticketService.ListadoSolucion();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarTicket")]
        public List<Ticket> EditarTicket(Ticket entidad)
        {
            try
            {
                return ticketService.EditarTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}
