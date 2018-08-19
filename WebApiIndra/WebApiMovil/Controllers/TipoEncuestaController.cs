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
    public class TipoEncuestaController : System.Web.Http.ApiController
    {

        TipoEncuestaService tipoencuesta;

        public TipoEncuestaController()
        {
            tipoencuesta = new TipoEncuestaService();
        }

        [HttpPost]
        [ActionName("ListadoTipoEncuesta")]
        public List<TipoEncuesta> ListadoTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                return tipoencuesta.ListadoTipoEncuesta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarTipoEncuesta")]
        public string InsertarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                return tipoencuesta.InsertarTipoEncuesta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarTipoEncuesta")]
        public List<TipoEncuesta> EditarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                return tipoencuesta.EditarTipoEncuesta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarTipoEncuesta")]
        public string ActualizarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                return tipoencuesta.ActualizarTipoEncuesta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarTipoEncuesta")]
        public string EliminarTipoEncuesta(TipoEncuesta entidad)
        {
            try
            {
                return tipoencuesta.EliminarTipoEncuesta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarTipoEncuestaPregunta")]
        public string InsertarTipoEncuestaPregunta(TipoEncuestaPregunta entidad)
        {
            try
            {
                return tipoencuesta.InsertarTipoEncuestaPregunta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoTipoEncuestaPregunta")]
        public List<TipoEncuestaPregunta> ListadoTipoEncuestaPregunta(TipoEncuestaPregunta entidad)
        {
            try
            {
                return tipoencuesta.ListadoTipoEncuestaPregunta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarPregunta")]
        public List<Pregunta> BuscarPregunta(TipoEncuestaPregunta entidad)
        {
            try
            {
                return tipoencuesta.BuscarPregunta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarTipoEncuestaPregunta")]
        public string EliminarTipoEncuestaPregunta(TipoEncuestaPregunta entidad)
        {
            try
            {
                return tipoencuesta.EliminarTipoEncuestaPregunta(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
