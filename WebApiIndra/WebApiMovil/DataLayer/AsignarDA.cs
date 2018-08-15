using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.DataLayer
{
    public class AsignarDA
    {
        public List<Asignacion> ListadoEquiposAsignados(Asignacion entidad)
        {
            List<Asignacion> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("Listar", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@piPageSize", entidad.iPageSize);
                        command.Parameters.AddWithValue("@piCurrentPage", entidad.iCurrentPage);
                        command.Parameters.AddWithValue("@pvSortColumn", entidad.pvSortColumn);
                        command.Parameters.AddWithValue("@pvSortOrder", entidad.pvSortOrder);
                        command.Parameters.AddWithValue("@idCodAsignacion", entidad.idCodAsignacion);
                        command.Parameters.AddWithValue("@vNroDocRepsonsable", entidad.vNroDocRepsonsable);
                        command.Parameters.AddWithValue("@vNombreResponsable", entidad.vNombreResponsable);
                        command.Parameters.AddWithValue("@vNroDocEncargado", entidad.vNroDocEncargado);
                        command.Parameters.AddWithValue("@vNombreEncargado", entidad.vNombreEncargado);

                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);
                        command.Parameters.AddWithValue("@cEstado", entidad.cEstado);
                        command.Parameters.AddWithValue("@dtFechaASignacion", entidad.dtFechaASignacion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Asignacion>();
                                while (dr.Read())
                                {
                                    Asignacion asignacion = new Asignacion();
                                    asignacion.sEcho = 1;
                                    asignacion.draw = dr.GetInt32(dr.GetOrdinal("iCurrentPage"));
                                    asignacion.iTotalRecords = dr.GetInt32(dr.GetOrdinal("iRecordCount"));
                                    asignacion.iTotalDisplayRecords = dr.GetInt32(dr.GetOrdinal("iRecordCount"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAsignacion")))
                                        asignacion.idCodAsignacion = dr.GetInt32(dr.GetOrdinal("idCodAsignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocRepsonsable")))
                                        asignacion.vNroDocRepsonsable = dr.GetString(dr.GetOrdinal("vNroDocRepsonsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatResponsable")))
                                        asignacion.vApePatResponsable = dr.GetString(dr.GetOrdinal("vApePatResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApeMatResponsable")))
                                        asignacion.vApeMatResponsable = dr.GetString(dr.GetOrdinal("vApeMatResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombreResponsable")))
                                        asignacion.vNombreResponsable = dr.GetString(dr.GetOrdinal("vNombreResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatResponsable")) && !dr.IsDBNull(dr.GetOrdinal("vApeMatResponsable")) && !dr.IsDBNull(dr.GetOrdinal("vNombreResponsable")))
                                        asignacion.vReponsable = asignacion.vApePatResponsable + " " + asignacion.vApePatResponsable + " " + asignacion.vNombreResponsable;
                                    //**************************************************************************************
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocEncargado")))
                                        asignacion.vNroDocEncargado = dr.GetString(dr.GetOrdinal("vNroDocEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatEncargado")))
                                        asignacion.vApePatEncargado = dr.GetString(dr.GetOrdinal("vApePatEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApeMatEncargado")))
                                        asignacion.vApeMatEncargado = dr.GetString(dr.GetOrdinal("vApeMatEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombreEncargado")))
                                        asignacion.vNombreEncargado = dr.GetString(dr.GetOrdinal("vNombreEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocEncargado")) && !dr.IsDBNull(dr.GetOrdinal("vApeMatEncargado")) && !dr.IsDBNull(dr.GetOrdinal("vNombreEncargado")))
                                        asignacion.vEncargadoNombre = asignacion.vApePatEncargado + " " + asignacion.vApeMatEncargado + " " + asignacion.vNombreEncargado;
                                    //**************************************************************************************
                                    if (!dr.IsDBNull(dr.GetOrdinal("dtFechaASignacion")))
                                        asignacion.dtFechaASignacion = dr.GetString(dr.GetOrdinal("dtFechaASignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        asignacion.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cEstado")))
                                        asignacion.cEstado = dr.GetString(dr.GetOrdinal("cEstado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        asignacion.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    

                                    //asignacion.vAcciones = "<span data-id='" + asignacion.idCodAsignacion + "' class='ver ar-bullseye_solid' title='Ver'></span> &nbsp;&nbsp;";
                                    ////asignacion.vAcciones = asignacion.vAcciones + " <span data-id='" + asignacion.idCodAsignacion + "' class='editar fas fa-inbox' title='Devolucion'></span>&nbsp;&nbsp;";
                                    ////asignacion.vAcciones = asignacion.vAcciones + " <span data-id='" + asignacion.idCodAsignacion + "' class='eliminar fas fa-sync-alt' title='Reposicion'></span>";
                                    //asignacion.vAcciones = asignacion.vAcciones + " <span data-id='" + asignacion.idCodAsignacion + "' class='devolucion fas fa-inbox' title='Devolucion'></span>&nbsp;&nbsp;&nbsp;";
                                    //asignacion.vAcciones = asignacion.vAcciones + " <span data-id='" + asignacion.idCodAsignacion + "' class='reposicion fas fa-sync-alt' title='Reposicion'></span>&nbsp;&nbsp;&nbsp;";
                                    //asignacion.vAcciones = asignacion.vAcciones + " <span data-id='" + asignacion.idCodAsignacion + "' class='eliminar fas fa-trash-alt' title='Eliminar'></span>&nbsp;";
                                    if (asignacion.cEstado == "ASIGNADO")
                                    {
                                        asignacion.vAcciones = "<nav class='nav-actions'><a data-toggle='tooltip' data-placement='top' class='ver' title='Ver' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-eye'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "<a data-toggle = 'tooltip' data-placement = 'top' class='devolucion' title='Devolucion' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-inbox'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "<a data-toggle = 'tooltip' data-placement = 'top' class='reposicion' title='Reposicion' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-sync-alt'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "<a data-toggle = 'tooltip' data-placement = 'top' class='reimpresionasig' title='Reimpresion Formato N° 4' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-file-pdf'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "<a class='danger' data-toggle='tooltip' data-placement='top' title='Eliminar' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-trash-alt'></i></a></nav>";
                                    }
                                    else if (asignacion.cEstado == "DEVUELT0")
                                    {
                                        asignacion.vAcciones = "<nav class='nav-actions'><a data-toggle='tooltip' data-placement='top' class='ver' title='Ver' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-eye'></i></a>";
                                        //asignacion.vAcciones = asignacion.vAcciones + "<a data-toggle = 'tooltip' data-placement = 'top' class='devolucion' title='Devolucion' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-inbox'></i></a>";
                                        //asignacion.vAcciones = asignacion.vAcciones + "<a data-toggle = 'tooltip' data-placement = 'top' class='reposicion' title='Reposicion' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-sync-alt'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "<a data-toggle = 'tooltip' data-placement = 'top' class='reimpresiondev' title='Reimpresion Formato N° 5' data-id='" + asignacion.idCodAsignacion + "'><i class='far fa-file-pdf'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "</nav>";
                                    }
                                    else if(asignacion.cEstado == "REPOSICION"){
                                        asignacion.vAcciones = "<nav class='nav-actions'><a data-toggle='tooltip' data-placement='top' class='ver' title='Ver' data-id='" + asignacion.idCodAsignacion + "'><i class='fas fa-eye'></i></a>";
                                        asignacion.vAcciones = asignacion.vAcciones + "</nav>";
                                    }
                                    

                                    Lista.Add(asignacion);
                                }
                            }
                            else {
                                Lista = new List<Asignacion>();
                                Asignacion asignacion = new Asignacion();
                                asignacion.draw = 1;
                                asignacion.iTotalRecords = 0;
                                asignacion.iTotalDisplayRecords = 0;
                                Lista.Add(asignacion);
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
   
        public List<Cliente> ListadoCliente()
        {
            List<Cliente> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("Listar", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Cliente>();
                                while (dr.Read())
                                {
                                    Cliente cliente = new Cliente();
                                    cliente.CodigoCliente = dr.GetInt32(dr.GetOrdinal("CodigoCliente"));
                                    cliente.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                                    cliente.Direccion = dr.GetString(dr.GetOrdinal("Direccion"));
                                    cliente.Telefono = dr.GetString(dr.GetOrdinal("Telefono"));


                                    Lista.Add(cliente);
                                }
                            }
                            else
                            {
                                Lista = new List<Cliente>();
                                Cliente cliente = new Cliente();
                                cliente.draw = 1;
                                cliente.iTotalRecords = 0;
                                cliente.iTotalDisplayRecords = 0;
                                Lista.Add(cliente);
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

        public Asignacion AsignacionCRUD(Asignacion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_ASIGNACION_CRUD]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodAsignacion", entidad.idCodAsignacion);
                        //command.Parameters.AddWithValue("@dtFechaAsignacion", entidad.dtFechaAsignacion);
                        command.Parameters.AddWithValue("@idCodEquipo", entidad.idCodEquipo);
                        command.Parameters.AddWithValue("@iCodPlan", entidad.iCodPlan);

                        command.Parameters.AddWithValue("@vNroDocRepsonsable", entidad.vNroDocRepsonsable);
                        command.Parameters.AddWithValue("@vNombreResponsable", entidad.vNombreResponsable);
                        command.Parameters.AddWithValue("@vApePatResponsable", entidad.vApePatResponsable);
                        command.Parameters.AddWithValue("@vApeMatResponsable", entidad.vApeMatResponsable);

                        command.Parameters.AddWithValue("@vNroDocEncargado", entidad.vNroDocEncargado);
                        command.Parameters.AddWithValue("@vNombreEncargado", entidad.vNombreEncargado);
                        command.Parameters.AddWithValue("@vApePatEncargado", entidad.vApePatEncargado);
                        command.Parameters.AddWithValue("@vApeMatEncargado", entidad.vApeMatEncargado);
                        command.Parameters.AddWithValue("@iUsuarioRegistro", entidad.iUsuarioRegistro);
                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);

                        command.Parameters.AddWithValue("@iOpcion", entidad.iOpcion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAsignacion")))
                                        entidad.idCodAsignacion = dr.GetInt32(dr.GetOrdinal("idCodAsignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("bError")))
                                        entidad.bError = dr.GetBoolean(dr.GetOrdinal("bError"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vMensaje")))
                                        entidad.vMensaje = dr.GetString(dr.GetOrdinal("vMensaje"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Ubigeo> ListarDepartamento()
        {
            List<Ubigeo> Lista = new List<Ubigeo>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_DEPARTAMENTO_LISTAR]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ubigeo>();
                                while (dr.Read())
                                {
                                    Ubigeo ubigeo = new Ubigeo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("DEPA_CODREF")))
                                        ubigeo.DEPA_CODREF = dr.GetString(dr.GetOrdinal("DEPA_CODREF"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("DEPA_DESCRIPCION")))
                                        ubigeo.DEPA_DESCRIPCION = dr.GetString(dr.GetOrdinal("DEPA_DESCRIPCION"));
                                    Lista.Add(ubigeo);
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

        public List<Ubigeo> ListarProvincia(Ubigeo entidad)
        {
            List<Ubigeo> Lista = new List<Ubigeo>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_PROVINCIA_LISTAR]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DEPA_CODREF", entidad.DEPA_CODREF);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ubigeo>();
                                while (dr.Read())
                                {
                                    Ubigeo ubigeo = new Ubigeo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("prov_codref")))
                                        ubigeo.prov_codref = dr.GetString(dr.GetOrdinal("prov_codref"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("prov_descripcion")))
                                        ubigeo.prov_descripcion = dr.GetString(dr.GetOrdinal("prov_descripcion"));
                                    Lista.Add(ubigeo);
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

        public List<Ubigeo> ListarDistrito(Ubigeo entidad)
        {
            List<Ubigeo> Lista = new List<Ubigeo>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_DISTRITO_LISTAR]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@prov_codref", entidad.prov_codref);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ubigeo>();
                                while (dr.Read())
                                {
                                    Ubigeo ubigeo = new Ubigeo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("dist_id")))
                                        ubigeo.dist_id = dr.GetInt32(dr.GetOrdinal("dist_id"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dist_descripcion")))
                                        ubigeo.dist_descripcion = dr.GetString(dr.GetOrdinal("dist_descripcion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dist_codref")))
                                        ubigeo.dist_codref = dr.GetString(dr.GetOrdinal("dist_codref"));
                                    Lista.Add(ubigeo);
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

        public Responsable BuscarResponsablePorDni(Responsable entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqvisita].[PA_PERSONAL_X_DNI_OBTENER]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@num_documento", entidad.NroDocResponsable);
                        command.Parameters.AddWithValue("@nom_trabajador", entidad.vResponsable);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_paterno")))
                                        entidad.vApePaterno = dr.GetString(dr.GetOrdinal("dsc_paterno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_materno")))
                                        entidad.vApeMaterno = dr.GetString(dr.GetOrdinal("dsc_materno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_nombres")))
                                        entidad.vNombres = dr.GetString(dr.GetOrdinal("dsc_nombres"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_paterno")) && !dr.IsDBNull(dr.GetOrdinal("dsc_materno")) && !dr.IsDBNull(dr.GetOrdinal("dsc_nombres")))
                                        entidad.vResponsable = entidad.vApePaterno + " " + entidad.vApeMaterno + " " + entidad.vNombres;
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Plan> ListarPlanes()
        {
            List<Plan> Lista = new List<Plan>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TM_PLAN_LISTAR]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = command.ExecuteReader()) {
                            if (dr.HasRows) {
                                while (dr.Read()) {
                                    Plan plan = new Plan();
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodTipoPlan")))
                                        plan.idCodTipoPlan = dr.GetInt32(dr.GetOrdinal("idCodTipoPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        plan.vNombre = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        plan.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        plan.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        plan.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                    Lista.Add(plan);
                                }
                            }
                        }
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Equipo ObtenerEquipoPorIMEI(Equipo entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_EQUIPO_OBTENER]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vIMEI", entidad.IMEI);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipo")))
                                        entidad.idCodEquipo = dr.GetInt32(dr.GetOrdinal("idCodEquipo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vIMEI")))
                                        entidad.IMEI = dr.GetString(dr.GetOrdinal("vIMEI"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodmodelo")))
                                        entidad.iCodModelo = dr.GetInt32(dr.GetOrdinal("iCodmodelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Modelo")))
                                        entidad.vModelo = dr.GetString(dr.GetOrdinal("Modelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodMarca")))
                                        entidad.iCodMarca = dr.GetInt32(dr.GetOrdinal("idCodMarca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Marca")))
                                        entidad.vMarca = dr.GetString(dr.GetOrdinal("Marca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                                        entidad.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Accesorio> ObtenerAccesorioPorIMEI(Equipo entidad)
        {
            List<Accesorio> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_ACCESORIO_OBTENER_X_IMEI]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vIMEI", entidad.IMEI);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                entidad.AccesorioList = new List<Accesorio>();
                                while (dr.Read())
                                {
                                    Accesorio objEnt = new Accesorio();
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipoDet")))
                                        objEnt.idCodEquipoDet = dr.GetInt32(dr.GetOrdinal("idCodEquipoDet"));
                                    if (entidad.IMEI == null)
                                    {
                                        objEnt.iTotalRecords = 0;
                                    }
                                    else
                                    {
                                        objEnt.iTotalRecords = 10;
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAccesorio")))
                                        objEnt.idCodAccesorio = dr.GetInt32(dr.GetOrdinal("idCodAccesorio"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        objEnt.vAccesorio = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                                        objEnt.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cEstado")))
                                    {
                                        objEnt.cEstado = dr.GetString(dr.GetOrdinal("cEstado"));
                                        //objEnt.vAcciones = "<span data-id='" + objEnt.idCodEquipoDet + "' class='ver ar-bullseye_solid' title='Ver'></span> ";
                                        //objEnt.vAcciones = objEnt.vAcciones + " <span data-id='" + objEnt.idCodEquipoDet + "' class='editar ar-pencil-alt_solid' title='Editar'></span>";
                                        if (objEnt.cEstado == "1"){
                                            objEnt.vAcciones = "<nav class='nav-actions'><a class='danger' data-toggle='tooltip' data-placement='top' title='Eliminar Accesorio' data-id='" + objEnt.idCodEquipoDet + "'><i class='fas fa-trash-alt'></i></a></nav>";
                                        }else if(objEnt.cEstado == "2"){
                                            objEnt.vAcciones = "<nav class='nav-actions'><a class='retornar' data-toggle='tooltip' data-placement='top' title='Devolver Accesorio' data-id='" + objEnt.idCodEquipoDet + "'><i class='fa fa-undo'></i></a><a class='ver' data-toggle='tooltip' data-placement='top' title='Ver Adjunto' data-id='" + objEnt.idCodEquipoDet + "'><i class='fas fa-eye'></i></a></nav>";
                                            //objEnt.vAcciones + " <span data-id='" + objEnt.idCodEquipoDet + "' class='retornar fa fa-undo' title='Devolver Accesorio'></span>";
                                        }
                                    }
                                    entidad.AccesorioList.Add(objEnt);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return entidad.AccesorioList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            List<Trabajador> Lista = new List<Trabajador>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqvisita].PA_PERSONAL_X_DNI_OBTENER", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@num_documento", entidad.num_documento);
                        command.Parameters.AddWithValue("@nom_trabajador", entidad.Nom_Trabajador);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Trabajador>();
                                while (dr.Read())
                                {
                                    Trabajador trabajador = new Trabajador();
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_area")))
                                        trabajador.cod_area = dr.GetString(dr.GetOrdinal("cod_area"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_area")))
                                        trabajador.dsc_area = dr.GetString(dr.GetOrdinal("dsc_area"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_empresa")))
                                        trabajador.cod_empresa = dr.GetString(dr.GetOrdinal("cod_empresa"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Tip_Personal")))
                                        trabajador.Tip_Personal = dr.GetString(dr.GetOrdinal("Tip_Personal"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_Trabajador")))
                                        trabajador.cod_Trabajador = dr.GetString(dr.GetOrdinal("cod_Trabajador"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_paterno")))
                                        trabajador.dsc_paterno = dr.GetString(dr.GetOrdinal("dsc_paterno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_materno")))
                                        trabajador.dsc_materno = dr.GetString(dr.GetOrdinal("dsc_materno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_nombres")))
                                        trabajador.dsc_nombres = dr.GetString(dr.GetOrdinal("dsc_nombres"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_estado")))
                                        trabajador.cod_estado = dr.GetString(dr.GetOrdinal("cod_estado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("flg_activo")))
                                        trabajador.flg_activo = dr.GetString(dr.GetOrdinal("flg_activo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_sexo")))
                                        trabajador.cod_sexo = dr.GetString(dr.GetOrdinal("cod_sexo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                                        trabajador.cod_tipo_documento = dr.GetString(dr.GetOrdinal("cod_tipo_documento"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("num_documento")))
                                        trabajador.num_documento = dr.GetString(dr.GetOrdinal("num_documento"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_dependencia")))
                                        trabajador.cod_dependencia = dr.GetString(dr.GetOrdinal("cod_dependencia"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_cargo")))
                                        trabajador.dsc_cargo = dr.GetString(dr.GetOrdinal("dsc_cargo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Nom_Trabajador")))
                                        trabajador.Nom_Trabajador = dr.GetString(dr.GetOrdinal("Nom_Trabajador"));

                                    if (!dr.IsDBNull(dr.GetOrdinal("vAnexo")))
                                        trabajador.vAnexo = dr.GetString(dr.GetOrdinal("vAnexo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("movil_institu")))
                                        trabajador.movil_institu = dr.GetString(dr.GetOrdinal("movil_institu"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Email_institu")))
                                        trabajador.Email_institu = dr.GetString(dr.GetOrdinal("Email_institu"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Usuario_institu")))
                                        trabajador.Usuario_institu = dr.GetString(dr.GetOrdinal("Usuario_institu"));
                                    Lista.Add(trabajador);
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

        public Plan ObtenerPlanPorNroCelular(Plan entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TM_PLAN_X_NRO_CEL_OBTENER]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodPlan")))
                                        entidad.iCodPlan = dr.GetInt32(dr.GetOrdinal("iCodPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        entidad.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodTipoPlan")))
                                        entidad.idCodTipoPlan = dr.GetInt32(dr.GetOrdinal("idCodTipoPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        entidad.vNombre = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        entidad.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        entidad.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        entidad.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_EQUIPO_ACCESORIO_CRUD]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodEquipoDet", entidad.idCodEquipoDet);
                        command.Parameters.AddWithValue("@idCodEquipo", entidad.idCodEquipo);
                        command.Parameters.AddWithValue("@idCodAccesorio", entidad.idCodAccesorio);
                        command.Parameters.AddWithValue("@vObservacion", entidad.vObservacion);
                        command.Parameters.AddWithValue("@vArchivo", entidad.vArchivo);
                        command.Parameters.AddWithValue("@iOpcion", entidad.iOpcion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipoDet")))
                                        entidad.idCodEquipoDet = dr.GetInt32(dr.GetOrdinal("idCodEquipoDet"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("bError")))
                                        entidad.bError = dr.GetBoolean(dr.GetOrdinal("bError"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vMensaje")))
                                        entidad.vMensaje = dr.GetString(dr.GetOrdinal("vMensaje"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Asignacion ObtenerAsignacionPorId(Asignacion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_ASIGNAR_OBTENER_DETALLE_X_ID]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodAsignacion", entidad.idCodAsignacion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAsignacion")))
                                        entidad.idCodAsignacion = dr.GetInt32(dr.GetOrdinal("idCodAsignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocRepsonsable")))
                                        entidad.vNroDocRepsonsable = dr.GetString(dr.GetOrdinal("vNroDocRepsonsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatResponsable")))
                                        entidad.vApePatResponsable = dr.GetString(dr.GetOrdinal("vApePatResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApeMatResponsable")))
                                        entidad.vApeMatResponsable = dr.GetString(dr.GetOrdinal("vApeMatResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombreResponsable")))
                                        entidad.vNombreResponsable = dr.GetString(dr.GetOrdinal("vNombreResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocEncargado")))
                                        entidad.vNroDocEncargado = dr.GetString(dr.GetOrdinal("vNroDocEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatEncargado")))
                                        entidad.vApePatEncargado = dr.GetString(dr.GetOrdinal("vApePatEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApeMatEncargado")))
                                        entidad.vApeMatEncargado = dr.GetString(dr.GetOrdinal("vApeMatEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombreEncargado")))
                                        entidad.vNombreEncargado = dr.GetString(dr.GetOrdinal("vNombreEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        entidad.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cEstado")))
                                        entidad.cEstado = dr.GetString(dr.GetOrdinal("cEstado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dtFechaASignacion")))
                                        entidad.dtFechaASignacion = dr.GetString(dr.GetOrdinal("dtFechaASignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vIMEI")))
                                        entidad.vIMEI = dr.GetString(dr.GetOrdinal("vIMEI"));
                                    //----------------------------------------------------------------------------------
                                    if (!dr.IsDBNull(dr.GetOrdinal("vMarca")))
                                        entidad.vMarca = dr.GetString(dr.GetOrdinal("vMarca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vModelo")))
                                        entidad.vModelo = dr.GetString(dr.GetOrdinal("vModelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        entidad.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        entidad.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        entidad.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vPlan")))
                                        entidad.vPlan = dr.GetString(dr.GetOrdinal("vPlan"));
                                    //-----------------------------------------------------------------------------------
                                    //*************************************************************************************
                                    if (!dr.IsDBNull(dr.GetOrdinal("vDependencia")))
                                        entidad.vDependencia = dr.GetString(dr.GetOrdinal("vDependencia"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vUnidad")))
                                        entidad.vUnidad = dr.GetString(dr.GetOrdinal("vUnidad"));
                                }
                            }
                            if (dr.NextResult())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        entidad.equipo = new Equipo();
                                        if (!dr.IsDBNull(dr.GetOrdinal("MODELO")))
                                            entidad.equipo.vModelo = dr.GetString(dr.GetOrdinal("MODELO"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("1")))
                                            entidad.equipo.mes1 = dr.GetDecimal(dr.GetOrdinal("1"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("2")))
                                            entidad.equipo.mes2 = dr.GetDecimal(dr.GetOrdinal("2"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("3")))
                                            entidad.equipo.mes3 = dr.GetDecimal(dr.GetOrdinal("3"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("4")))
                                            entidad.equipo.mes4 = dr.GetDecimal(dr.GetOrdinal("4"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("5")))
                                            entidad.equipo.mes5 = dr.GetDecimal(dr.GetOrdinal("5"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("6")))
                                            entidad.equipo.mes6 = dr.GetDecimal(dr.GetOrdinal("6"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("7")))
                                            entidad.equipo.mes7 = dr.GetDecimal(dr.GetOrdinal("7"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("8")))
                                            entidad.equipo.mes8 = dr.GetDecimal(dr.GetOrdinal("8"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("9")))
                                            entidad.equipo.mes9= dr.GetDecimal(dr.GetOrdinal("9"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("10")))
                                            entidad.equipo.mes10 = dr.GetDecimal(dr.GetOrdinal("10"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("11")))
                                            entidad.equipo.mes11 = dr.GetDecimal(dr.GetOrdinal("11"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("12")))
                                            entidad.equipo.mes12 = dr.GetDecimal(dr.GetOrdinal("12"));
                                    }
                                }
                            }
                            if (dr.NextResult())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        entidad.accesorio = new Accesorio();
                                        if (!dr.IsDBNull(dr.GetOrdinal("CARGADOR")))
                                            entidad.accesorio.dMontoCargador = dr.GetDecimal(dr.GetOrdinal("CARGADOR"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("AUDIFONOS")))
                                            entidad.accesorio.dMontoAudifonos = dr.GetDecimal(dr.GetOrdinal("AUDIFONOS"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("CABLE_DATOS")))
                                            entidad.accesorio.dMontoCableDatos = dr.GetDecimal(dr.GetOrdinal("CABLE_DATOS"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("ADAPTADOR")))
                                            entidad.accesorio.dMontoAdaptador = dr.GetDecimal(dr.GetOrdinal("ADAPTADOR"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("SIMCARD")))
                                            entidad.accesorio.dMontoSimCard = dr.GetDecimal(dr.GetOrdinal("SIMCARD"));
                                    }
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad) {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_OBTENER_IMG_X_ACCESORIO]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodEquipoDet", entidad.idCodEquipoDet);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("vArchivo")))
                                        entidad.vArchivo = dr.GetString(dr.GetOrdinal("vArchivo"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Equipo> ObtenerEquiposDisponiblePorIMEI(Equipo entidad)
        {
            List<Equipo> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("eqmoviles.PA_OBTENER_EQP_DISP_X_IMEI", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vIMEI", entidad.IMEI);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Equipo>();
                                while (dr.Read())
                                {
                                    Equipo objEnt = new Equipo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipo")))
                                        objEnt.idCodEquipo = dr.GetInt32(dr.GetOrdinal("idCodEquipo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vIMEI")))
                                        objEnt.IMEI = dr.GetString(dr.GetOrdinal("vIMEI"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodmodelo")))
                                        objEnt.iCodModelo = dr.GetInt32(dr.GetOrdinal("iCodmodelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Modelo")))
                                        objEnt.vModelo = dr.GetString(dr.GetOrdinal("Modelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodMarca")))
                                        objEnt.iCodMarca = dr.GetInt32(dr.GetOrdinal("idCodMarca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Marca")))
                                        objEnt.vMarca = dr.GetString(dr.GetOrdinal("Marca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                                        objEnt.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                                    Lista.Add(objEnt);
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

        public List<Plan> ObtenerCelulareDisponiblePorNroCelular(Plan entidad)
        {
            List<Plan> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("eqmoviles.PA_OBTENER_PLAN_DISP_X_CELULAR", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Plan>();
                                while (dr.Read())
                                {
                                    Plan objEnt = new Plan();
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodPlan")))
                                        objEnt.iCodPlan = dr.GetInt32(dr.GetOrdinal("iCodPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        objEnt.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodTipoPlan")))
                                        objEnt.idCodTipoPlan = dr.GetInt32(dr.GetOrdinal("idCodTipoPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        objEnt.vNombre = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        objEnt.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        objEnt.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        objEnt.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                    Lista.Add(objEnt);
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