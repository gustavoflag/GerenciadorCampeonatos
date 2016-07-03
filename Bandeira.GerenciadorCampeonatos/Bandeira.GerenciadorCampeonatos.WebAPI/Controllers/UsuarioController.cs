using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        private IAcessoFacade acessoFacade;

        public UsuarioController()
        {
            acessoFacade = new AcessoFacade();
        }

        // GET api/usuario
        [Authorize]
        public IList<Usuario> Get()
        {
            return acessoFacade.ListarUsuarios();
        }
    }
}
