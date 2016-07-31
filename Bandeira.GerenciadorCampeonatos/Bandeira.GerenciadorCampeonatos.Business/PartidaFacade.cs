using Bandeira.GerenciadorCampeonatos.Business.Process;
using Bandeira.GerenciadorCampeonatos.Model;
using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class PartidaFacade : IPartidaFacade
    {
        private PartidaProcess partidaProcess;
        private LocalProcess localProcess;
        private CompetidorProcess competidorProcess;
        private IContainer container;

        public PartidaFacade()
            :this(new GerenciadorCampeonatosContainer())
        {
        }

        public PartidaFacade(IContainer container)
        {
            this.container = container;
            partidaProcess = new PartidaProcess(container);
            localProcess = new LocalProcess(container);
            competidorProcess = new CompetidorProcess(container);
        }

        /*public PartidaFacade(IProcess<Partida> partidaProcess
                            , IProcess<Local> localProcess
                            , IProcess<Competidor> competidorProcess)
        {
            this.partidaProcess = partidaProcess;
            this.localProcess = localProcess;
            this.competidorProcess = competidorProcess;
        }*/

        //Local
        public Resultado CriarLocal(Local local)
        {
            Resultado resultado = localProcess.Incluir(local);

            if (resultado.Sucesso)
                resultado.Merge(localProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado AlterarLocal(Local local)
        {
            Resultado resultado = localProcess.Alterar(local);

            if (resultado.Sucesso)
                resultado.Merge(localProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado ExcluirLocal(Local local)
        {
            Resultado resultado = localProcess.Excluir(local);

            if (resultado.Sucesso)
                resultado.Merge(localProcess.SaveChangesContainer());

            return resultado;
        }

        public IList<Local> ListarLocais(int campeonatoId)
        {
            return localProcess.Listar(campeonatoId);
        }

        public IList<Local> ListarLocais()
        {
            return localProcess.Listar();
        }

        public Local ConsultarLocal(Local local)
        {
            return localProcess.Consultar(local);
        }

        //Partida
        public Resultado CriarPartida(Partida partida)
        {
            Resultado resultado = partidaProcess.Incluir(partida);

            if (resultado.Sucesso)
                resultado.Merge(partidaProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado CriarPartidas(IList<Partida> partidas)
        {
            Resultado resultado = new Resultado();

            foreach (Partida partida in partidas)
            {
                if (resultado.Sucesso)
                {
                    resultado.Merge(partidaProcess.Incluir(partida));
                }

                if (!resultado.Sucesso)
                    break;
            }

            if (resultado.Sucesso)
                resultado.Merge(partidaProcess.SaveChangesContainer());

            return resultado;
        }

        public IList<Partida> ListarPartidas(int campeonatoId, int rodadaNumero)
        {
            return partidaProcess.Listar(campeonatoId, rodadaNumero);
        }

        public Resultado CriarCompetidor(Competidor competidor)
        {
            Resultado resultado = competidorProcess.Incluir(competidor);

            if (resultado.Sucesso)
                resultado.Merge(partidaProcess.SaveChangesContainer());

            return resultado;
        }

        public Partida ConsultarPartida(Partida partida)
        {
            return partidaProcess.Consultar(partida);
        }

        //Competidor
        public Competidor ConsultarCompetidor(string nomeJogador, int partidaId)
        {
            return competidorProcess.ConsultarCompetidor(nomeJogador, partidaId);
        }

        //ResultadoPartida
        public Resultado InsereResultadoPartida(Partida partida, Competidor competidor, Pontuacao pontuacao, int valor)
        {
            Resultado resultado = partidaProcess.InsereResultado(partida, competidor, pontuacao, valor);

            if (resultado.Sucesso)
                resultado.Merge(partidaProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado ApagaResultadoPartida(ResultadoPartida resultadoPartida)
        {
            Resultado resultado = partidaProcess.ApagaResultado(resultadoPartida);

            if (resultado.Sucesso)
                resultado.Merge(partidaProcess.SaveChangesContainer());

            return resultado;
        }
    }
}
