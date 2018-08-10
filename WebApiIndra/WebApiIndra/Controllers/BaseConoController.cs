using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiIndra.Models;
using WebApiIndra.Services;

namespace WebApiIndra.Controllers
{

    public class BaseConoController : System.Web.Http.ApiController
    {
        BaseConoService baseService;

        public BaseConoController()
        {
            baseService = new BaseConoService();
        }

        [HttpGet]
        [ActionName("ListadoBaseConocimiento")]
        public List<SD_BaseConocimiento> ListadoBaseConocimiento()
        {
            try
            {
                return baseService.ListadoBaseConocimiento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
