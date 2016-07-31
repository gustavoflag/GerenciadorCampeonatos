using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    public interface IPartidaFacade
    {
        Resultado AlterarLocal(Local local);
        Resultado ApagaResultadoPartida(ResultadoPartida resultadoPartida);
        Competidor ConsultarCompetidor(string nomeJogador, int partidaId);
        Partida ConsultarPartida(Partida partida);
        Resultado CriarCompetidor(Competidor competidor);
        Resultado CriarLocal(Local local);
        Resultado CriarPartida(Partida partida);
        Resultado CriarPartidas(IList<Partida> partidas);
        Resultado ExcluirLocal(Local local);
        Resultado InsereResultadoPartida(Partida partida, Competidor competidor, Pontuacao pontuacao, int valor);
        IList<Local> ListarLocais(int campeonatoId);
        IList<Local> ListarLocais();
        IList<Partida> ListarPartidas(int campeonatoId, int rodadaNumero);
        Local ConsultarLocal(Local local);
    }
}
