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

                    string query = "SELECT * FROM dbo.TipoSolucion ts WHERE ts.SOL_Id <> 0";

                    if (entidad.SOL_ID != 1)
                    {
                        query += " AND ts.SOL_Id = " + entidad.SOL_ID;
                    }

                    if (entidad.SOL_Nombre != null)
                    {
                        query += " AND (ts.SOL_Nombre LIKE '%" + entidad.SOL_Nombre + "%' OR ts.SOL_ID LIKE '%" + entidad.SOL_ID + "%')";
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
                                    tiposol.SOL_Descripcion = dr.GetString(dr.GetOrdinal("SOL_Descripcion"));
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
    }
}