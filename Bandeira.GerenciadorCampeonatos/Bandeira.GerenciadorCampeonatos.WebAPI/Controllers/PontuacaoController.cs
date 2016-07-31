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
    public class PontuacaoController : ApiController
    {
        private ICampeonatoFacade campeonatoFacade;

        public PontuacaoController()
        {
            campeonatoFacade = new CampeonatoFacade();
        }

        // GET: api/Pontuacao
        public IEnumerable<PontuacaoView> Get(int id)
        {
            return Mapper.Map<IList<PontuacaoView>>(campeonatoFacade.ListarPontuacoes(id));
        }

        // POST: api/Pontuacao
        public Resultado Post([FromBody]PontuacaoView pontuacao)
        {
            return campeonatoFacade.CriarPontuacao(Mapper.Map<Pontuacao>(pontuacao));
        }
    }
}
