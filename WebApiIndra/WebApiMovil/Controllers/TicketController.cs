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
        [ActionName("ListadoGrillaTicket")]
        public List<Ticket> ListadoGrillaTicket(Ticket entidad)
        {
            try
            {
                return ticketService.ListadoGrillaTicket(entidad);
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
        [ActionName("ListadoServicio")]
        public List<Servicio> ListadoServicio()
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

        [HttpPost]
        [ActionName("ListadoEmpresa")]
        public List<Empresa> ListadoEmpresa(Empresa entidad)
        {
            try
            {
                return ticketService.ListadoEmpresa(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoUsuarioSolicitante")]
        public List<UsuarioCliente> ListadoUsuarioSolicitante(Empresa entidad)
        {
            try
            {
                return ticketService.ListadoUsuarioSolicitante(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoSelectTipoSolucion")]
        public List<TipoSolucion> ListadoSelectTipoSolucion()
        {
            try
            {
                return ticketService.ListadoSelectTipoSolucion();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoSelectUsuarioResponsable")]
        public List<UsuarioResponsable> ListadoSelectUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                return ticketService.ListadoSelectUsuarioResponsable(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarTicket")]
        public string InsertarTicket(Ticket entidad)
        {
            try
            {
                return ticketService.InsertarTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarTicket")]
        public string ActualizarTicket(Ticket entidad)
        {
            try
            {
                return ticketService.ActualizarTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoTipoSolucionProblema")]
        public List<TipoSolucion> ListadoTipoSolucionProblema(TipoSolucion entidad)
        {
            try
            {
                return ticketService.ListadoTipoSolucionProblema(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoHistorialTicket")]
        public List<HistorialTicket> ListadoHistorialTicket(HistorialTicket entidad)
        {
            try
            {
                return ticketService.ListadoHistorialTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
