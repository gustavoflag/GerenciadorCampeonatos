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

        Campeonato ConsultarCampeonato(Campeonato campeonato);

        //Rodada
        Resultado CriarRodada(Rodada rodada);

        Resultado ApagarRodada(Rodada rodada);

        IList<Rodada> ListarRodadas(int campeonatoId);

        Resultado CriarRodadas(int campeonatoId, int quantidade);

        //Pontuação
        Resultado CriarPontuacao(Pontuacao pontuacao);

        Resultado CriarPontuacoes(IList<Pontuacao> pontuacoes);

        IList<Pontuacao> ListarAtivos(int campeonatoId);

        IList<Pontuacao> ListarInativos(int campeonatoId);

        IList<Pontuacao> ListarPontuacoes(int campeonatoId);

        //Jogador
        Resultado CriarJogador(Jogador jogador, int campeonatoId);

        Resultado AlterarJogador(Jogador jogador);

        Jogador ConsultarJogador(Jogador jogador);

        IList<Jogador> ListarJogadores(int campeonatoId);

        Resultado AssociarJogadorCampeonato(Jogador jogador, Campeonato campeonato);

        Resultado DesassociarJogadorCampeonato(JogadorCampeonato jogadorCampeonato);
    }
}
