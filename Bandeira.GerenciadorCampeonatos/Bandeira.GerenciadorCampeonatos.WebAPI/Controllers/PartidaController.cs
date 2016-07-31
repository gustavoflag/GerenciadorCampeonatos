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
    [Authorize]
    public class PartidaController : ApiController
    {
        private IPartidaFacade partidaFacade;

        public PartidaController()
        {
            partidaFacade = new PartidaFacade();
        }

        // GET: api/Partida
        public IEnumerable<PartidaView> Get(int idCampeonato, int rodadaNumero)
        {
            return Mapper.Map<IList<Partida>, IList<PartidaView>>(partidaFacade.ListarPartidas(idCampeonato, rodadaNumero));
        }

        // GET: api/Partida/5
        public PartidaView Get(int id)
        {
            return Mapper.Map<PartidaView>(partidaFacade.ConsultarPartida(new Partida() { PartidaId = id }));
        }

        // POST: api/Partida
        public Resultado Post([FromBody]PartidaView partidaView)
        {
            return partidaFacade.CriarPartida(Mapper.Map<Partida>(partidaView));
        }

        // PUT: api/Partida/5
        //public void Put(int id, [FromBody]string value)
        //{
            
        //}

        // DELETE: api/Partida/5
        public void Delete(int id)
        {
        }
    }
}
