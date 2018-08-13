using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class AsignarBL
    {
        private AsignarDA asignarDA;

        public AsignarBL()
        {
            asignarDA = new AsignarDA();
        }

        public List<Asignacion> ListadoEquiposAsignados(Asignacion entidad)
        {
            try
            {
                return asignarDA.ListadoEquiposAsignados(entidad);
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
                return asignarDA.ListadoCliente();
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
                return asignarDA.ListarDepartamento();
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
                return asignarDA.ListarProvincia(entidad);
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
                return asignarDA.ListarDistrito(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Responsable BuscarResponsablePorDni(Responsable entidad) {
            try
            {
                return asignarDA.BuscarResponsablePorDni(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Plan> ListarPlanes() {
            try
            {
                return asignarDA.ListarPlanes();
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
                return asignarDA.ObtenerEquipoPorIMEI(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            try
            {
                return asignarDA.BuscarTrabajador(entidad);
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
                return asignarDA.ObtenerAccesorioPorIMEI(entidad);
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
                return asignarDA.ObtenerPlanPorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                return asignarDA.AccesorioCRUD(entidad);
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
                return asignarDA.AsignacionCRUD(entidad);
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
                return asignarDA.ObtenerAsignacionPorId(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad)
        {
            try
            {
                return asignarDA.ObtenerImgPorAccesorio(entidad);
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
                return asignarDA.ObtenerEquiposDisponiblePorIMEI(entidad);
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
                return asignarDA.ObtenerCelulareDisponiblePorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}