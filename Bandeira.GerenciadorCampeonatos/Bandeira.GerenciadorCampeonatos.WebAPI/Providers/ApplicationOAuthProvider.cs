using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Model;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IAcessoFacade acessoFacade;

        public ApplicationOAuthProvider()
        {
            acessoFacade = new AcessoFacade();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext c)
        {
            c.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext c)
        { 
            Resultado<Usuario> resultadoLogin = acessoFacade.Login(c.UserName, c.Password);  

            if (resultadoLogin.Sucesso)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, c.UserName));

                if (resultadoLogin.Retorno.Perfil.PermissaoAcesso)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Acesso"));
                }

                if (resultadoLogin.Retorno.Perfil.PermissaoCampeonato)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Campeonato"));
                }

                if (resultadoLogin.Retorno.Perfil.PermissaoPartida)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Partida"));
                }

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(
                       claims, OAuthDefaults.AuthenticationType);
                c.Validated(claimsIdentity);
            }
            else
            {
                c.SetError("Acesso negado", resultadoLogin.ToString());
            }

            return Task.FromResult<object>(null);
        }
    }
}