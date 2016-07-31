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
    public class JogadorController : ApiController
    {
        private ICampeonatoFacade campeonatoFacade;

        public JogadorController()
        {
            campeonatoFacade = new CampeonatoFacade();
        }

        // GET: api/Jogador/Campeonato/5
        [HttpGet]
        public IEnumerable<JogadorView> Get(bool campeonato, int CampeonatoId)
        {
            return Mapper.Map<IList<Jogador>, IList<JogadorView>>(campeonatoFacade.ListarJogadores(CampeonatoId));
        }

        // GET: api/Jogador/5
        [HttpGet]
        public JogadorView Get(int id)
        {
            return Mapper.Map<JogadorView>(campeonatoFacade.ConsultarJogador(new Jogador() { JogadorId = id }));
        }

        // POST: api/Jogador
        [HttpPost]
        public Resultado Post(int id, [FromBody]JogadorView jogador)
        {
            return campeonatoFacade.CriarJogador(Mapper.Map<Jogador>(jogador), id);
        }

        [HttpPost]
        public Resultado AssociarCampeonato([FromBody]JogadorCampeonatoView jogadorCampeonato)
        {
            Jogador jogador = new Jogador() { JogadorId = jogadorCampeonato.JogadorId };
            Campeonato campeonato = new Campeonato() { CampeonatoId = jogadorCampeonato.CampeonatoId };

            return campeonatoFacade.AssociarJogadorCampeonato(jogador, campeonato);
        }

        // PUT: api/Jogador/5
        [HttpPut]
        public Resultado Put(int id, [FromBody]JogadorView jogador)
        {
            jogador.JogadorId = id;
            return campeonatoFacade.AlterarJogador(Mapper.Map<Jogador>(jogador));
        }

        // DELETE: api/Jogador/5
        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    return campeonatoFacade.
        //}
    }
}
