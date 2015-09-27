using Bandeira.GerenciadorCampeonatos.Business.Process;
using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class CampeonatoFacade
    {
        private CampeonatoProcess campeonatoProcess;
        private RodadaProcess rodadaProcess;

        public CampeonatoFacade()
            : this(new GerenciadorCampeonatosContainer())
        {
        }

        public CampeonatoFacade(GerenciadorCampeonatosContainer container)
        {
            campeonatoProcess = new CampeonatoProcess(container);
            rodadaProcess = new RodadaProcess(container);
        }


        //Campeonato
        public Resultado CriarCampeonato(Campeonato campeonato)
        {
            return campeonatoProcess.Incluir(campeonato);
        }


        //Rodada
        public Resultado CriarRodada(Rodada rodada)
        {
            return rodadaProcess.Incluir(rodada);
        }
    }
}
