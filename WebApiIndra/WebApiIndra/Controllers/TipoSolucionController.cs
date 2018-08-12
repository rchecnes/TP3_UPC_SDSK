using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiIndra.Models;
using WebApiIndra.Services;

namespace WebApiIndra.Controllers
{

    public class TipoSolucionController : System.Web.Http.ApiController
    {
        TipoSolucionService tiposolucion;

        public TipoSolucionController()
        {
            tiposolucion = new TipoSolucionService();
        }

        [HttpGet]
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

        [HttpGet]
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
