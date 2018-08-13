using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApi.Controllers
{
    public class AsignarController : System.Web.Http.ApiController
    {
        AsignarService asignarService;

        public AsignarController()
        {
            asignarService = new AsignarService();
        }

        //[Authorize]
        [HttpPost]
        [ActionName("ListadoEquiposAsignados")]
        public List<Asignacion> ListadoEquiposAsignados(Asignacion entidad)
        {
            try
            {
                return asignarService.ListadoEquiposAsignados(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoCliente")]
        public List<Cliente> ListadoCliente()
        {
            try
            {
                return asignarService.ListadoCliente();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarDepartamento")]
        public List<Ubigeo> ListarDepartamento()
        {
            try
            {
                return asignarService.ListarDepartamento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarProvincia")]
        public List<Ubigeo> ListarProvincia(Ubigeo entidad)
        {
            try
            {
                return asignarService.ListarProvincia(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarDistrito")]
        public List<Ubigeo> ListarDistrito(Ubigeo entidad)
        {
            try
            {
                return asignarService.ListarDistrito(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarResponsablePorDni")]
        public Responsable BuscarResponsablePorDni(Responsable entidad)
        {
            try
            {
                return asignarService.BuscarResponsablePorDni(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarPlanes")]
        public List<Plan> ListarPlanes()
        {
            try
            {
                return asignarService.ListarPlanes();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerEquipoPorIMEI")]
        public Equipo ObtenerEquipoPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarService.ObtenerEquipoPorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarTrabajador")]
        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            try
            {
                return asignarService.BuscarTrabajador(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerAccesorioPorIMEI")]
        public List<Accesorio> ObtenerAccesorioPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarService.ObtenerAccesorioPorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerPlanPorNroCelular")]
        public Plan ObtenerPlanPorNroCelular(Plan entidad)
        {
            try
            {
                return asignarService.ObtenerPlanPorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("AccesorioCRUD")]
        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                return asignarService.AccesorioCRUD(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("AsignacionCRUD")]
        public Asignacion AsignacionCRUD(Asignacion entidad)
        {
            try
            {
                return asignarService.AsignacionCRUD(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerAsignacionPorId")]
        public Asignacion ObtenerAsignacionPorId(Asignacion entidad)
        {
            try
            {
                return asignarService.ObtenerAsignacionPorId(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerImgPorAccesorio")]
        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad)
        {
            try
            {
                return asignarService.ObtenerImgPorAccesorio(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerEquipoDisponiblePorIMEI")]
        public List<Equipo> ObtenerEquiposDisponiblePorIMEI(Equipo entidad)
        {
            try
            {
                return asignarService.ObtenerEquiposDisponiblePorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerCelulareDisponiblePorNroCelular")]
        public List<Plan> ObtenerCelulareDisponiblePorNroCelular(Plan entidad)
        {
            try
            {
                return asignarService.ObtenerCelulareDisponiblePorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}