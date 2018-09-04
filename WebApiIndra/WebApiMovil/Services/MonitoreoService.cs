using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class MonitoreoService
    {
        public List<Contrato> ListadoContratoMonitoreo(Contrato entidad)
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
                        condition += " AND em.EMP_RazonSocial LIKE '%" + entidad.EMP_RazonSocial + "%'";
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

                                    string monitoreo = "<a title='Monitorear SLA' href='#' class='monitoreo' id='" + item.CON_ID + "'><span class='glyphicon glyphicon-signal fa-1x'></span></a>";
                                    item.ltAcciones = monitoreo;

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
        public List<ContratoSLA> ListadoLogroMonitoreo(ContratoSLA entidad)
        {
            List<ContratoSLA> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string query = "SELECT * FROM ContratoSLA csl" +
                                   " INNER JOIN SLA s ON(csl.CSL_SLA_ID=s.SLA_ID)" +
                                   " WHERE CSL_CON_ID="+entidad.CSL_CON_ID;

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<ContratoSLA>();
                                while (dr.Read())
                                {
                                    ContratoSLA item = new ContratoSLA();
                                    item.CSL_SLA_ID = dr.GetInt32(dr.GetOrdinal("CSL_SLA_ID"));
                                    item.CSL_PorcentajeMedicion = dr.GetDecimal(dr.GetOrdinal("CSL_PorcentajeMedicion"));
                                    item.CSL_Penalidad = dr.GetDecimal(dr.GetOrdinal("CSL_Penalidad"));
                                    item.SLA_Descripcion= dr.GetString(dr.GetOrdinal("SLA_Descripcion"));
                                    item.SLA_NomSistema = dr.GetString(dr.GetOrdinal("SLA_NomSistema"));
                                    //item.
                                    //Mese
                                    string[] mes = new string[12];
                                    mes[0] = "ENE"; mes[3] = "ABR"; mes[6] = "JUL"; mes[9] = "OCT";
                                    mes[1] = "FEB"; mes[4] = "MAY"; mes[7] = "AGO"; mes[10] = "NOV";
                                    mes[2] = "MAR"; mes[5] = "JUN"; mes[8] = "SEP"; mes[11] = "DIC";

                                    List<RepMonitoreo> Resultado = null;
                                    string queryrep = "SELECT MONTH(TIC_FechaRegistro)as REP_Periodo, YEAR(TIC_FechaRegistro)as REP_Anio  FROM Ticket " +
                                                      " WHERE TIC_EMP_ID=" + entidad.CSL_EMP_ID+ " AND TIC_FechaRegistro BETWEEN '" + entidad.CON_FechaInicioContrato + "' AND '"+entidad.CON_FechaFinContrato + "' GROUP BY YEAR(TIC_FechaRegistro),MONTH(TIC_FechaRegistro)";
                                    using (SqlCommand command1 = new SqlCommand(queryrep, conection))
                                    {
                                        using (SqlDataReader dr1 = command1.ExecuteReader())
                                        {
                                            if (dr1.HasRows)
                                            {
                                                Resultado = new List<RepMonitoreo>();
                                                while (dr1.Read())
                                                {
                                                    decimal logro = 0;
                                                    if(dr.GetString(dr.GetOrdinal("SLA_NomSistema"))== "TEMP_ATE_M10M")
                                                    {
                                                        logro = 50;
                                                    }
                                                    else if(dr.GetString(dr.GetOrdinal("SLA_NomSistema")) == "NRESOL_PRI_CONTACTO")
                                                    {
                                                        logro = 20;
                                                    }
                                                    else if (dr.GetString(dr.GetOrdinal("SLA_NomSistema")) == "TIC_ATE_24H")
                                                    {
                                                        logro = 60;
                                                    }

                                                    RepMonitoreo rep = new RepMonitoreo();
                                                    rep.REP_Logro = logro;
                                                    rep.REP_Cumple = (dr.GetDecimal(dr.GetOrdinal("CSL_PorcentajeMedicion"))>= logro)?1:0;
                                                    rep.REP_Descripcion = mes[dr1.GetInt32(dr1.GetOrdinal("REP_Periodo"))-1];
                                                    rep.REP_Periodo = "08";
                                                    rep.REP_Anio = dr1.GetInt32(dr1.GetOrdinal("REP_Anio"));
                                                    Resultado.Add(rep);
                                                }
                                            }
                                        }
                                    }
                                    item.Medicion = Resultado;
                                    //item.Medicion =  

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