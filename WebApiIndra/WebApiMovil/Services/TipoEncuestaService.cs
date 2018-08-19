using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class TipoEncuestaService
    {
        public List<TipoEncuesta> ListadoTipoEncuesta(TipoEncuesta entidad)
        {
            List<TipoEncuesta> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY te." + entidad.pvSortColumn + " " + entidad.pvSortOrder + ") as row FROM TipoEncuesta te " +
                                   "WHERE te.TEN_FlagActivo=1";

                    string condition = "";
                    if (entidad.TEN_Nombre != null)
                    {
                        condition += " AND (te.TEN_Nombre LIKE '%" + entidad.TEN_Nombre + "%')";
                    }

                    //Paginado
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
                    //Fin paginado

                    string finquery = "SELECT * FROM (" + query + condition + ")a WHERE a.row >" + inicio + " and a.row <= " + final;

                    //Hacemos un conteo de los registro
                    int totRecord = 0;
                    string querytot = "SELECT COUNT(te.TEN_ID)AS Cantidad FROM TipoEncuesta te " +
                                      "WHERE te.TEN_FlagActivo=1";

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
                                Lista = new List<TipoEncuesta>();
                                while (dr.Read())
                                {
                                    TipoEncuesta item = new TipoEncuesta();
                                    item.TEN_ID = dr.GetInt32(dr.GetOrdinal("TEN_ID"));
                                    item.TEN_Nombre = dr.GetString(dr.GetOrdinal("TEN_Nombre"));
                                    item.TEN_AnioVigencia = dr.GetInt32(dr.GetOrdinal("TEN_AnioVigencia"));
                                    string editar = "<a title='Editar' href='#' class='editar' id='" + item.TEN_ID + "'><span class='glyphicon glyphicon-edit fa-1x'></span></a>";
                                    string pregunta = "<a title='Agregar Pregunta' href='#' class='pregunta' id='" + item.TEN_ID + "'><span class='glyphicon glyphicon-th-list fa-1x'></span></a>";
                                    string eliminar = "<a title='Eliminar' href='#' class='eliminar' id='" + item.TEN_ID + "'><span class='glyphicon glyphicon-trash fa-1x'></span></a>";
                                    

                                    item.ltAcciones = editar + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + pregunta + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + eliminar;

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
                                Lista = new List<TipoEncuesta>();
                                TipoEncuesta item = new TipoEncuesta();
                                item.draw = 0;
                                item.iTotalRecords = 0;
                                item.iTotalDisplayRecords = 0;
                                item.ltAcciones = "";
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
        public string InsertarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("InsertarTipoEncuesta", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TEN_Nombre", entidad.TEN_Nombre);
                        command.Parameters.AddWithValue("@TEN_Descripcion", entidad.TEN_Descripcion);
                        command.Parameters.AddWithValue("@TEN_AnioVigencia", entidad.TEN_AnioVigencia);
                        command.Parameters.AddWithValue("@TEN_FechaCrecion", DateTime.Now);
                        command.Parameters.AddWithValue("@TEN_UsuarioCreacion", "JROMO");
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
        public List<TipoEncuesta> EditarTipoEncuesta(TipoEncuesta entidad)
        {
            List<TipoEncuesta> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EditarTipoEncuesta", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TEN_ID", entidad.TEN_ID);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<TipoEncuesta>();
                                while (dr.Read())
                                {
                                    TipoEncuesta item = new TipoEncuesta();
                                    item.TEN_ID = dr.GetInt32(dr.GetOrdinal("TEN_ID"));
                                    item.TEN_Nombre = dr.GetString(dr.GetOrdinal("TEN_Nombre"));
                                    if (dr.IsDBNull(dr.GetOrdinal("TEN_Descripcion")))
                                    {
                                        item.TEN_Descripcion = "";
                                    }
                                    else
                                    {
                                        item.TEN_Descripcion = dr.GetString(dr.GetOrdinal("TEN_Descripcion"));
                                    }
                                    item.TEN_AnioVigencia = dr.GetInt32(dr.GetOrdinal("TEN_AnioVigencia"));
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
        public string ActualizarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarTipoEncuesta", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TEN_ID", entidad.TEN_ID);
                        command.Parameters.AddWithValue("@TEN_Nombre", entidad.TEN_Nombre);
                        command.Parameters.AddWithValue("@TEN_Descripcion", entidad.TEN_Descripcion);
                        command.Parameters.AddWithValue("@TEN_AnioVigencia", entidad.TEN_AnioVigencia);
                        command.Parameters.AddWithValue("@TEN_FechaModificacion", DateTime.Now);
                        command.Parameters.AddWithValue("@TEN_UsuarioModificacion", "JROMO");
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
        public string EliminarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarTipoEncuesta", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TEN_ID", entidad.TEN_ID);
                        command.ExecuteNonQuery();
                    }

                    string query = "DELETE FROM TipoEncuestaPregunta WHERE TEP_TEN_ID=" + entidad.TEN_ID;

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        command.ExecuteReader();
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
        public string InsertarTipoEncuestaPregunta(TipoEncuestaPregunta entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "INSERT INTO TipoEncuestaPregunta (TEP_PRE_ID,TEP_TEN_ID) VALUES('"+entidad.TEP_PRE_ID+"','"+entidad.TEP_TEN_ID+"')";

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        command.ExecuteReader();
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
        public List<TipoEncuestaPregunta> ListadoTipoEncuestaPregunta(TipoEncuestaPregunta entidad)
        {
            List<TipoEncuestaPregunta> Lista = null;

            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM TipoEncuestaPregunta tep" +
                                   " INNER JOIN Pregunta p ON(tep.TEP_PRE_ID=p.PRE_ID)" +
                                   " WHERE tep.TEP_TEN_ID='"+entidad.TEP_TEN_ID + "' AND tep.TEP_FlagActivo=1" +
                                   " AND p.PRE_FlagActivo=1";

                    string prueba = "";

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<TipoEncuestaPregunta>();
                                while (dr.Read())
                                {
                                    TipoEncuestaPregunta item = new TipoEncuestaPregunta();
                                    item.TEP_ID = dr.GetInt32(dr.GetOrdinal("TEP_ID"));
                                    item.TEP_PRE_ID = dr.GetInt32(dr.GetOrdinal("TEP_PRE_ID"));
                                    item.TEP_TEN_ID = dr.GetInt32(dr.GetOrdinal("TEP_TEN_ID"));
                                    item.PRE_Descripcion = dr.GetString(dr.GetOrdinal("PRE_Descripcion"));
                                    item.PRE_TipoControl = dr.GetInt32(dr.GetOrdinal("PRE_TipoControl"));
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
                throw;
            }
        }
        public List<Pregunta> BuscarPregunta(TipoEncuestaPregunta entidad)
        {
            List<Pregunta> Lista = null;

            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM Pregunta p WHERE p.PRE_FlagActivo=1 AND p.PRE_Descripcion LIKE '%"+entidad.PRE_Descripcion+"%' AND p.PRE_ID NOT IN(SELECT TEP_PRE_ID FROM TipoEncuestaPregunta tep WHERE tep.TEP_TEN_ID="+entidad.TEP_TEN_ID+" AND tep.TEP_FlagActivo=1)";

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Pregunta>();
                                while (dr.Read())
                                {
                                    Pregunta item = new Pregunta();
                                    item.PRE_ID = dr.GetInt32(dr.GetOrdinal("PRE_ID"));
                                    item.PRE_Descripcion = dr.GetString(dr.GetOrdinal("PRE_Descripcion"));
                                    item.label = dr.GetString(dr.GetOrdinal("PRE_Descripcion"));
                                    item.value = dr.GetInt32(dr.GetOrdinal("PRE_ID"));
                                    item.PRE_TipoControl = dr.GetInt32(dr.GetOrdinal("PRE_TipoControl"));
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
                throw;
            }
        }
        public string EliminarTipoEncuestaPregunta(TipoEncuestaPregunta entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "DELETE FROM TipoEncuestaPregunta WHERE TEP_ID=" + entidad.TEP_ID;

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        command.ExecuteReader();
                    }
                    conection.Close();
                }

                return "ok";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}