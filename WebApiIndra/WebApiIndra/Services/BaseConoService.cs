using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiIndra.Models;

namespace WebApiIndra.Services
{
    public class BaseConoService
    {
        public List<SD_BaseConocimiento> ListadoBaseConocimiento()
        {
            List<SD_BaseConocimiento> ListaBase = null;
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
                                ListaBase = new List<SD_BaseConocimiento>();
                                while (dr.Read())
                                {
                                    SD_BaseConocimiento baseco = new SD_BaseConocimiento();
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
    }
}