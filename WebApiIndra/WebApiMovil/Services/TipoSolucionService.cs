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
    }
}