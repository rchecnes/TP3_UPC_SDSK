using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApiMovil.Controllers
{
    public class ResponsableController : System.Web.Http.ApiController
    {

        ResponsableService responsable;

        public ResponsableController()
        {
            responsable = new ResponsableService();
        }

        [HttpPost]
        [ActionName("ListadoCargo")]
        public List<Cargo> ListadoCargo()
        {
            try
            {
                return responsable.ListadoCargo();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoNivel")]
        public List<Nivel> ListadoNivel()
        {
            try
            {
                return responsable.ListadoNivel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoUsuarioResponsable")]
        public List<UsuarioResponsable> ListadoUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                return responsable.ListadoUsuarioResponsable(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarUsuarioResponsable")]
        public string InsertarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                return responsable.InsertarUsuarioResponsable(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarUsuarioResponsable")]
        public List<UsuarioResponsable> EditarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                return responsable.EditarUsuarioResponsable(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarUsuarioResponsable")]
        public string ActualizarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                return responsable.ActualizarUsuarioResponsable(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarUsuarioResponsable")]
        public string EliminarUsuarioResponsable(UsuarioResponsable entidad)
        {
            try
            {
                return responsable.EliminarUsuarioResponsable(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
