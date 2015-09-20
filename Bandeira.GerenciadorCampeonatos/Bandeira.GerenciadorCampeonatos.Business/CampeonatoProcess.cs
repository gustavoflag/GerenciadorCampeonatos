using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class CampeonatoProcess
    {
        private GerenciadorCampeonatosContainer container;

        public CampeonatoProcess(GerenciadorCampeonatosContainer container)
        {
            this.container = container;
        }

        public CampeonatoProcess()
            :this(new GerenciadorCampeonatosContainer())
        {
        }

        public Resultado CriarCampeonato()
        {
            return new Resultado();
            //container.Campeonatos
        }
    }
}
