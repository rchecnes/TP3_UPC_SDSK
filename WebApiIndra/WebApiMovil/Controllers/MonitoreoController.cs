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
    public class MonitoreoController : System.Web.Http.ApiController
    {
        MonitoreoService monitoreoService;

        public MonitoreoController()
        {
            monitoreoService = new MonitoreoService();
        }

        [HttpPost]
        [ActionName("ListadoContratoMonitoreo")]
        public List<Contrato> ListadoContratoMonitoreo(Contrato entidad)
        {
            try
            {
                return monitoreoService.ListadoContratoMonitoreo(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListadoLogroMonitoreo")]
        public List<ContratoSLA> ListadoLogroMonitoreo(ContratoSLA entidad)
        {
            try
            {
                return monitoreoService.ListadoLogroMonitoreo(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
