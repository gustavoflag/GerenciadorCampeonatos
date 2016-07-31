using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Business.Process;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Controllers
{
    [Authorize(Roles = "Partida")]
    public class LocalController : ApiController
    {
        private IPartidaFacade partidaFacade;

        public LocalController()
        {
            partidaFacade = new PartidaFacade();
        }

        // GET: api/Local
        public IEnumerable<LocalView> Get()
        {
            return Mapper.Map<IList<Local>, IList<LocalView>>(partidaFacade.ListarLocais());
        }

        // GET: api/Local
        public IEnumerable<LocalView> Get(bool campeonato, int CampeonatoId)
        {
            return Mapper.Map<IList<Local>, IList<LocalView>>(partidaFacade.ListarLocais(CampeonatoId));
        }

        // GET: api/Local/5
        public LocalView Get(int id)
        {
            return Mapper.Map<LocalView>(partidaFacade.ConsultarLocal(new Local() { LocalId = id }));
        }

        // POST: api/Local
        public Resultado Post([FromBody]LocalView localView)
        {
            return partidaFacade.CriarLocal(Mapper.Map<Local>(localView));
        }

        // PUT: api/Local/5
        public Resultado Put(int id, [FromBody]LocalView localView)
        {
            return partidaFacade.AlterarLocal(Mapper.Map<Local>(localView));
        }

        // DELETE: api/Local/5
        public Resultado Delete(int id)
        {
            return partidaFacade.ExcluirLocal(new Local() { LocalId = id });
        }
    }
}
