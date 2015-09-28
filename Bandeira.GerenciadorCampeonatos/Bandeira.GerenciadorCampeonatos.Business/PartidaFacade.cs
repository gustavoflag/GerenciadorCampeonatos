using Bandeira.GerenciadorCampeonatos.Business.Process;
using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class PartidaFacade : IPartidaFacade
    {
        private PartidaProcess partidaProcess;
        private LocalProcess localProcess;
        private CompetidorProcess competidorProcess;
        private GerenciadorCampeonatosContainer container;

        public PartidaFacade()
            :this(new GerenciadorCampeonatosContainer())
        {
        }

        public PartidaFacade(GerenciadorCampeonatosContainer container)
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
    }
}
