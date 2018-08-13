using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class AsignarService
    {
        private AsignarBL asignarBL;

        public AsignarService()
        {
            asignarBL = new AsignarBL();
        }

        public List<Asignacion> ListadoEquiposAsignados(Asignacion entidad)
        {
            try
            {
                return asignarBL.ListadoEquiposAsignados(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Cliente> ListadoCliente()
        {
            try
            {
                return asignarBL.ListadoCliente();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Ubigeo> ListarDepartamento()
        {
            try
            {
                return asignarBL.ListarDepartamento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ubigeo> ListarProvincia(Ubigeo entidad)
        {
            try
            {
                return asignarBL.ListarProvincia(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ubigeo> ListarDistrito(Ubigeo entidad)
        {
            try
            {
                return asignarBL.ListarDistrito(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Responsable BuscarResponsablePorDni(Responsable entidad)
        {
            try
            {
                return asignarBL.BuscarResponsablePorDni(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Plan> ListarPlanes()
        {
            try
            {
                return asignarBL.ListarPlanes();
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
                return asignarBL.ObtenerEquipoPorIMEI(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            try
            {
                return asignarBL.BuscarTrabajador(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Accesorio> ObtenerAccesorioPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarBL.ObtenerAccesorioPorIMEI(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Plan ObtenerPlanPorNroCelular(Plan entidad)
        {
            try
            {
                return asignarBL.ObtenerPlanPorNroCelular(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                return asignarBL.AccesorioCRUD(entidad);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Asignacion AsignacionCRUD(Asignacion entidad)
        {
            try
            {
                return asignarBL.AsignacionCRUD(entidad);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Asignacion ObtenerAsignacionPorId(Asignacion entidad)
        {
            try
            {
                return asignarBL.ObtenerAsignacionPorId(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad)
        {
            try
            {
                return asignarBL.ObtenerImgPorAccesorio(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Equipo> ObtenerEquiposDisponiblePorIMEI(Equipo entidad)
        {
            try
            {
                return asignarBL.ObtenerEquiposDisponiblePorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Plan> ObtenerCelulareDisponiblePorNroCelular(Plan entidad)
        {
            try
            {
                return asignarBL.ObtenerCelulareDisponiblePorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}