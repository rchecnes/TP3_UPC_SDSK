using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.DataLayer
{
    public class TicketDA
    {
        public List<GM_Usuario> IngresarSistema(GM_Usuario entidad)
        {
            List<GM_Usuario> ListaUsuario = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM dbo.GM_Usuario u" +
                        " INNER JOIN  dbo.GM_Empleado em on(u.IdEmpleado = em.IdEmpleado)" +
                        " INNER JOIN  dbo.GM_Rol r on(u.IdRol = r.IdRol)" +
                        " WHERE u.NameUsuario='"+entidad.NameUsuario+"'" +
                        " AND u.PasUsuario='"+ entidad.PasUsuario + "'";
                    
                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaUsuario = new List<GM_Usuario>();
                                while (dr.Read())
                                {
                                    GM_Usuario usuario = new GM_Usuario();
                                    usuario.IdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"));
                                    usuario.IdRol = dr.GetInt32(dr.GetOrdinal("IdRol"));
                                    usuario.IdEmpleado = dr.GetInt32(dr.GetOrdinal("IdEmpleado"));
                                    usuario.NomEmpleado = dr.GetString(dr.GetOrdinal("NomEmpleado"));
                                    usuario.NomRol = dr.GetString(dr.GetOrdinal("NomRol"));

                                    ListaUsuario.Add(usuario);
                                }
                            }
                        }

                    }

                    conection.Close();
                }
                return ListaUsuario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<GM_Estado> ListadoEstado()
        {
            List<GM_Estado> ListaEstado = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ListarEstado", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaEstado = new List<GM_Estado>();
                                while (dr.Read())
                                {
                                    GM_Estado estado = new GM_Estado();
                                    estado.IdEstado = dr.GetInt32(dr.GetOrdinal("IdEstado"));
                                    estado.NomEstado = dr.GetString(dr.GetOrdinal("NomEstado"));
                                    ListaEstado.Add(estado);
                                }
                            }
                            else
                            {
                                ListaEstado = new List<GM_Estado>();
                                GM_Estado estado = new GM_Estado();
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaEstado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<GM_Mantenimiento> ListadoMantenimiento()
        {
            List<GM_Mantenimiento> ListaMantenimiento = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ListarMantenimiento", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaMantenimiento = new List<GM_Mantenimiento>();
                                while (dr.Read())
                                {
                                    GM_Mantenimiento estado = new GM_Mantenimiento();
                                    estado.IdMantenimiento = dr.GetInt32(dr.GetOrdinal("IdMantenimiento"));
                                    estado.NomMantenimiento = dr.GetString(dr.GetOrdinal("NomMantenimiento"));
                                    ListaMantenimiento.Add(estado);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaMantenimiento;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<GM_Empleado> ListadoDesarrollador()
        {
            List<GM_Empleado> ListaEmpleado = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ListarDesarrollador", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaEmpleado = new List<GM_Empleado>();
                                while (dr.Read())
                                {
                                    GM_Empleado estado = new GM_Empleado();
                                    estado.IdEmpleado = dr.GetInt32(dr.GetOrdinal("IdEmpleado"));
                                    estado.NomEmpleado = dr.GetString(dr.GetOrdinal("NomEmpleado"));
                                    ListaEmpleado.Add(estado);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaEmpleado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<GM_Prioridad> ListadoPrioridad()
        {
            List<GM_Prioridad> ListaPrioridad = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ListarPrioridad", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaPrioridad = new List<GM_Prioridad>();
                                while (dr.Read())
                                {
                                    GM_Prioridad prioridad = new GM_Prioridad();
                                    prioridad.IdPrioridad = dr.GetInt32(dr.GetOrdinal("IdPrioridad"));
                                    prioridad.NomPrioridad = dr.GetString(dr.GetOrdinal("NomPrioridad"));
                                    ListaPrioridad.Add(prioridad);
                                }
                            }
                            else
                            {
                                ListaPrioridad = new List<GM_Prioridad>();
                                GM_Prioridad prioridad = new GM_Prioridad();
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaPrioridad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<GM_Ticket> ListadoTicket(GM_Ticket entidad)
        {
            List<GM_Ticket> ListaTicket = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM dbo.GM_Ticket t" +
                        " INNER JOIN  dbo.GM_Estado s on(t.IdEstado = s.IdEstado)" +
                        " INNER JOIN  dbo.GM_Proyecto pr on(t.IdProyecto = pr.IdProyecto)" +
                        " INNER JOIN  dbo.GM_Cliente cl on(pr.IdCliente = cl.IdCliente)" +
                        " LEFT JOIN dbo.GM_Prioridad p on(t.IdPrioridad = p.IdPrioridad)" +
                        " LEFT JOIN  dbo.GM_Mantenimiento m on(t.IdMantenimiento = m.IdMantenimiento)" +
                        " LEFT JOIN  dbo.GM_Empleado em on(t.IdEmpleado = em.IdEmpleado)" +
                        " WHERE t.IdTicket<>0";

                    if (entidad.IdRol != 1)
                    {
                        query += " AND t.IdEmpleado = "+entidad.IdEmpleado;
                    }
                    
                    if (entidad.NomCliente != null)
                    {
                        query += " AND (cl.NomCliente LIKE '%" + entidad.NomCliente + "%' OR t.IdTicket LIKE '%"+ entidad.NomCliente + "%')";
                    }
                    if (entidad.IdEstado != 0)
                    {
                        query += " AND t.IdEstado = " + entidad.IdEstado;
                    }
                    if (entidad.IdPrioridad != 0)
                    {
                        query += " AND t.IdPrioridad = " + entidad.IdPrioridad;
                    }

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaTicket = new List<GM_Ticket>();
                                while (dr.Read())
                                {
                                    GM_Ticket ticket = new GM_Ticket();
                                    ticket.IdTicket = dr.GetInt32(dr.GetOrdinal("IdTicket"));
                                    ticket.FeCreTicket = dr.GetDateTime(dr.GetOrdinal("FeCreTicket")).ToString("dd/MM/yyyy");
                                    ticket.NomCliente = dr.GetString(dr.GetOrdinal("NomCliente"));
                                    ticket.NomEstado = dr.GetString(dr.GetOrdinal("NomEstado"));
                                    ticket.NomProyecto = dr.GetString(dr.GetOrdinal("NomProyecto"));

                                    if (!dr.IsDBNull(dr.GetOrdinal("NomMantenimiento")))
                                    {
                                        ticket.NomMantenimiento = dr.GetString(dr.GetOrdinal("NomMantenimiento"));
                                    }
                                    else
                                    {
                                        ticket.NomMantenimiento = "Ninguno";
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("NomPrioridad")))
                                    {
                                        ticket.NomPrioridad = dr.GetString(dr.GetOrdinal("NomPrioridad"));
                                    }
                                    else
                                    {
                                        ticket.NomPrioridad = "Ninguno";
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("NomEmpleado")))
                                    {
                                        ticket.NomEmpleado = dr.GetString(dr.GetOrdinal("NomEmpleado"));
                                        ticket.IdEmpleado = dr.GetInt32(dr.GetOrdinal("IdEmpleado"));
                                    }
                                    else
                                    {
                                        ticket.NomEmpleado = "Ninguno";
                                        ticket.IdEmpleado = 0;
                                    }

                                    ListaTicket.Add(ticket);
                                }
                            }
                        }

                    }
                    
                    conection.Close();
                }
                return ListaTicket;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<GM_Ticket> EditarTicket(GM_Ticket entidad)
        {
            List<GM_Ticket> ListaTicket = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EditarTicket", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaTicket = new List<GM_Ticket>();
                                while (dr.Read())
                                {
                                    GM_Ticket ticket = new GM_Ticket();
                                    ticket.IdTicket = dr.GetInt32(dr.GetOrdinal("IdTicket"));
                                    ticket.FeCreTicket = dr.GetDateTime(dr.GetOrdinal("FeCreTicket")).ToString("yyyy/MM/dd");
                                    ticket.FeEnTicket = dr.GetDateTime(dr.GetOrdinal("FeEnTicket")).ToString("yyyy/MM/dd");
                                    ticket.NomCliente = dr.GetString(dr.GetOrdinal("NomCliente"));
                                    ticket.IdEstado = dr.GetInt32(dr.GetOrdinal("IdEstado"));
                                    ticket.NomEstado = dr.GetString(dr.GetOrdinal("NomEstado"));
                                    ticket.NomProyecto = dr.GetString(dr.GetOrdinal("NomProyecto"));
                                    
                                    if (!dr.IsDBNull(dr.GetOrdinal("NomMantenimiento")))
                                    {
                                        ticket.IdMantenimiento = dr.GetInt32(dr.GetOrdinal("IdMantenimiento"));
                                        ticket.NomMantenimiento = dr.GetString(dr.GetOrdinal("NomMantenimiento"));
                                    }
                                    else
                                    {
                                        ticket.IdMantenimiento = 0;
                                        ticket.NomMantenimiento = "Ninguno";
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("NomPrioridad")))
                                    {
                                        ticket.IdPrioridad = dr.GetInt32(dr.GetOrdinal("IdPrioridad"));
                                        ticket.NomPrioridad = dr.GetString(dr.GetOrdinal("NomPrioridad"));
                                    }
                                    else
                                    {
                                        ticket.IdPrioridad = 0;
                                        ticket.NomPrioridad = "Ninguno";
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("NomEmpleado")))
                                    {
                                        ticket.NomEmpleado = dr.GetString(dr.GetOrdinal("NomEmpleado"));
                                        ticket.IdEmpleado = dr.GetInt32(dr.GetOrdinal("IdEmpleado"));
                                    }
                                    else
                                    {
                                        ticket.NomEmpleado = "Ninguno";
                                        ticket.IdEmpleado = 0;
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("NomAdjunto")))
                                    {
                                        ticket.IdAdjunto = dr.GetInt32(dr.GetOrdinal("IdAdjunto"));
                                        ticket.NomAdjunto = dr.GetString(dr.GetOrdinal("NomAdjunto"));
                                        ticket.RutaAdjunto = dr.GetString(dr.GetOrdinal("RutaAdjunto"));
                                    }
                                    else
                                    {
                                        ticket.IdAdjunto = 0;
                                        ticket.NomAdjunto = "Sin Adjunto";
                                        ticket.RutaAdjunto = null;
                                    }

                                    ticket.DesTicket = dr.GetString(dr.GetOrdinal("DesTicket"));

                                    ListaTicket.Add(ticket);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaTicket;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertarActividad(GM_Actividad entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("InsertarActividad", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NomActividad", entidad.NomActividad);
                        command.Parameters.AddWithValue("@PorAvanActividad", entidad.PorAvanActividad);
                        command.Parameters.AddWithValue("@DurActividad", entidad.DurActividad);
                        command.Parameters.AddWithValue("@FeCreActividad", DateTime.Now);
                        command.Parameters.AddWithValue("@FeIniActividad", entidad.FeIniActividad);
                        command.Parameters.AddWithValue("@FeFinActividad", entidad.FeFinActividad);
                        command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);
                        command.Parameters.AddWithValue("@IdCreEmpleado", entidad.IdCreEmpleado);
                        command.ExecuteNonQuery();                            
                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<GM_ListadoActividad> ListadoActvidad(GM_Actividad entidad)
        {
            List<GM_ListadoActividad> ListaActividad = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ListarActividad", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaActividad = new List<GM_ListadoActividad>();
                                while (dr.Read())
                                {
                                    GM_ListadoActividad actividad = new GM_ListadoActividad();
                                    actividad.IdActividad = dr.GetInt32(dr.GetOrdinal("IdActividad"));
                                    actividad.NomActividad = dr.GetString(dr.GetOrdinal("NomActividad"));
                                    actividad.DurActividad = Convert.ToDecimal(dr["DurActividad"]);
                                    actividad.FeIniActividad = dr.GetDateTime(dr.GetOrdinal("FeIniActividad")).ToString("dd/MM/yyyy");
                                    actividad.FeFinActividad = dr.GetDateTime(dr.GetOrdinal("FeFinActividad")).ToString("dd/MM/yyyy");
                                    actividad.PorAvanActividad = Convert.ToDecimal(dr["PorAvanActividad"]);
                                    ListaActividad.Add(actividad);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaActividad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<GM_ListadoActividad> EditarActividad(GM_Actividad entidad)
        {
            List<GM_ListadoActividad> ListaActividad = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EditarActividad", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdActividad", entidad.IdActividad);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaActividad = new List<GM_ListadoActividad>();
                                while (dr.Read())
                                {
                                    GM_ListadoActividad actividad = new GM_ListadoActividad();
                                    actividad.IdActividad = dr.GetInt32(dr.GetOrdinal("IdActividad"));
                                    actividad.NomActividad = dr.GetString(dr.GetOrdinal("NomActividad"));
                                    actividad.DurActividad = Convert.ToDecimal(dr["DurActividad"]);
                                    actividad.FeIniActividad = dr.GetDateTime(dr.GetOrdinal("FeIniActividad")).ToString("dd/MM/yyyy");
                                    actividad.FeFinActividad = dr.GetDateTime(dr.GetOrdinal("FeFinActividad")).ToString("dd/MM/yyyy");
                                    actividad.PorAvanActividad = Convert.ToDecimal(dr["PorAvanActividad"]);

                                    ListaActividad.Add(actividad);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaActividad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ActualizarActividad(GM_Actividad entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarActividad", conection))
                    {
                        DateTime FeIniActividad = DateTime.Parse(entidad.FeIniActividad);
                        DateTime FeFinActividad = DateTime.Parse(entidad.FeFinActividad);

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdActividad", entidad.IdActividad);
                        command.Parameters.AddWithValue("@NomActividad", entidad.NomActividad);
                        command.Parameters.AddWithValue("@DurActividad", entidad.DurActividad);
                        command.Parameters.AddWithValue("@FeIniActividad", FeIniActividad);
                        command.Parameters.AddWithValue("@FeFinActividad", FeFinActividad);
                        command.Parameters.AddWithValue("@IdModEmpleado", entidad.IdModEmpleado);
                        command.ExecuteNonQuery();
                    }
                    conection.Close();
                }
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
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarActividad", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdActividad", entidad.IdActividad);
                        command.ExecuteNonQuery();
                    }
                    conection.Close();
                }
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
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    int IdEstado = entidad.IdEstado;

                    if (entidad.EnvCalidad==1)
                    {
                        IdEstado = 4;// En Revision
                    }

                    using (SqlCommand command = new SqlCommand("ActualizarTicket", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);
                        command.Parameters.AddWithValue("@IdEstado", IdEstado);
                        command.ExecuteNonQuery();
                    }

                    if (entidad.DesComentario !="" && entidad.DesComentario != null)
                    {
                        using (SqlCommand command = new SqlCommand("InsertarComentario", conection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@DesComentario", entidad.DesComentario);
                            command.Parameters.AddWithValue("@FeCreComentario", DateTime.Now);
                            command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);
                            command.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                            command.ExecuteNonQuery();
                        }
                    }
                    conection.Close();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<GM_Comentario> ListadoComentario(GM_Comentario entidad)
        {
            List<GM_Comentario> ListaComentario = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();
                    
                    using (SqlCommand command = new SqlCommand("ListarComentario", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaComentario = new List<GM_Comentario>();
                                while (dr.Read())
                                {
                                    GM_Comentario coment = new GM_Comentario();
                                    coment.IdComentario = dr.GetInt32(dr.GetOrdinal("IdComentario"));
                                    coment.DesComentario = dr.GetString(dr.GetOrdinal("DesComentario"));
                                    coment.FeCreComentario = dr.GetDateTime(dr.GetOrdinal("FeCreComentario")).ToString("dd/MM/yyyy");
                                    coment.IdTicket = dr.GetInt32(dr.GetOrdinal("IdTicket"));
                                    coment.IdEmpleado = dr.GetInt32(dr.GetOrdinal("IdEmpleado"));
                                    coment.NomEmpleado = dr.GetString(dr.GetOrdinal("NomEmpleado"));
                                    ListaComentario.Add(coment);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaComentario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AsignarResponsableTicket(GM_Ticket entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();
                    
                    using (SqlCommand command = new SqlCommand("AsignarResponsableTicket", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdTicket", entidad.IdTicket);
                        command.Parameters.AddWithValue("@FeEnTicket", entidad.FeEnTicket);
                        command.Parameters.AddWithValue("@IdMantenimiento", entidad.IdMantenimiento);
                        command.Parameters.AddWithValue("@IdPrioridad", entidad.IdPrioridad);
                        command.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                        command.Parameters.AddWithValue("@IdEstado", 2);
                        command.ExecuteNonQuery();
                    }
                    
                    conection.Close();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}