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

        private IContainer GetFakeContainer()
        {
            return new GerenciadorCampeonatosContainerMock();
        }

        private IContainer GetRealContainer()
        {
            return new GerenciadorCampeonatosContainer();
        }

        [TestMethod]
        public void CriarCampeonatoTest()
        {
            container = GetFakeContainer();
            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            campeonato.Nome = "Campeonato Teste";

            Resultado retorno = target.CriarCampeonato(campeonato);

            Assert.AreEqual(1, container.Campeonatos.Count());
            Assert.AreEqual("Campeonato Teste", container.Campeonatos.FirstOrDefault().Nome);
        }

        [TestMethod]
        public void AlterarCampeonatoTest()
        {
            container = GetFakeContainer();
            container.Campeonatos.Add(new Campeonato() { CampeonatoId = 1, Nome = "Campeonato 1" });

            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            campeonato.CampeonatoId = 1;
            campeonato.Nome = "Campeonato 2";

            Resultado retorno = target.AlterarCampeonato(campeonato);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual("Campeonato 2", container.Campeonatos.Where(c => c.CampeonatoId == 1).FirstOrDefault().Nome);
        }

        [TestMethod]
        public void CriarRodadaTest()
        {
            container = GetFakeContainer();
            target = new CampeonatoFacade(container);

            Rodada rodada = new Rodada();
            rodada.CampeonatoId = 4;
            rodada.Numero = 8;

            Resultado retorno = target.CriarRodada(rodada);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(1, container.Rodadas.Count());
            Assert.AreEqual(4, container.Rodadas.FirstOrDefault().CampeonatoId);
            Assert.AreEqual(8, container.Rodadas.FirstOrDefault().Numero);
        }

        [TestMethod]
        public void CriarCampeonatoRealTest()
        {
            container = GetRealContainer();
            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            campeonato.Nome = "Campeonato Teste";

            Resultado retorno = target.CriarCampeonato(campeonato);

            Assert.AreEqual(1, container.Campeonatos.Count());
            Assert.AreEqual("Campeonato Teste", container.Campeonatos.FirstOrDefault().Nome);
        }
    }
}
