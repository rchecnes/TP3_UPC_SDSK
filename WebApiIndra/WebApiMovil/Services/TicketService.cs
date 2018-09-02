using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiIndra.Services
{
    public class TicketService
    {
        public List<Ticket> ListadoGrillaTicket(Ticket entidad)
        {
            List<Ticket> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY " + entidad.pvSortColumn + " " + entidad.pvSortOrder + ") as row FROM dbo.Ticket t " +
                                   "INNER JOIN Empresa em ON(t.TIC_EMP_ID=em.EMP_ID) " +
                                   "INNER JOIN UsuarioCliente uc ON(t.TIC_USU_ID=uc.USU_ID) " +
                                   "INNER JOIN Estado es ON(t.TIC_EST_ID=es.EST_ID) " +
                                   "INNER JOIN UsuarioResponsable ur ON(t.TIC_RES_ID=ur.RES_ID) " +
                                   "WHERE t.TIC_FlagActivo=1";

                    string condition = "";
                    if (entidad.TIC_ID != 0)
                    {
                        condition += " AND t.TIC_ID = " + entidad.TIC_ID;
                    }

                    if (entidad.EMP_RazonSocial != null)
                    {
                        condition += " AND (em.EMP_RazonSocial LIKE '%" + entidad.EMP_RazonSocial + "%')";
                    }
                    
                    if (entidad.TIC_FechaInicio != null && entidad.TIC_FechaFin != null)
                    {
                        condition += " AND t.TIC_FechaRegistro BETWEEN '"+ entidad.TIC_FechaInicio + "' AND '"+ entidad.TIC_FechaFin + "'";
                    }
                    else
                    {
                        if (entidad.TIC_FechaInicio != null)
                        {
                            condition += " AND t.TIC_FechaRegistro='" + entidad.TIC_FechaInicio + "'";
                        }
                        if (entidad.TIC_FechaFin != null)
                        {
                            condition += " AND t.TIC_FechaRegistro='" + entidad.TIC_FechaFin + "'";
                        }
                    }

                    if (entidad.TIC_EST_ID != 0)
                    {
                        condition += " AND t.TIC_EST_ID =" + entidad.TIC_EST_ID;
                    }

                    int inicio = 0;
                    int final = 0;
                    if (entidad.iCurrentPage == 0)
                    {
                        inicio = entidad.iCurrentPage * entidad.iPageSize;
                        final = entidad.iPageSize;
                    }
                    else
                    {
                        inicio = (entidad.iCurrentPage - 1) * entidad.iPageSize;
                        final = entidad.iCurrentPage * entidad.iPageSize;
                    }
                    string finquery = "SELECT * FROM (" + query + condition + ")a WHERE a.row >" + inicio + " and a.row <= " + final;

                    //Hacemos un conteo de los registro
                    int totRecord = 0;
                    string querytot = "SELECT COUNT(t.TIC_ID)AS Cantidad FROM dbo.Ticket t " +
                                   "INNER JOIN Empresa em ON(t.TIC_EMP_ID=em.EMP_ID) " +
                                   "INNER JOIN UsuarioCliente uc ON(t.TIC_USU_ID=uc.USU_ID) " +
                                   "INNER JOIN Estado es ON(t.TIC_EST_ID=es.EST_ID) " +
                                   "INNER JOIN UsuarioResponsable ur ON(t.TIC_RES_ID=ur.RES_ID) " +
                                   "WHERE t.TIC_FlagActivo=1";
                    using (SqlCommand command = new SqlCommand(querytot + condition, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                totRecord = dr.GetInt32(dr.GetOrdinal("Cantidad"));
                            }
                        }
                    }
                    //Fin totalizado

                    using (SqlCommand command = new SqlCommand(finquery, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ticket>();
                                while (dr.Read())
                                {
                                    Ticket item = new Ticket();
                                    item.TIC_ID = dr.GetInt32(dr.GetOrdinal("TIC_ID"));
                                    item.EMP_RazonSocial = dr.GetString(dr.GetOrdinal("EMP_RazonSocial"));
                                    item.USU_Nombre = dr.GetString(dr.GetOrdinal("USU_Nombre"));
                                    /*if (!dr.IsDBNull(dr.GetOrdinal("SOL_Descripcion")))
                                    {
                                        item.SOL_Descripcion = dr.GetString(dr.GetOrdinal("SOL_Descripcion"));
                                    }
                                    else
                                    {
                                        item.CAT_Descripcion = "";
                                    }*/
                                    item.TIC_FechaRegistro = dr.GetDateTime(dr.GetOrdinal("TIC_FechaRegistro")).ToString("dd/MM/yyyy");
                                    item.EST_Descrpcion = dr.GetString(dr.GetOrdinal("EST_Descripcion"));
                                    item.RES_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre"));

                                    string editar = "<a title='Editar' href='#' class='editar' id='" + item.TIC_ID + "'><span class='glyphicon glyphicon-edit fa-1x'></span></a>";                                    
                                    string abrir = "<a title='Abrir Ticket' href='#' class='abrir' id='" + item.TIC_ID + "'><span class='glyphicon glyphicon-ok fa-1x'></span></a>";
                                    string atencion = "<a title='Registrar Atención' href='#' class='atencion' id='" + item.TIC_ID + "'><span class='glyphicon glyphicon-th-list fa-1x'></span></a>";
                                    string historial = "<a title='Ver Historial del Ticket' href='#' class='historial' id='" + item.TIC_ID + "'><span class='glyphicon glyphicon-time fa-1x'></span></a>";

                                    item.ltAcciones = editar + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + abrir + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + atencion + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + historial;

                                    //Paginado
                                    item.sEcho = 2;
                                    item.draw = 0;//dr.GetInt32(dr.GetOrdinal("iCurrentPage"));
                                    item.iTotalRecords = totRecord;//dr.GetInt32(dr.GetOrdinal("iRecordCount"));
                                    item.iTotalDisplayRecords = totRecord;//dr.GetInt32(dr.GetOrdinal("iRecordCount"));

                                    Lista.Add(item);
                                }
                            }
                            else
                            {
                                Lista = new List<Ticket>();
                                Ticket item = new Ticket();
                                item.draw = 0;
                                item.iTotalRecords = 0;
                                item.iTotalDisplayRecords = 0;
                                Lista.Add(item);
                            }
                        }

                    }

                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<Estado> ListadoEstado()
        {
            List<Estado> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EstadoLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<Estado>();
                                while (dr.Read())
                                {
                                    Estado item = new Estado();
                                    item.EST_ID = dr.GetInt32(dr.GetOrdinal("EST_ID"));
                                    item.EST_Descripcion = dr.GetString(dr.GetOrdinal("EST_Descripcion"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<Prioridad> ListadoPrioridad()
        {
            List<Prioridad> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("PrioridadLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<Prioridad>();
                                while (dr.Read())
                                {
                                    Prioridad item = new Prioridad();
                                    item.PRI_ID = dr.GetInt32(dr.GetOrdinal("PRI_ID"));
                                    item.PRI_Descripcion = dr.GetString(dr.GetOrdinal("PRI_Descripcion"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<TipoSolucion> ListadoSolucion()
        {
            List<TipoSolucion> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SolucionLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion item = new TipoSolucion();
                                    item.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_ID"));
                                    item.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<Empresa> ListadoEmpresa(Empresa entidad)
        {
            List<Empresa> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Empresa WHERE EMP_RazonSocial LIKE '%" + entidad.EMP_RazonSocial+"%'", conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<Empresa>();
                                while (dr.Read())
                                {
                                    Empresa item = new Empresa();
                                    item.EMP_ID = dr.GetInt32(dr.GetOrdinal("EMP_ID"));
                                    item.EMP_RUC = dr.GetString(dr.GetOrdinal("EMP_RUC"));
                                    item.EMP_RazonSocial = dr.GetString(dr.GetOrdinal("EMP_RazonSocial"));
                                    item.label = dr.GetString(dr.GetOrdinal("EMP_RazonSocial"));
                                    item.value = dr.GetInt32(dr.GetOrdinal("EMP_ID"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<UsuarioCliente> ListadoUsuarioSolicitante(Empresa entidad)
        {
            List<UsuarioCliente> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM UsuarioCliente WHERE USU_EMP_ID="+entidad.EMP_ID, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<UsuarioCliente>();
                                while (dr.Read())
                                {
                                    UsuarioCliente item = new UsuarioCliente();
                                    item.USU_ID = dr.GetInt32(dr.GetOrdinal("USU_ID"));
                                    item.USU_Nombre = dr.GetString(dr.GetOrdinal("USU_Nombre"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<Servicio> ListadoServicio()
        {
            List<Servicio> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Servicio", conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<Servicio>();
                                while (dr.Read())
                                {
                                    Servicio item = new Servicio();
                                    item.SER_ID = dr.GetInt32(dr.GetOrdinal("SER_ID"));
                                    item.SER_Descripcion = dr.GetString(dr.GetOrdinal("SER_Descripcion"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<TipoSolucion> ListadoSelectTipoSolucion()
        {
            List<TipoSolucion> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM TipoSolucion WHERE SOL_FlagActivo=1", conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion item = new TipoSolucion();
                                    item.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_ID"));
                                    item.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<UsuarioResponsable> ListadoSelectUsuarioResponsable(UsuarioResponsable entidad)
        {
            List<UsuarioResponsable> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM UsuarioResponsable WHERE RES_FlagActivo=1 AND RES_Nombre LIKE '%"+entidad.RES_Nombre+"%'", conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<UsuarioResponsable>();
                                while (dr.Read())
                                {
                                    UsuarioResponsable item = new UsuarioResponsable();
                                    item.RES_ID = dr.GetInt32(dr.GetOrdinal("RES_ID"));
                                    item.RES_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre"));
                                    item.label = dr.GetString(dr.GetOrdinal("RES_Nombre"));
                                    item.value = dr.GetInt32(dr.GetOrdinal("RES_ID"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string InsertarTicket(Ticket entidad)
        {
            using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                conection.Open();
                SqlTransaction tran = conection.BeginTransaction();

                try
                {
                    
                    string sqltik = "INSERT INTO Ticket " +
                                    " (TIC_PRI_ID, TIC_PROB_ID, TIC_SER_ID, TIC_EMP_ID, TIC_USU_ID, TIC_RES_ID, TIC_Descripcion, TIC_FechaRegistro, TIC_EST_ID) VALUES" +
                                    "('" + entidad.TIC_PRI_ID + "', '" + entidad.TIC_PROB_ID + "','" + entidad.TIC_SER_ID + "','" + entidad.TIC_EMP_ID + "','" + entidad.TIC_USU_ID + "','" + entidad.TIC_RES_ID + "','" + entidad.TIC_Descripcion + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','1')";

                    using (SqlCommand command = new SqlCommand(sqltik, conection, tran))
                    {
                        command.ExecuteNonQuery();
                    }

                    //Consultamos id del ultimo ticket
                    int TIC_ID = 0;
                    string sqllastid = "SELECT MAX(TIC_ID)AS TIC_ID FROM Ticket";
                    using (SqlCommand command = new SqlCommand(sqllastid, conection, tran))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                TIC_ID = dr.GetInt32(dr.GetOrdinal("TIC_ID"));
                            }

                        }
                    }

                    //Insertamos el historico
                    string sqlhis = "INSERT INTO HistorialTicket " +
                                    "(HIS_TIC_ID,HIS_PRI_ID,HIS_RES_ID,HIS_FechaCambio,HIS_Descripcion)VALUES " +
                                    "('" + TIC_ID + "','"+entidad.TIC_PRI_ID+ "','" + entidad.TIC_RES_ID + "','"+ DateTime.Now.ToString("yyyy-MM-dd") + "','" + entidad.TIC_Descripcion +"')";
                    using (SqlCommand command = new SqlCommand(sqlhis, conection, tran))
                    {
                        command.ExecuteNonQuery();
                    }

                    tran.Commit();
                    conection.Close();
                    return "ok";
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    throw (ex);
                }
            }
        }
        public List<Ticket> EditarTicket(Ticket entidad)
        {
            List<Ticket> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string sqltik = "SELECT * FROM Ticket t " +
                                    " INNER JOIN UsuarioCliente uc ON(t.TIC_USU_ID=uc.USU_ID)"+
                                    " INNER JOIN Empresa em ON(t.TIC_EMP_ID=em.EMP_ID)" +
                                    " INNER JOIN UsuarioResponsable ur ON(t.TIC_RES_ID=ur.RES_ID)" +
                                    " WHERE TIC_ID=" + entidad.TIC_ID;

                    using (SqlCommand command = new SqlCommand(sqltik, conection))
                    {
                        
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ticket>();
                                while (dr.Read())
                                {
                                    Ticket item = new Ticket();
                                    item.TIC_ID = dr.GetInt32(dr.GetOrdinal("TIC_ID"));
                                    item.TIC_SER_ID = dr.GetInt32(dr.GetOrdinal("TIC_SER_ID"));
                                    item.TIC_PROB_ID = dr.GetInt32(dr.GetOrdinal("TIC_PROB_ID"));
                                    item.TIC_PRI_ID = dr.GetInt32(dr.GetOrdinal("TIC_PRI_ID"));
                                    item.TIC_RES_ID = dr.GetInt32(dr.GetOrdinal("TIC_RES_ID"));
                                    item.RES_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre"));
                                    item.TIC_Descripcion = dr.GetString(dr.GetOrdinal("TIC_Descripcion"));
                                    item.TIC_USU_ID = dr.GetInt32(dr.GetOrdinal("TIC_USU_ID"));
                                    item.USU_Nombre = dr.GetString(dr.GetOrdinal("USU_Nombre"));
                                    item.TIC_EMP_ID = dr.GetInt32(dr.GetOrdinal("TIC_EMP_ID"));
                                    item.EMP_RazonSocial = dr.GetString(dr.GetOrdinal("EMP_RazonSocial"));
                                    Lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string ActualizarTicket(Ticket entidad)
        {
            using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                conection.Open();
                SqlTransaction tran = conection.BeginTransaction();
                try
                {
                    string sqltik = "UPDATE Ticket " +
                                    " SET TIC_PRI_ID=" + entidad.TIC_PRI_ID + ", TIC_RES_ID=" + entidad.TIC_RES_ID + ", TIC_Descripcion='" + entidad.TIC_Descripcion + "'" +
                                    " WHERE TIC_ID=" + entidad.TIC_ID;

                    using (SqlCommand command = new SqlCommand(sqltik, conection, tran))
                    {
                        command.ExecuteNonQuery();
                    }

                    //Insertamos el historico
                    string sqlhis = "INSERT INTO HistorialTicket" +
                                    "(HIS_TIC_ID,HIS_PRI_ID,HIS_RES_ID,HIS_FechaCambio,HIS_Descripcion)VALUES" +
                                    "('" + entidad.TIC_ID + "','" + entidad.TIC_PRI_ID + "','" + entidad.TIC_RES_ID + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + entidad.TIC_Descripcion + "')";
                    using (SqlCommand command = new SqlCommand(sqlhis, conection, tran))
                    {
                        command.ExecuteNonQuery();
                    }

                    tran.Commit();
                    conection.Close();
                    return "ok";
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    throw (ex);
                }
            }
        }
        public List<TipoSolucion> ListadoTipoSolucionProblema(TipoSolucion entidad)
        {
            List<TipoSolucion> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM TipoSolucion WHERE SOL_PROB_ID="+entidad.SOL_PROB_ID, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion item = new TipoSolucion();
                                    item.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_ID"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_Nombre"))) {
                                        item.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_RutaArchivo")))
                                    {
                                        item.SOL_RutaArchivo = dr.GetString(dr.GetOrdinal("SOL_RutaArchivo"));
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_NombreArchivo")))
                                    {
                                        item.SOL_NombreArchivo = dr.GetString(dr.GetOrdinal("SOL_NombreArchivo"));
                                    }
                                    lista.Add(item);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<HistorialTicket> ListadoHistorialTicket(HistorialTicket entidad)
        {
            List<HistorialTicket> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string sql = "SELECT * FROM HistorialTicket ht " +
                                 "INNER JOIN Prioridad p ON(ht.HIS_PRI_ID=p.PRI_ID) " +
                                 "INNER JOIN UsuarioResponsable ur ON(ht.HIS_RES_ID=ur.RES_ID) " +
                                 "WHERE HIS_TIC_ID=" + entidad.HIS_TIC_ID;

                    using (SqlCommand command = new SqlCommand(sql, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<HistorialTicket>();
                                while (dr.Read())
                                {
                                    HistorialTicket item = new HistorialTicket();
                                    item.HIS_TIC_ID = dr.GetInt32(dr.GetOrdinal("HIS_TIC_ID"));
                                    item.PRI_Descripcion = dr.GetString(dr.GetOrdinal("PRI_Descripcion"));
                                    item.RES_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("HIS_Descripcion")))
                                    {
                                        item.HIS_Descripcion = dr.GetString(dr.GetOrdinal("HIS_Descripcion"));
                                    }
                                    item.HIS_FechaCambio = dr.GetDateTime(dr.GetOrdinal("HIS_FechaCambio")).ToString("dd/MM/yyyy");
                                    
                                    lista.Add(item);
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}