using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class ContratoService
    {
        public List<Contrato> ListadoContrato(Contrato entidad)
        {
            List<Contrato> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY " + entidad.pvSortColumn + " " + entidad.pvSortOrder + ") as row FROM dbo.Contrato c " +
                                   "INNER JOIN Empresa em ON(c.CON_EMP_ID=em.EMP_ID) " +
                                   "WHERE c.CON_FlagActivo=1";

                    string condition = "";
                    if (entidad.EMP_RazonSocial != null)
                    {
                        condition += " AND em.EMP_RazonSocial LIKE '%" + entidad.EMP_RazonSocial+"%'";
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
                    string querytot = "SELECT COUNT(c.CON_ID)AS Cantidad FROM dbo.Contrato c " +
                                   "INNER JOIN Empresa em ON(c.CON_EMP_ID=em.EMP_ID) " +
                                   "WHERE c.CON_FlagActivo=1";
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
                                Lista = new List<Contrato>();
                                while (dr.Read())
                                {
                                    Contrato item = new Contrato();
                                    item.CON_ID = dr.GetInt32(dr.GetOrdinal("CON_ID"));
                                    item.EMP_RazonSocial = dr.GetString(dr.GetOrdinal("EMP_RazonSocial"));                                  
                                    item.CON_FechaFinContrato = dr.GetDateTime(dr.GetOrdinal("CON_FechaFinContrato")).ToString("dd/MM/yyyy");

                                    string editar = "<a title='Editar' href='#' class='editar' id='" + item.CON_ID + "'><span class='glyphicon glyphicon-edit fa-1x'></span></a>";
                                    string eliminar = "<a title='Eliminar Ticket' href='#' class='eliminar' id='" + item.CON_ID + "'><span class='glyphicon glyphicon-trash fa-1x'></span></a>";
                                    string addsla = "<a title='Agregar SLA' href='#' class='addsla' id='" + item.CON_ID + "'><span class='glyphicon glyphicon-th-list fa-1x'></span></a>";
                                    item.ltAcciones = editar + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + eliminar + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + addsla;

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
                                Lista = new List<Contrato>();
                                Contrato item = new Contrato();
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
        public string InsertarContrato(Contrato entidad)
        {
            using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                conection.Open();
                SqlTransaction tran = conection.BeginTransaction();

                try
                {

                    string sqltik = "INSERT INTO Contrato " +
                                    " (CON_EMP_ID, CON_FechaInicioContrato, CON_FechaFinContrato, CON_FechaCreacion, CON_UsuarioCreacion, CON_FlagActivo) VALUES" +
                                    "('" + entidad.CON_EMP_ID + "', '" + entidad.CON_FechaInicioContrato + "','" + entidad.CON_FechaFinContrato + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + entidad.CON_UsuarioCreacion+"','1')";

                    using (SqlCommand command = new SqlCommand(sqltik, conection, tran))
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
        public List<Contrato> EditarContrato(Contrato entidad)
        {
            List<Contrato> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM dbo.Contrato c INNER JOIN Empresa em ON(c.CON_EMP_ID=em.EMP_ID) WHERE CON_ID="+entidad.CON_ID;

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Contrato>();
                                while (dr.Read())
                                {
                                    Contrato item = new Contrato();
                                    item.CON_ID = dr.GetInt32(dr.GetOrdinal("CON_ID"));
                                    item.EMP_RazonSocial = dr.GetString(dr.GetOrdinal("EMP_RazonSocial"));
                                    item.CON_FechaInicioContrato = dr.GetDateTime(dr.GetOrdinal("CON_FechaInicioContrato")).ToString("yyyy-MM-dd");
                                    item.CON_FechaFinContrato = dr.GetDateTime(dr.GetOrdinal("CON_FechaFinContrato")).ToString("yyyy-MM-dd");                                    
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
        public string ActualizarContrato(Contrato entidad)
        {
            using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                conection.Open();
                SqlTransaction tran = conection.BeginTransaction();

                try
                {

                    string sqltik = "UPDATE Contrato " +
                                    " SET CON_FechaInicioContrato='"+entidad.CON_FechaInicioContrato+ "', CON_FechaFinContrato='"+entidad.CON_FechaFinContrato + "'" +
                                    " WHERE CON_ID="+entidad.CON_ID;

                    using (SqlCommand command = new SqlCommand(sqltik, conection, tran))
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
        public string EliminarContrato(Contrato entidad)
        {
            using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                conection.Open();
                SqlTransaction tran = conection.BeginTransaction();

                try
                {

                    using (SqlCommand command = new SqlCommand("DELETE FROM Contrato WHERE CON_ID="+entidad.CON_ID, conection, tran))
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
    }
}