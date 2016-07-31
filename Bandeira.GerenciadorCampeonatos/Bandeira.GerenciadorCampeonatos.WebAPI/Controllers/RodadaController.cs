using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Business;
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
    [Authorize(Roles = "Campeonato")]
    public class RodadaController : ApiController
    {
        private ICampeonatoFacade campeonatoFacade;

        public RodadaController()
        {
            campeonatoFacade = new CampeonatoFacade();
        }

        // GET: api/Rodada
        public IEnumerable<RodadaView> Get(int id)
        {
            return Mapper.Map<IList<RodadaView>>(campeonatoFacade.ListarRodadas(id));
        }

        // POST: api/Rodada
        public Resultado Post([FromBody]RodadaView rodada)
        {
            return campeonatoFacade.CriarRodada(Mapper.Map<Rodada>(rodada));
        }

        // DELETE: api/Rodada/5
        public Resultado Delete(int id)
        {
            return campeonatoFacade.ApagarRodada(new Rodada() { RodadaId = id });
        }
    }
}
