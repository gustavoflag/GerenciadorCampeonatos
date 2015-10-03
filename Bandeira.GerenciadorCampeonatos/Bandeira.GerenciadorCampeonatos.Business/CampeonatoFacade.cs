using Bandeira.GerenciadorCampeonatos.Business.Process;
using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class CampeonatoFacade : ICampeonatoFacade
    {
        private CampeonatoProcess campeonatoProcess;
        private RodadaProcess rodadaProcess;
        private PontuacaoProcess pontuacaoProcess;
        private JogadorProcess jogadorProcess;
        private IContainer container;

        public CampeonatoFacade()
            : this(new GerenciadorCampeonatosContainer())
        {
        }

        public CampeonatoFacade(IContainer container)
        {
            this.container = container;
            campeonatoProcess = new CampeonatoProcess(container);
            rodadaProcess = new RodadaProcess(container);
            pontuacaoProcess = new PontuacaoProcess(container);
            jogadorProcess = new JogadorProcess(container);
        }

        /*public CampeonatoFacade(IProcess<Campeonato> campeonatoProcess
                               , IProcess<Rodada> rodadaProcess
                               , IProcess<Pontuacao> pontuacaoProcess
                               , IProcess<Jogador> jogadorProcess)
        {
            this.campeonatoProcess = campeonatoProcess;
            this.rodadaProcess = rodadaProcess;
            this.pontuacaoProcess = pontuacaoProcess;
            this.jogadorProcess = jogadorProcess;
        }*/

        //Campeonato
        public Resultado CriarCampeonato(Campeonato campeonato)
        {
            Resultado resultado = campeonatoProcess.Incluir(campeonato);

            if (resultado.Sucesso)
                container.SaveChanges();

            return resultado;
        }

        public Resultado AlterarCampeonato(Campeonato campeonato)
        {
            Resultado resultado = campeonatoProcess.Alterar(campeonato);

            if (resultado.Sucesso)
                container.SaveChanges();

            return resultado;
        }

        public Resultado ExcluirCampeonato(Campeonato campeonato)
        {
            Resultado resultado = campeonatoProcess.Excluir(campeonato);

            if (resultado.Sucesso)
                container.SaveChanges();

            return resultado;
        }

        //Rodada
        public Resultado CriarRodada(Rodada rodada)
        {
            Resultado resultado = rodadaProcess.Incluir(rodada);

            if (resultado.Sucesso)  
                container.SaveChanges();

            return resultado;
        }

        public Resultado ApagarRodada(Rodada rodada)
        {
            Resultado resultado = rodadaProcess.Excluir(rodada);

            if (resultado.Sucesso)
                container.SaveChanges();

            return resultado;
        }

        //Pontuação
        private Resultado InativaPontuacoesAtivasPreExistentes(Pontuacao pontuacao)
        {
            Resultado resultado = new Resultado();

            IList<Pontuacao> pontuacaoJaExistente = pontuacaoProcess.Consultar(pontuacao);

            if (pontuacaoJaExistente != null)
            {
                foreach (Pontuacao pontuacaoBase in pontuacaoJaExistente)
                {
                    pontuacaoBase.Ativo = false;
                    resultado.Merge(pontuacaoProcess.Alterar(pontuacaoBase));

                    if (!resultado.Sucesso)
                        break;
                }
            }

            return resultado;
        }

        public Resultado CriarPontuacao(Pontuacao pontuacao)
        {
            Resultado resultado = InativaPontuacoesAtivasPreExistentes(pontuacao);

            if (resultado.Sucesso)
            {
                pontuacao.DtCadastro = DateTime.Now;
                resultado.Merge(pontuacaoProcess.Incluir(pontuacao));

                if (resultado.Sucesso)
                    container.SaveChanges();
            }

            return resultado;
        }

        public Resultado CriarPontuacoes(IList<Pontuacao> pontuacoes)
        {
            Resultado resultado = new Resultado();

            foreach (Pontuacao pontuacao in pontuacoes)
            {
                resultado.Merge(InativaPontuacoesAtivasPreExistentes(pontuacao));

                if (resultado.Sucesso)
                {
                    pontuacao.DtCadastro = DateTime.Now;
                    resultado.Merge(pontuacaoProcess.Incluir(pontuacao));
                }
                
                if (!resultado.Sucesso)
                    break;
            }

            if (resultado.Sucesso)
                container.SaveChanges();

            return resultado;
        }
    }
}
