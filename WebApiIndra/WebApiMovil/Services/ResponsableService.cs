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
    public class ResponsableService
    {
        public List<Cargo> ListadoCargo()
        {
            List<Cargo> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("CargoLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Cargo>();
                                while (dr.Read())
                                {
                                    Cargo item = new Cargo();
                                    item.CAR_ID = dr.GetInt32(dr.GetOrdinal("CAR_ID"));
                                    item.CAR_Descripcion = dr.GetString(dr.GetOrdinal("CAR_Descripcion"));
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
        public List<Nivel> ListadoNivel()
        {
            List<Nivel> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("NivelLista", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Nivel>();
                                while (dr.Read())
                                {
                                    Nivel item = new Nivel();
                                    item.NIV_ID = dr.GetInt32(dr.GetOrdinal("NIV_ID"));
                                    item.NIV_Descripcion = dr.GetString(dr.GetOrdinal("NIV_Descripcion"));
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
        public List<UsuarioResponsable> ListadoUsuarioResponsable(UsuarioResponsable entidad)
        {
            List<UsuarioResponsable> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY ur." + entidad.pvSortColumn + " " + entidad.pvSortOrder + ") as row FROM UsuarioResponsable ur " +
                                   "INNER JOIN Cargo c ON(ur.RES_CAR_ID=c.CAR_ID) " +
                                   "INNER JOIN Nivel n ON(ur.RES_NIV_ID=n.NIV_ID) " +
                                   "WHERE ur.RES_ID <> 0 AND ur.RES_FlagActivo=1";

                    string condition = "";
                    if (entidad.RES_Nombre != null)
                    {
                        condition += " AND (ur.RES_Nombre LIKE '%" + entidad.RES_Nombre + "%')";
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
                    string querytot = "SELECT COUNT(ur.RES_ID)AS Cantidad FROM UsuarioResponsable ur " +
                                   "INNER JOIN Cargo c ON(ur.RES_CAR_ID=c.CAR_ID) " +
                                   "INNER JOIN Nivel n ON(ur.RES_NIV_ID=n.NIV_ID) " +
                                   "WHERE ur.RES_FlagActivo=1";

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
                                Lista = new List<UsuarioResponsable>();
                                while (dr.Read())
                                {
                                    UsuarioResponsable item = new UsuarioResponsable();
                                    item.RES_ID = dr.GetInt32(dr.GetOrdinal("RES_ID"));
                                    item.RES_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre")) +" "+ dr.GetString(dr.GetOrdinal("RES_ApellidoPaterno"))+" "+ dr.GetString(dr.GetOrdinal("RES_ApellidoMaterno"));
                                    item.RES_Email = dr.GetString(dr.GetOrdinal("RES_Email"));
                                    item.RES_ApellidoMaterno = dr.GetString(dr.GetOrdinal("RES_ApellidoMaterno"));
                                    item.RES_ApellidoPaterno = dr.GetString(dr.GetOrdinal("RES_ApellidoPaterno"));
                                    item.CAR_Descripcion = dr.GetString(dr.GetOrdinal("CAR_Descripcion"));
                                    item.NIV_Descripcion = dr.GetString(dr.GetOrdinal("NIV_Descripcion"));

                                    string editar = "<a title='Editar' href='#' class='editar' id='"+ item.RES_ID + "'><span class='glyphicon glyphicon-edit fa-1x'></span></a>"; ;
                                    string eliminar = "<a title='Eliminar' href='#' class='eliminar' id='"+ item.RES_ID + "'><span class='glyphicon glyphicon-trash fa-1x'></span></a>"; ;

                                    item.ltAcciones = editar+ "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + eliminar;

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
                                Lista = new List<UsuarioResponsable>();
                                UsuarioResponsable item = new UsuarioResponsable();
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
        public string InsertarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("InsertarUsuarioResponsable", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        string RES_Login = entidad.RES_Nombre.Substring(0, 1) + entidad.RES_ApellidoPaterno;
                        command.Parameters.AddWithValue("@RES_Login", RES_Login);
                        command.Parameters.AddWithValue("@RES_Nombre", entidad.RES_Nombre);
                        command.Parameters.AddWithValue("@RES_ApellidoPaterno", entidad.RES_ApellidoPaterno);
                        command.Parameters.AddWithValue("@RES_ApellidoMaterno", entidad.RES_ApellidoMaterno);
                        command.Parameters.AddWithValue("@RES_Email", entidad.RES_Email);
                        command.Parameters.AddWithValue("@RES_CAR_ID", entidad.RES_CAR_ID);
                        command.Parameters.AddWithValue("@RES_NIV_ID", entidad.RES_NIV_ID);
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
        public List<UsuarioResponsable> EditarUsuarioResponsable(UsuarioResponsable entidad)
        {
            List<UsuarioResponsable> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EditarUsuarioResponsable", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RES_ID", entidad.RES_ID);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<UsuarioResponsable>();
                                while (dr.Read())
                                {
                                    UsuarioResponsable item = new UsuarioResponsable();
                                    item.RES_ID = dr.GetInt32(dr.GetOrdinal("RES_ID"));
                                    item.RES_Login = dr.GetString(dr.GetOrdinal("RES_Login"));
                                    item.RES_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre"));
                                    item.RES_ApellidoPaterno = dr.GetString(dr.GetOrdinal("RES_ApellidoPaterno"));
                                    item.RES_ApellidoMaterno = dr.GetString(dr.GetOrdinal("RES_ApellidoMaterno"));
                                    item.RES_Email = dr.GetString(dr.GetOrdinal("RES_Email"));
                                    item.RES_CAR_ID = dr.GetInt32(dr.GetOrdinal("RES_CAR_ID"));
                                    item.RES_NIV_ID = dr.GetInt32(dr.GetOrdinal("RES_NIV_ID"));
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
        public string ActualizarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarUsuarioResponsable", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        string RES_Login = entidad.RES_Nombre.Substring(0, 1) + entidad.RES_ApellidoPaterno;
                        command.Parameters.AddWithValue("@RES_Login", RES_Login);
                        command.Parameters.AddWithValue("@RES_ID", entidad.RES_ID);
                        command.Parameters.AddWithValue("@RES_Nombre", entidad.RES_Nombre);
                        command.Parameters.AddWithValue("@RES_ApellidoPaterno", entidad.RES_ApellidoPaterno);
                        command.Parameters.AddWithValue("@RES_ApellidoMaterno", entidad.RES_ApellidoMaterno);
                        command.Parameters.AddWithValue("@RES_Email", entidad.RES_Email);
                        command.Parameters.AddWithValue("@RES_CAR_ID", entidad.RES_CAR_ID);
                        command.Parameters.AddWithValue("@RES_NIV_ID", entidad.RES_NIV_ID);
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

        public string EliminarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarUsuarioResponsable", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RES_ID", entidad.RES_ID);
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