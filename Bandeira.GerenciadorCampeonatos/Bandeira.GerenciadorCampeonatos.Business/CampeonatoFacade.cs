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
                resultado.Merge(campeonatoProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado AlterarCampeonato(Campeonato campeonato)
        {
            Resultado resultado = campeonatoProcess.Alterar(campeonato);

            if (resultado.Sucesso)
                resultado.Merge(campeonatoProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado ExcluirCampeonato(Campeonato campeonato)
        {
            Resultado resultado = campeonatoProcess.Excluir(campeonato);

            if (resultado.Sucesso)
                resultado.Merge(campeonatoProcess.SaveChangesContainer());

            return resultado;
        }

        public Campeonato ConsultarCampeonato(Campeonato campeonato)
        {
            return campeonatoProcess.Consultar(campeonato);
        }



        //Rodada
        public Resultado CriarRodada(Rodada rodada)
        {
            Resultado resultado = rodadaProcess.Incluir(rodada);

            if (resultado.Sucesso)
                resultado.Merge(rodadaProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado ApagarRodada(Rodada rodada)
        {
            Resultado resultado = rodadaProcess.Excluir(rodada);

            if (resultado.Sucesso)
                container.SaveChanges();

            return resultado;
        }

        public IList<Rodada> ListarRodadas(int campeonatoId)
        {
            return rodadaProcess.Listar(campeonatoId);
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
                    resultado.Merge(pontuacaoProcess.SaveChangesContainer());
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
                resultado.Merge(pontuacaoProcess.SaveChangesContainer());

            return resultado;
        }

        public IList<Pontuacao> ListarAtivos(int campeonatoId)
        {
            return pontuacaoProcess.Listar(campeonatoId, true);
        }

        public IList<Pontuacao> ListarInativos(int campeonatoId)
        {
            return pontuacaoProcess.Listar(campeonatoId, false);
        }

        public IList<Pontuacao> ListarPontuacoes(int campeonatoId)
        {
            return pontuacaoProcess.Listar(campeonatoId, null);
        }

        //Jogador
        public Resultado CriarJogador(Jogador jogador, int campeonatoId)
        {           
            Resultado resultado = jogadorProcess.Incluir(jogador);

            if (resultado.Sucesso)
                resultado.Merge(jogadorProcess.SaveChangesContainer());
            
            if (resultado.Sucesso)
                resultado.Merge(jogadorProcess.AssociaCampeonato(jogador, new Campeonato() { CampeonatoId = campeonatoId }));

            if (resultado.Sucesso)
                resultado.Merge(jogadorProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado AlterarJogador(Jogador jogador)
        {
            Resultado resultado = jogadorProcess.Alterar(jogador);

            if (resultado.Sucesso)
                resultado.Merge(jogadorProcess.SaveChangesContainer());

            return resultado;
        }

        public Jogador ConsultarJogador(Jogador jogador)
        {
            return jogadorProcess.Consultar(jogador);
        }

        public IList<Jogador> ListarJogadores(int campeonatoId)
        {
            return jogadorProcess.Listar(campeonatoId);
        }

        public Resultado AssociarJogadorCampeonato(Jogador jogador, Campeonato campeonato)
        {
            Resultado resultado = jogadorProcess.AssociaCampeonato(jogador, campeonato);

            if (resultado.Sucesso)
                resultado.Merge(jogadorProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado DesassociarJogadorCampeonato(JogadorCampeonato jogadorCampeonato)
        {
            Resultado resultado = jogadorProcess.DesassociaCampeonato(jogadorCampeonato);

            if (resultado.Sucesso)
                resultado.Merge(jogadorProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado CriarRodadas(int campeonatoId, int quantidade)
        {
            Queue<Jogador> jogadoresCampeonato = new Queue<Jogador>(ListarJogadores(campeonatoId));

            Resultado resultado = new Resultado();

            Campeonato campeonato = campeonatoProcess.Consultar(new Campeonato() { CampeonatoId = campeonatoId });

            for (int i = 1; i < quantidade + 1; i++)
            {
                Rodada rodada = new Rodada();
                rodada.Numero = i;
                rodada.CampeonatoId = campeonatoId;

                if (campeonato.QuantidadeJogadoresPorPartida.HasValue)
                {
                    double quantidadeJogosPorRodada = jogadoresCampeonato.Count / campeonato.QuantidadeJogadoresPorPartida.Value;

                    if (quantidadeJogosPorRodada % 1 == 0)
                    {
                        for (int j = 0; j < quantidadeJogosPorRodada; j++)
                        {
                            Partida partida = new Partida();

                            for (int k = 0; k < campeonato.QuantidadeJogadoresPorPartida; k++)
                            {
                                Jogador jogador = jogadoresCampeonato.Dequeue();

                                Competidor competidor = new Competidor();
                                competidor.Jogador = jogador;

                                partida.Competidores.Add(competidor);

                                jogadoresCampeonato.Enqueue(jogador);
                            }

                            rodada.Partidas.Add(partida);
                        }
                    }
                }

                resultado.Merge(rodadaProcess.Incluir(rodada));

                if (!resultado.Sucesso)
                    return resultado;
            }

            if (resultado.Sucesso)
                resultado.Merge(rodadaProcess.SaveChangesContainer());
            
            return resultado;
        }
    }
}
