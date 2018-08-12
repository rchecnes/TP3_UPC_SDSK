using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiIndra.Models;

namespace WebApiIndra.Services
{
    public class TipoSolucionService
    {
        public List<TipoSolucion> ListadoTipoSolucion()
        {
            List<TipoSolucion> ListaBase = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM dbo.GM_Ticket";

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                ListaBase = new List<TipoSolucion>();
                                while (dr.Read())
                                {
                                    TipoSolucion baseco = new TipoSolucion();
                                    baseco.NombreBC = dr.GetString(dr.GetOrdinal("IdTicket"));

                                    ListaBase.Add(baseco);
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
                                    estado.CAT_Descripcion= dr.GetString(dr.GetOrdinal("CAT_Descripcion"));
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