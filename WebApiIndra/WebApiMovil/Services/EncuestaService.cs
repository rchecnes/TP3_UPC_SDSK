﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class EncuestaService
    {
        public List<Ticket> ListadoTicketAtendido(Ticket entidad)
        {
            List<Ticket> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT *,ROW_NUMBER() OVER (ORDER BY " + entidad.pvSortColumn + " " + entidad.pvSortOrder + ") as row FROM dbo.Ticket t " +
                                   "INNER JOIN TipoSolucion ts ON(t.TIC_SOL_ID=ts.SOL_ID) " +
                                   "INNER JOIN Empresa em ON(t.TIC_EMP_ID=em.EMP_ID) " +
                                   "INNER JOIN UsuarioCliente uc ON(t.TIC_USU_ID=uc.USU_ID) " +
                                   "INNER JOIN Estado es ON(t.TIC_EST_ID=es.EST_ID) " +
                                   "WHERE t.TIC_FlagActivo=1 AND t.TIC_EST_ID=3 AND t.TIC_EMP_ID="+entidad.TIC_EMP_ID+ " AND t.TIC_SOL_ID="+ entidad.TIC_SOL_ID;

                    string condition = "";
                    if (entidad.TIC_ID != 0)
                    {
                        condition += " AND t.TIC_ID = " + entidad.TIC_ID;
                    }

                    /*if (entidad.EMP_RazonSocial != null)
                    {
                        condition += " AND (em.EMP_RazonSocial LIKE '%" + entidad.EMP_RazonSocial + "%')";
                    }

                    if (entidad.TIC_FechaInicio != null && entidad.TIC_FechaFin != null)
                    {
                        condition += " AND t.TIC_FechaRegistro BETWEEN '" + entidad.TIC_FechaInicio + "' AND '" + entidad.TIC_FechaFin + "'";
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
                    }*/

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
                    string querytot = "SELECT COUNT(ts.SOL_ID)AS Cantidad FROM dbo.Ticket t " +
                                   "INNER JOIN TipoSolucion ts ON(t.TIC_SOL_ID=ts.SOL_ID) " +
                                   "INNER JOIN Empresa em ON(t.TIC_EMP_ID=em.EMP_ID) " +
                                   "INNER JOIN UsuarioCliente uc ON(t.TIC_USU_ID=uc.USU_ID) " +
                                   "INNER JOIN Estado es ON(t.TIC_EST_ID=es.EST_ID) " +
                                   "WHERE t.TIC_FlagActivo=1 AND t.TIC_EST_ID=3";
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
                                    
                                    item.TIC_FechaRegistro = dr.GetDateTime(dr.GetOrdinal("TIC_FechaRegistro")).ToString("dd/MM/yyyy");
                                    item.EST_Descrpcion = dr.GetString(dr.GetOrdinal("EST_Descripcion"));
                                    item.RES_Nombre = "ANONIMO";

                                    string encuesta = "<a title='Responder Encuesta' href='#' class='encuesta' id='" + item.TIC_ID + "'><span class='glyphicon glyphicon-pencil fa-1x'></span></a>";                                    

                                    item.ltAcciones = encuesta;

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
        public List<TipoEncuestaPregunta> ListadoPreguntaEncuesta()
        {
            List<TipoEncuestaPregunta> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query =  "SELECT * FROM TipoEncuestaPregunta tep"+
                                    " INNER JOIN TipoEncuesta te ON(tep.TEP_TEN_ID = te.TEN_ID)"+
                                    " INNER JOIN Pregunta pr ON(tep.TEP_PRE_ID = pr.PRE_ID)"+
                                    " WHERE te.TEN_AnioVigencia = YEAR(GETDATE())";

                                       
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
                                    item.TEP_PRE_ID = dr.GetInt32(dr.GetOrdinal("TEP_PRE_ID"));
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
                throw (ex);
            }
        }
    }
}