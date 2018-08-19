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
        public List<TipoSolucion> ListadoTipoSolucion(TipoSolucion entidad)
        {
            List<TipoSolucion> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY "+ entidad.pvSortColumn + " "+ entidad.pvSortOrder + ") as row FROM dbo.TipoSolucion ts " +
                                   "INNER JOIN Categoria c ON(ts.SOL_CAT_ID=c.CAT_ID) " +
                                   "WHERE ts.SOL_Id <> 0 AND ts.SOL_FlagActivo=1";

                    string condition = "";
                    if (entidad.SOL_CAT_ID != 0)
                    {
                        condition += " AND ts.SOL_CAT_ID = " + entidad.SOL_CAT_ID;
                    }

                    if (entidad.SOL_Nombre != null)
                    {
                        condition += " AND (ts.SOL_Nombre LIKE '%" + entidad.SOL_Nombre + "%' OR ts.SOL_ID LIKE '%" + entidad.SOL_Nombre + "%')";
                    }

                    int inicio = 0;
                    int final = 0;
                    if (entidad.iCurrentPage==0)
                    {
                        inicio = entidad.iCurrentPage * entidad.iPageSize;
                        final = entidad.iPageSize;
                    }
                    else
                    {
                        inicio = (entidad.iCurrentPage - 1) * entidad.iPageSize;
                        final = entidad.iCurrentPage * entidad.iPageSize;
                    }
                    string finquery = "SELECT * FROM ("+ query + condition +")a WHERE a.row >" + inicio + " and a.row <= " + final;

                    //Hacemos un conteo de los registro
                    int totRecord = 0;
                    string querytot = "SELECT COUNT(ts.SOL_ID)AS Cantidad FROM dbo.TipoSolucion ts " +
                                      "INNER JOIN Categoria c ON(ts.SOL_CAT_ID=c.CAT_ID) " +
                                      "WHERE ts.SOL_Id <> 0 AND ts.SOL_FlagActivo=1 ";
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
                                Lista = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion item = new TipoSolucion();
                                    item.SOL_ID = dr.GetInt32(dr.GetOrdinal("SOL_Id"));
                                    item.SOL_Nombre = dr.GetString(dr.GetOrdinal("SOL_Nombre"));
                                    item.CAT_Descripcion = dr.GetString(dr.GetOrdinal("CAT_Descripcion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_Descripcion")))
                                    {
                                        item.SOL_Descripcion = dr.GetString(dr.GetOrdinal("SOL_Descripcion"));
                                    }else {
                                        item.CAT_Descripcion = "";
                                    }
                                    if (!dr.IsDBNull(dr.GetOrdinal("SOL_RutaArchivo")))
                                    {
                                        item.SOL_RutaArchivo = dr.GetString(dr.GetOrdinal("SOL_RutaArchivo"));
                                    }
                                    else
                                    {
                                        item.SOL_RutaArchivo = "";
                                    }
                                    item.SOL_FechaCreacion = dr.GetDateTime(dr.GetOrdinal("SOL_FechaCreacion")).ToString("dd/MM/yyyy");
                                    item.SOL_UsuarioCreacion = dr.GetString(dr.GetOrdinal("SOL_UsuarioCreacion"));

                                    string editar = "<a title='Editar' href='#' class='editar' id='" + item.SOL_ID + "'><span class='glyphicon glyphicon-edit fa-1x'></span></a>"; ;
                                    string eliminar = "<a title='Eliminar' href='#' class='eliminar' id='" + item.SOL_ID + "'><span class='glyphicon glyphicon-trash fa-1x'></span></a>"; ;

                                    item.ltAcciones = editar + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + eliminar;

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

                        string descripcion = (entidad.SOL_Descripcion != null) ? entidad.SOL_Descripcion : "";
                        string palabraclave = (entidad.SOL_PalabraClave != null) ? entidad.SOL_PalabraClave : "";
                        string comentario = (entidad.SOL_Comentario != null) ? entidad.SOL_Comentario : "";
                        string rutaarchivo = (entidad.SOL_RutaArchivo != null) ? entidad.SOL_RutaArchivo : "";
                        string nombrearchivo = (entidad.SOL_NombreArchivo != null) ? entidad.SOL_NombreArchivo : "";

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SOL_Nombre", entidad.SOL_Nombre);
                        command.Parameters.AddWithValue("@SOL_RutaArchivo", rutaarchivo);
                        command.Parameters.AddWithValue("@SOL_NombreArchivo", nombrearchivo);
                        command.Parameters.AddWithValue("@SOL_Descripcion", descripcion);
                        command.Parameters.AddWithValue("@SOL_PalabraClave", palabraclave);
                        command.Parameters.AddWithValue("@SOL_Comentario", comentario);
                        command.Parameters.AddWithValue("@SOL_FechaCreacion", DateTime.Now);
                        command.Parameters.AddWithValue("@SOL_UsuarioCreacion", "DGUTIERREZ");
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
                        string descripcion = (entidad.SOL_Descripcion != null) ? entidad.SOL_Descripcion : "";
                        string palabraclave = (entidad.SOL_PalabraClave != null) ? entidad.SOL_PalabraClave : "";

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SOL_ID", entidad.SOL_ID);
                        command.Parameters.AddWithValue("@SOL_Descripcion", descripcion);
                        command.Parameters.AddWithValue("@SOL_PalabraClave", palabraclave);
                        command.Parameters.AddWithValue("@SOL_CAT_ID", entidad.SOL_CAT_ID);
                        command.Parameters.AddWithValue("@SOL_PROB_ID", entidad.SOL_PROB_ID);
                        command.Parameters.AddWithValue("@SOL_FechaModificacion", DateTime.Now);
                        command.Parameters.AddWithValue("@SOL_UsuarioModificacion", "EGUTIERREZ");
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

        public string EliminarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarTipoSolucion", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SOL_ID", entidad.SOL_ID);
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