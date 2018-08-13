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
        public List<TipoSolucion> ListadoTipoSolucion()
        {
            try
            {
                return tiposolucion.ListadoTipoSolucion();
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
    }
}
