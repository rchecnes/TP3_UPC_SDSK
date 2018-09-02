using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApiMovil.Controllers
{
    public class UsuarioController : System.Web.Http.ApiController
    {
        UsuarioService usuario;

        public UsuarioController()
        {
            usuario = new UsuarioService();
        }

        [HttpPost]
        [ActionName("ValidarUsuario")]
        public List<Usuario> ValidarUsuario(Usuario entidad)
        {
            try
            {
                return usuario.ValidarUsuario(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}