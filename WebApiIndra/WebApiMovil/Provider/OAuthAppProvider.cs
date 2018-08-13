using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApiMovil.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                return Task.Factory.StartNew(() =>
                {
                    //var username = context.UserName;
                    //var password = context.Password;
                    //var usuarioService = new UsuarioService();
                    //Usuario usuario = usuarioService.ObtenerAccesoDominio(new Usuario(username, password));
                    //if (usuario != null)
                    //{
                    //    var claims = new List<Claim>()
                    //{
                    //    new Claim(ClaimTypes.Name, usuario.vUsuario),
                    //    new Claim("UserID",  usuario.iCodUsuario.ToString())
                    //};

                    //    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    //    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                    //}
                    //else
                    //{
                    //    context.SetError("invalid_grant", "Error");
                    //}
                });
            }
            catch (System.Exception)
            {
                throw;
            }

        }




        //public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        //{
        //    Usuario usuario = new Usuario();
        //    return base.TokenEndpoint(context);
        //}

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }




    }
}