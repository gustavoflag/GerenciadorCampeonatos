using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Filters;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Controllers
{
    public class CampeonatoController : ApiController
    {
        private ICampeonatoFacade campeonatoFacade;

        public CampeonatoController()
        {
            campeonatoFacade = new CampeonatoFacade();
        }

        // GET: api/Campeonato
        //public IEnumerable<CampeonatoView> Get()
        //{
        //    //return campeonatoFacade.
        //}

        // GET: api/Campeonato/5
        [HttpGet]
        [Authorize(Roles = "Campeonato")]
        public CampeonatoView Get(int id)
        {
            return Mapper.Map<CampeonatoView>(campeonatoFacade.ConsultarCampeonato(new Campeonato() { CampeonatoId = id }));
        }

        [HttpPost]
        [ActionName("ListarClassificacao")]
        public IList<JogadorPontosView> ListarClassificacao()
        {
            var classificacao = Mapper.Map<IList<JogadorPontosView>>(campeonatoFacade.ListarClassificacao(1));

            return classificacao.OrderByDescending(c => c.Pontos).ToList();
        }

        // POST: api/Campeonato
        [HttpPost]
        [ValidateModel()]
        [Authorize(Roles = "Campeonato")]
        public Resultado Post([FromBody]CampeonatoView campeonato)
        {
            return campeonatoFacade.CriarCampeonato(Mapper.Map<Campeonato>(campeonato));
        }

        // PUT: api/Campeonato/5
        [HttpPut]
        [ValidateModel()]
        [Authorize(Roles = "Campeonato")]
        public Resultado Put(int id, [FromBody]CampeonatoView campeonato)
        {
            campeonato.CampeonatoId = id;
            return campeonatoFacade.AlterarCampeonato(Mapper.Map<Campeonato>(campeonato));
        }

        // DELETE: api/Campeonato/5
        [HttpDelete]
        [Authorize(Roles = "Campeonato")]
        public Resultado Delete(int id)
        {
            return campeonatoFacade.ExcluirCampeonato(new Campeonato() { CampeonatoId = id });
        }
    }
}
