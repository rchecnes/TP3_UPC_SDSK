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
    public class TipoSolucionService
    {
        /*public List<TipoSolucion> ListadoTipoSolucion(TipoSolucion entidad)
        {
            List<TipoSolucion> ListaBase = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM dbo.TipoSolucion ts " +
                                   "INNER JOIN Categoria c ON(ts.SOL_CAT_ID=c.CAT_ID) "+
                                   "WHERE ts.SOL_Id <> 0";

                    if (entidad.SOL_CAT_ID != 0)
                    {
                        query += " AND ts.SOL_CAT_ID = " + entidad.SOL_CAT_ID;
                    }

                    if (entidad.SOL_Nombre != null)
                    {
                        query += " AND (ts.SOL_Nombre LIKE '%" + entidad.SOL_Nombre + "%' OR ts.SOL_ID LIKE '%" + entidad.SOL_Nombre + "%')";
                    }

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaBase = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion tiposol = new TipoSolucion();
                                    tiposol.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_Id"));
                                    tiposol.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    tiposol.CAT_Descripcion = dr.GetString(dr.GetOrdinal("CAT_Descripcion"));
                                    tiposol.SOL_RutaArchivo = dr.GetString(dr.GetOrdinal("SOL_RutaArchivo"));
                                    tiposol.SOL_FechaCreacion = dr.GetDateTime(dr.GetOrdinal("SOL_FechaCreacion")).ToString("dd/MM/yyyy");
                                    tiposol.SOL_UsuarioCreacion = dr.GetString(dr.GetOrdinal("SOL_UsuarioCreacion"));

                                    ListaBase.Add(tiposol);
                                }
                            }
                        }

                    }

                    conection.Close();
                }
                return ListaBase;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }*/
        public List<TipoSolucion> ListadoTipoSolucion(TipoSolucion entidad)
        {
            List<TipoSolucion> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY CAT_ID asc) as row FROM dbo.TipoSolucion ts " +
                                   "INNER JOIN Categoria c ON(ts.SOL_CAT_ID=c.CAT_ID) " +
                                   "WHERE ts.SOL_Id <> 0";

                    if (entidad.SOL_CAT_ID != 0)
                    {
                        query += " AND ts.SOL_CAT_ID = " + entidad.SOL_CAT_ID;
                    }

                    if (entidad.SOL_Nombre != null)
                    {
                        query += " AND (ts.SOL_Nombre LIKE '%" + entidad.SOL_Nombre + "%' OR ts.SOL_ID LIKE '%" + entidad.SOL_Nombre + "%')";
                    }

                    string finquery = "SELECT * FROM ("+ query+ ")a WHERE a.row >" + entidad.iCurrentPage + " and a.row <= " + entidad.iPageSize;

                    using (SqlCommand command = new SqlCommand(finquery, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion item = new TipoSolucion();
                                    item.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_Id"));
                                    item.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    item.CAT_Descripcion = dr.GetString(dr.GetOrdinal("CAT_Descripcion"));
                                    item.SOL_RutaArchivo = dr.GetString(dr.GetOrdinal("SOL_RutaArchivo"));
                                    item.SOL_FechaCreacion = dr.GetDateTime(dr.GetOrdinal("SOL_FechaCreacion")).ToString("dd/MM/yyyy");
                                    item.SOL_UsuarioCreacion = dr.GetString(dr.GetOrdinal("SOL_UsuarioCreacion"));

                                    //Paginado
                                    item.sEcho = 1;
                                    item.draw = 2;//dr.GetInt32(dr.GetOrdinal("iCurrentPage"));
                                    item.iTotalRecords = 20;//dr.GetInt32(dr.GetOrdinal("iRecordCount"));
                                    item.iTotalDisplayRecords = 20;//dr.GetInt32(dr.GetOrdinal("iRecordCount"));

                                    Lista.Add(item);
                                }
                            }
                            else
                            {
                                Lista = new List<TipoSolucion>();
                                TipoSolucion item = new TipoSolucion();
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
        public List<Categoria> ListadoCategoria()
        {
            List<Categoria> ListaCategoria = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("CategoriaLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaCategoria = new List<Categoria>();
                                while (dr.Read())
                                {
                                    Categoria estado = new Categoria();
                                    estado.CAT_ID = dr.GetInt32(dr.GetOrdinal("CAT_ID"));
                                    estado.CAT_Descripcion = dr.GetString(dr.GetOrdinal("CAT_Descripcion"));
                                    ListaCategoria.Add(estado);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaCategoria;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<TipoProblema> ListadoTipoProblema()
        {
            List<TipoProblema> ListaTipoProblema = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("TipoProblemaLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaTipoProblema = new List<TipoProblema>();
                                while (dr.Read())
                                {
                                    TipoProblema problema = new TipoProblema();
                                    problema.PROB_ID = dr.GetInt32(dr.GetOrdinal("PROB_Id"));
                                    problema.PROB_Descripcion = dr.GetString(dr.GetOrdinal("PROB_Descripcion"));
                                    ListaTipoProblema.Add(problema);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaTipoProblema;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string InsertarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("InsertarTipoSolucion", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SOL_Nombre", entidad.SOL_Nombre);
                        command.Parameters.AddWithValue("@SOL_RutaArchivo", "/PRUAB");
                        command.Parameters.AddWithValue("@SOL_NombreArchivo", "PRUEBA");
                        command.Parameters.AddWithValue("@SOL_Descripcion", entidad.SOL_Descripcion);
                        command.Parameters.AddWithValue("@SOL_PalabraClave", entidad.SOL_PalabraClave);
                        command.Parameters.AddWithValue("@SOL_Comentario", entidad.SOL_Comentario);
                        command.Parameters.AddWithValue("@SOL_FechaCreacion", DateTime.Now);
                        command.Parameters.AddWithValue("@SOL_UsuarioCreacion", "RCHECNES");
                        command.Parameters.AddWithValue("@SOL_PROB_ID", entidad.SOL_PROB_ID);
                        command.Parameters.AddWithValue("@SOL_CAT_ID", entidad.SOL_CAT_ID);
                        command.ExecuteNonQuery();
                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return "ok";
        }
        public List<TipoSolucion> EditarTipoSolucion(TipoSolucion entidad)
        {
            List<TipoSolucion> ListaTipoSolucion = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EditarTipoSolucion", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SOL_ID", entidad.SOL_ID);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaTipoSolucion = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion tiposol = new TipoSolucion();
                                    tiposol.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_ID"));
                                    tiposol.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_Descripcion")))
                                    {
                                        tiposol.SOL_Descripcion = dr.GetString(dr.GetOrdinal("SOL_Descripcion"));
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_PalabraClave")))
                                    {
                                        tiposol.SOL_PalabraClave = dr.GetString(dr.GetOrdinal("SOL_PalabraClave"));
                                    }
                                    tiposol.SOL_CAT_ID = dr.GetInt32(dr.GetOrdinal("SOL_CAT_ID"));
                                    tiposol.SOL_PROB_ID = dr.GetInt32(dr.GetOrdinal("SOL_PROB_ID"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_RutaArchivo")))
                                    {
                                        tiposol.SOL_RutaArchivo = dr.GetString(dr.GetOrdinal("SOL_RutaArchivo"));
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_NombreArchivo")))
                                    {
                                        tiposol.SOL_NombreArchivo = dr.GetString(dr.GetOrdinal("SOL_NombreArchivo"));
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_Comentario")))
                                    {
                                        tiposol.SOL_Comentario = dr.GetString(dr.GetOrdinal("SOL_Comentario"));
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_FechaCreacion")))
                                    {
                                        tiposol.SOL_FechaCreacion = dr.GetDateTime(dr.GetOrdinal("SOL_FechaCreacion")).ToString("dd/MM/yyyy");
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_FechaModificacion")))
                                    {
                                        tiposol.SOL_FechaModificacion = dr.GetDateTime(dr.GetOrdinal("SOL_FechaModificacion")).ToString("dd/MM/yyyy");
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_UsuarioCreacion")))
                                    {
                                        tiposol.SOL_UsuarioCreacion = dr.GetString(dr.GetOrdinal("SOL_UsuarioCreacion"));
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_UsuarioModificacion")))
                                    {
                                        tiposol.SOL_UsuarioModificacion = dr.GetString(dr.GetOrdinal("SOL_UsuarioModificacion"));
                                    }

                                    ListaTipoSolucion.Add(tiposol);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return ListaTipoSolucion;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string ActualizarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarTipoSolucion", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SOL_ID", entidad.SOL_ID);
                        command.Parameters.AddWithValue("@SOL_Descripcion", entidad.SOL_Descripcion);
                        command.Parameters.AddWithValue("@SOL_PalabraClave", entidad.SOL_PalabraClave);
                        command.Parameters.AddWithValue("@SOL_CAT_ID", entidad.SOL_CAT_ID);
                        command.Parameters.AddWithValue("@SOL_PROB_ID", entidad.SOL_PROB_ID);
                        command.Parameters.AddWithValue("@SOL_FechaModificacion", DateTime.Now);
                        command.Parameters.AddWithValue("@SOL_UsuarioModificacion", "RCHECNES");
                        command.ExecuteNonQuery();
                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return "ok";
        }
    }
}