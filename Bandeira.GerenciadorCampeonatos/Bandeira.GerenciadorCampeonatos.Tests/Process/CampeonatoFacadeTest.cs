using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.Tests.Mocks;
using Bandeira.GerenciadorCampeonatos.Business;

namespace Bandeira.GerenciadorCampeonatos.Tests.Process
{
    [TestClass]
    public class CampeonatoFacadeTest
    {
        private IContainer container;
        private ICampeonatoFacade target;

        private IContainer GetContainer()
        {
            return new GerenciadorCampeonatosContainerMock();
        }

        [TestMethod]
        public void CriarCampeonatoTest()
        {
            container = GetContainer();
            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            campeonato.Nome = "Campeonato Teste";

            target.CriarCampeonato(campeonato);

            Assert.AreEqual(1, container.Campeonatos.Count());
            Assert.AreEqual("Campeonato Teste", container.Campeonatos.FirstOrDefault().Nome);
        }

        [TestMethod]
        public void CriarRodadaTest()
        {
            container = GetContainer();
            target = new CampeonatoFacade(container);

            Rodada rodada = new Rodada();
            rodada.CampeonatoId = 4;
            rodada.Numero = 8;

            target.CriarRodada(rodada);

            Assert.AreEqual(1, container.Rodadas.Count());
            Assert.AreEqual(4, container.Rodadas.FirstOrDefault().CampeonatoId);
            Assert.AreEqual(8, container.Rodadas.FirstOrDefault().Numero);
        }
    }
}
