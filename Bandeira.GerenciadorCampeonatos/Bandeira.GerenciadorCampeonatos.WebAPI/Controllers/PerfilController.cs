using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Filters;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Controllers
{
    [Authorize(Roles = "Acesso")]
    public class PerfilController : ApiController
    {
        private IAcessoFacade acessoFacade;

        public PerfilController()
        {
            acessoFacade = new AcessoFacade();
        }

        // GET: api/Perfil
        public IEnumerable<PerfilView> Get()
        {
            return Mapper.Map<IList<Perfil>, IList<PerfilView>>(acessoFacade.ListarPerfis());
        }

        // GET: api/Perfil/5
        public PerfilView Get(int id)
        {
            return Mapper.Map<PerfilView>(acessoFacade.ConsultarPerfil(new Perfil() { PerfilId = id }));
        }

        // POST: api/Perfil
        [ValidateModel()]
        public Resultado Post([FromBody]PerfilView perfil)
        {
            return acessoFacade.CriarPerfil(Mapper.Map<Perfil>(perfil));
        }

        // PUT: api/Perfil/5
        [ValidateModel()]
        public Resultado Put(int id, [FromBody]PerfilView perfil)
        {
            perfil.PerfilId = id;

            return acessoFacade.AlterarPerfil(Mapper.Map<Perfil>(perfil));
        }

        // DELETE: api/Perfil/5
        public Resultado Delete(int id)
        {
            return acessoFacade.ExcluirPerfil(new Perfil() { PerfilId = id });
        }
    }
}
