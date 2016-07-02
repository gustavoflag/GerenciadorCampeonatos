using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Bandeira.GerenciadorCampeonatos.WebAPI.Startup))]
namespace Bandeira.GerenciadorCampeonatos.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}