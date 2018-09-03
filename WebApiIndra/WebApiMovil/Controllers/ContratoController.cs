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
    public class ContratoController : System.Web.Http.ApiController
    {
        ContratoService contratoService;

        public ContratoController()
        {
            contratoService = new ContratoService();
        }

        [HttpPost]
        [ActionName("ListadoContrato")]
        public List<Contrato> ListadoContrato(Contrato entidad)
        {
            try
            {
                return contratoService.ListadoContrato(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("InsertarContrato")]
        public string InsertarContrato(Contrato entidad)
        {
            try
            {
                return contratoService.InsertarContrato(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EditarContrato")]
        public List<Contrato> EditarContrato(Contrato entidad)
        {
            try
            {
                return contratoService.EditarContrato(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ActualizarContrato")]
        public string ActualizarContrato(Contrato entidad)
        {
            try
            {
                return contratoService.ActualizarContrato(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarContrato")]
        public string EliminarContrato(Contrato entidad)
        {
            try
            {
                return contratoService.EliminarContrato(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
