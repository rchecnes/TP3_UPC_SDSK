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
    public class EncuestaController : System.Web.Http.ApiController
    {
        EncuestaService encuestaService;

        public EncuestaController()
        {
            encuestaService = new EncuestaService();
        }

        [HttpPost]
        [ActionName("ListadoTicketAtendido")]
        public List<Ticket> ListadoTicketAtendido(Ticket entidad)
        {
            try
            {
                return encuestaService.ListadoTicketAtendido(entidad);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoPreguntaEncuesta")]
        public List<TipoEncuestaPregunta> ListadoPreguntaEncuesta()
        {
            try
            {
                return encuestaService.ListadoPreguntaEncuesta();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
