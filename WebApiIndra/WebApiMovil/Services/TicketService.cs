using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class TicketService
    {
        private TicketBL ticketBL;

        public TicketService()
        {
            ticketBL = new TicketBL();
        }

        public List<GM_Usuario> IngresarSistema(GM_Usuario entidad)
        {
            try
            {
                return ticketBL.IngresarSistema(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<GM_Estado> ListadoEstado()
        {
            try
            {
                return ticketBL.ListadoEstado();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_Mantenimiento> ListadoMantenimiento()
        {
            try
            {
                return ticketBL.ListadoMantenimiento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_Empleado> ListadoDesarrollador()
        {
            try
            {
                return ticketBL.ListadoDesarrollador();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_Prioridad> ListadoPrioridad()
        {
            try
            {
                return ticketBL.ListadoPrioridad();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_Ticket> ListadoTicket(GM_Ticket entidad)
        {
            try
            {
                return ticketBL.ListadoTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<GM_Ticket> EditarTicket(GM_Ticket entidad)
        {
            try
            {
                return ticketBL.EditarTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertarActividad(GM_Actividad entidad)
        {
            try
            {
                ticketBL.InsertarActividad(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_ListadoActividad> ListadoActividad(GM_Actividad entidad)
        {
            try
            {
                return ticketBL.ListadoActividad(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_ListadoActividad> EditarActividad(GM_Actividad entidad)
        {
            try
            {
                return ticketBL.EditarActividad(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ActualizarActividad(GM_Actividad entidad)
        {
            try
            {
                ticketBL.ActualizarActividad(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EliminarActividad(GM_Actividad entidad)
        {
            try
            {
                ticketBL.EliminarActividad(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ActualizarTicket(GM_Ticket entidad)
        {
            try
            {
                ticketBL.ActualizarTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GM_Comentario> ListadoComentario(GM_Comentario entidad)
        {
            try
            {
                return ticketBL.ListadoComentario(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AsignarResponsableTicket(GM_Ticket entidad)
        {
            try
            {
                ticketBL.AsignarResponsableTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}