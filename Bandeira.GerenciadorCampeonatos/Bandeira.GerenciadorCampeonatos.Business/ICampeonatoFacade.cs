using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public interface ICampeonatoFacade
    {
        //Campeonato
        Resultado CriarCampeonato(Campeonato campeonato);

        Resultado AlterarCampeonato(Campeonato campeonato);

        Resultado ExcluirCampeonato(Campeonato campeonato);

        //Rodada
        Resultado CriarRodada(Rodada rodada);

        Resultado ApagarRodada(Rodada rodada);

        IList<Rodada> ListarRodadas(int campeonatoId);

        //Pontuação
        Resultado CriarPontuacao(Pontuacao pontuacao);

        Resultado CriarPontuacoes(IList<Pontuacao> pontuacoes);

        IList<Pontuacao> ListarAtivos(int campeonatoId);

        IList<Pontuacao> ListarInativos(int campeonatoId);

        IList<Pontuacao> ListarPontuacoes(int campeonatoId);

        //Jogador
        Resultado CriarJogador(Jogador jogador);

        Resultado AlterarJogador(Jogador jogador);

        IList<Jogador> ListarJogadores(int campeonatoId);
    }
}
