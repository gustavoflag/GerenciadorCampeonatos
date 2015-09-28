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

        private void SetContainer()
        {
            container = new GerenciadorCampeonatosContainerMock();
        }

        [TestMethod]
        public void CriarCampeonatoTest()
        {
            SetContainer();
            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            campeonato.Nome = "Campeonato Teste";

            target.CriarCampeonato(campeonato);

            Assert.AreEqual(1, container.Campeonatos.Count());
            Assert.AreEqual("Campeonato Teste", container.Campeonatos.FirstOrDefault().Nome);

        }
    }
}
