using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Model;
using Microsoft.Owin.Security.OAuth;
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
            Resultado resultadoLogin = acessoFacade.Login(c.UserName, c.Password);  

            if (resultadoLogin.Sucesso)
            {
                Claim claim1 = new Claim(ClaimTypes.Name, c.UserName);
                Claim[] claims = new Claim[] { claim1 };
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