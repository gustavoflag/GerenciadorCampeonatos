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


        //Rodada
        Resultado CriarRodada(Rodada rodada);

        Resultado ApagarRodada(Rodada rodada);

        //Pontuação
        Resultado CriarPontuacao(Pontuacao pontuacao);

        Resultado CriarPontuacoes(IList<Pontuacao> pontuacoes);
    }
}
