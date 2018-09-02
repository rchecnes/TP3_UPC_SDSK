using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class UsuarioService
    {
        public List<Usuario> ValidarUsuario(Usuario entidad)
        {
            List<Usuario> lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    string sql = "SELECT * FROM UsuarioResponsable ur " +
                                 "INNER JOIN Cargo c ON(ur.RES_CAR_ID=c.CAR_ID) " +
                                 "WHERE ur.RES_Login='" + entidad.USUS_Login + "' AND ur.RES_Password='" + entidad.USUS_Password + "'";

                    using (SqlCommand command = new SqlCommand(sql, conection))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                lista = new List<Usuario>();
                                while (dr.Read())
                                {
                                    Usuario item = new Usuario();
                                    item.USUS_ID = dr.GetInt32(dr.GetOrdinal("RES_ID"));
                                    item.USUS_Login = dr.GetString(dr.GetOrdinal("RES_Login"));
                                    item.USUS_Nombre = dr.GetString(dr.GetOrdinal("RES_Nombre"));
                                    item.USUS_Tipo = "USUARIO_RESPONSABLE";
                                    item.USUS_CAR_ID = dr.GetInt32(dr.GetOrdinal("CAR_ID")); ;
                                    item.USUS_CAR_Nombre = dr.GetString(dr.GetOrdinal("CAR_Descripcion"));
                                    lista.Add(item);
                                }
                            }
                        }

                    }

                    if(lista != null)
                    {
                        conection.Close();
                        return lista;
                    }
                    else
                    {
                        string sqluc = "SELECT * FROM UsuarioCliente " +
                                     "WHERE USU_Login='" + entidad.USUS_Login + "' AND USU_Password='" + entidad.USUS_Password + "'";

                        using (SqlCommand command = new SqlCommand(sqluc, conection))
                        {
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    lista = new List<Usuario>();
                                    while (dr.Read())
                                    {
                                        Usuario item = new Usuario();
                                        item.USUS_ID = dr.GetInt32(dr.GetOrdinal("USU_ID"));
                                        item.USUS_Login = dr.GetString(dr.GetOrdinal("USU_Login"));
                                        item.USUS_Nombre = dr.GetString(dr.GetOrdinal("USU_Nombre"));
                                        item.USUS_Tipo = "USUARIO_CLIENTE";
                                        item.USUS_CAR_ID = 0;
                                        item.USUS_CAR_Nombre = "Cliente";
                                        lista.Add(item);
                                    }
                                }
                            }

                        }

                        conection.Close();
                        return lista;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}