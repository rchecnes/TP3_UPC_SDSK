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
        [ActionName("IngresarSistema")]
        public List<GM_Usuario> IngresarSistema(GM_Usuario entidad)
        {
            try
            {
                return ticketService.IngresarSistema(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
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
        [ActionName("ListadoMantenimiento")]
        public List<GM_Mantenimiento> ListadoMantenimiento()
        {
            try
            {
                return ticketService.ListadoMantenimiento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoDesarrollador")]
        public List<GM_Empleado> ListadoDesarrollador()
        {
            try
            {
                return ticketService.ListadoDesarrollador();
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
        [ActionName("InsertarActividad")]
        public void InsertarActividad(GM_Actividad entidad)
        {
            try
            {
                ticketService.InsertarActividad(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoActividad")]
        public List<GM_ListadoActividad> ListadoActividad(GM_Actividad entidad)
        {
            try
            {
                return ticketService.ListadoActividad(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarActividad")]
        public List<GM_ListadoActividad> EditarActividad(GM_Actividad entidad)
        {
            try
            {
                return ticketService.EditarActividad(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarActividad")]
        public void ActualizarActividad(GM_Actividad entidad)
        {
            try
            {
                ticketService.ActualizarActividad(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarActividad")]
        public void EliminarActividad(GM_Actividad entidad)
        {
            try
            {
                ticketService.EliminarActividad(entidad);
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

        [HttpPost]
        [ActionName("ListadoComentario")]
        public List<GM_Comentario> ListadoComentario(GM_Comentario entidad)
        {
            try
            {
                return ticketService.ListadoComentario(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("AsignarResponsableTicket")]
        public void AsignarResponsableTicket(GM_Ticket entidad)
        {
            try
            {
                ticketService.AsignarResponsableTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
