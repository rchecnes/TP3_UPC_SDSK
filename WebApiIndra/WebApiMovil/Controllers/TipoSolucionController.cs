using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiIndra.Services;
using WebApiMovil.Models;

namespace WebApi.Controllers
{

    public class TipoSolucionController : System.Web.Http.ApiController
    {
        TipoSolucionService tiposolucion;

        public TipoSolucionController()
        {
            tiposolucion = new TipoSolucionService();
        }

        [HttpPost]
        [ActionName("ListadoTipoSolucion")]
        public List<TipoSolucion> ListadoTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                return tiposolucion.ListadoTipoSolucion(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoCategoria")]
        public List<Categoria> ListadoCategoria()
        {
            try
            {
                return tiposolucion.ListadoCategoria();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoTipoProblema")]
        public List<TipoProblema> ListadoTipoProblema()
        {
            try
            {
                return tiposolucion.ListadoTipoProblema();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarTipoSolucion")]
        public string InsertarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
               return tiposolucion.InsertarTipoSolucion(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarTipoSolucion")]
        public List<TipoSolucion> EditarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                return tiposolucion.EditarTipoSolucion(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarTipoSolucion")]
        public string ActualizarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                return tiposolucion.ActualizarTipoSolucion(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarTipoSolucion")]
        public string EliminarTipoSolucion(TipoSolucion entidad)
        {
            try
            {
                return tiposolucion.EliminarTipoSolucion(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
