using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class TicketBL
    {

        private TicketDA ticketDA;

        public TicketBL()
        {
            ticketDA = new TicketDA();
        }

        public List<GM_Usuario> IngresarSistema(GM_Usuario entidad)
        {
            try
            {
                return ticketDA.IngresarSistema(entidad);
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
                return ticketDA.ListadoEstado();
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
                return ticketDA.ListadoMantenimiento();
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
                return ticketDA.ListadoDesarrollador();
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
                return ticketDA.ListadoPrioridad();
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
                return ticketDA.ListadoTicket(entidad);
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
                return ticketDA.EditarTicket(entidad);
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
                ticketDA.InsertarActividad(entidad);
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
                return ticketDA.ListadoActvidad(entidad);
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
                return ticketDA.EditarActividad(entidad);
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
                ticketDA.ActualizarActividad(entidad);
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
                ticketDA.EliminarActividad(entidad);
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
                ticketDA.ActualizarTicket(entidad);
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
                return ticketDA.ListadoComentario(entidad);
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
                ticketDA.AsignarResponsableTicket(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}