using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.Tests.Mocks;
using Bandeira.GerenciadorCampeonatos.Business;
using System.Collections.Generic;

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
        public void CriarPontuacaoTest()
        {
            container = GetFakeContainer();
            //container.Campeonatos.Add(new Campeonato() { CampeonatoId = 1, Nome = "Campeonato teste" });

            target = new CampeonatoFacade(container);

            Pontuacao pontuacao = new Pontuacao();
            pontuacao.CampeonatoId = 4;
            pontuacao.Colocacao = 1;
            pontuacao.Pontos = 25;
            pontuacao.Ativo = true;

            Resultado retorno = target.CriarPontuacao(pontuacao);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(1, container.Pontuacoes.Count());
            Assert.AreEqual(4, container.Pontuacoes.FirstOrDefault().CampeonatoId);
            Assert.AreEqual(1, container.Pontuacoes.FirstOrDefault().Colocacao);
            Assert.AreEqual(25, container.Pontuacoes.FirstOrDefault().Pontos);
        }

        [TestMethod]
        public void CriarPontuacaoComJaExistenteTest()
        {
            container = GetFakeContainer();
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 1, Pontos = 10, DtCadastro = DateTime.Now.AddDays(-1) });

            target = new CampeonatoFacade(container);

            Pontuacao pontuacao = new Pontuacao();
            pontuacao.CampeonatoId = 4;
            pontuacao.Colocacao = 1;
            pontuacao.Pontos = 25;
            pontuacao.Ativo = true;

            Resultado retorno = target.CriarPontuacao(pontuacao);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(2, container.Pontuacoes.Count());

            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Ativo == false).Count());
            Assert.AreEqual(10, container.Pontuacoes.Where(p => p.Ativo == false).FirstOrDefault().Pontos);

            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Colocacao == 1 && p.Ativo).Count());

            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Ativo).Count());
            Assert.AreEqual(4, container.Pontuacoes.Where(p => p.Ativo).FirstOrDefault().CampeonatoId);
            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Ativo).FirstOrDefault().Colocacao);
            Assert.AreEqual(25, container.Pontuacoes.Where(p => p.Ativo).FirstOrDefault().Pontos);
        }

        [TestMethod]
        public void CriarPontuacaoComMaisDeUmJaExistenteTest()
        {
            container = GetFakeContainer();
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 1, Pontos = 10, DtCadastro = DateTime.Now.AddDays(-1), Ativo = true });
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 1, Pontos = 12, DtCadastro = DateTime.Now.AddDays(-2), Ativo = false });

            target = new CampeonatoFacade(container);

            Pontuacao pontuacao = new Pontuacao();
            pontuacao.CampeonatoId = 4;
            pontuacao.Colocacao = 1;
            pontuacao.Pontos = 25;
            pontuacao.Ativo = true;

            Resultado retorno = target.CriarPontuacao(pontuacao);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(3, container.Pontuacoes.Count());

            Assert.AreEqual(2, container.Pontuacoes.Where(p => p.Ativo == false).Count());

            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Colocacao == 1 && p.Ativo).Count());

            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Ativo).Count());
            Assert.AreEqual(4, container.Pontuacoes.Where(p => p.Ativo).FirstOrDefault().CampeonatoId);
            Assert.AreEqual(1, container.Pontuacoes.Where(p => p.Ativo).FirstOrDefault().Colocacao);
            Assert.AreEqual(25, container.Pontuacoes.Where(p => p.Ativo).FirstOrDefault().Pontos);
        }

        [TestMethod]
        public void CriarPontuacoesTest()
        {
            container = GetFakeContainer();
            //container.Campeonatos.Add(new Campeonato() { CampeonatoId = 1, Nome = "Campeonato teste" });

            List<Pontuacao> pontuacoes = new List<Pontuacao>();
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 1, Pontos = 25, Ativo = true });
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 2, Pontos = 18, Ativo = true });
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 3, Pontos = 15, Ativo = true });
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 4, Pontos = 12, Ativo = true });

            target = new CampeonatoFacade(container);

            Resultado retorno = target.CriarPontuacoes(pontuacoes);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(4, container.Pontuacoes.Count());
            Assert.AreEqual(4, container.Pontuacoes.FirstOrDefault().CampeonatoId);

            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 1 && p.Ativo));
            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 2 && p.Ativo));
            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 3 && p.Ativo));
            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 4 && p.Ativo));
        }

        [TestMethod]
        public void CriarPontuacoesComJaExistentesTest()
        {
            container = GetFakeContainer();
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 1, Pontos = 10, Ativo = true, DtCadastro = DateTime.Now.AddDays(-10) });
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 2, Pontos = 6, Ativo = true, DtCadastro = DateTime.Now.AddDays(-10) });
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 3, Pontos = 4, Ativo = true, DtCadastro = DateTime.Now.AddDays(-10) });
            container.Pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 4, Pontos = 3, Ativo = true, DtCadastro = DateTime.Now.AddDays(-10) });

            List<Pontuacao> pontuacoes = new List<Pontuacao>();
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 1, Pontos = 25, Ativo = true });
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 2, Pontos = 18, Ativo = true });
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 3, Pontos = 15, Ativo = true });
            pontuacoes.Add(new Pontuacao() { CampeonatoId = 4, Colocacao = 4, Pontos = 12, Ativo = true });

            target = new CampeonatoFacade(container);

            Resultado retorno = target.CriarPontuacoes(pontuacoes);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(8, container.Pontuacoes.Count());

            Assert.AreEqual(4, container.Pontuacoes.Count(p => p.Ativo)); 
            Assert.AreEqual(4, container.Pontuacoes.Count(p => p.Ativo == false));

            Assert.AreEqual(4, container.Pontuacoes.FirstOrDefault().CampeonatoId);

            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 1 && p.Ativo));
            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 2 && p.Ativo));
            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 3 && p.Ativo));
            Assert.AreEqual(1, container.Pontuacoes.Count(p => p.Colocacao == 4 && p.Ativo));

            Assert.AreEqual(25, container.Pontuacoes.Where(p => p.Colocacao == 1 && p.Ativo).FirstOrDefault().Pontos);
            Assert.AreEqual(18, container.Pontuacoes.Where(p => p.Colocacao == 2 && p.Ativo).FirstOrDefault().Pontos);
            Assert.AreEqual(15, container.Pontuacoes.Where(p => p.Colocacao == 3 && p.Ativo).FirstOrDefault().Pontos);
            Assert.AreEqual(12, container.Pontuacoes.Where(p => p.Colocacao == 4 && p.Ativo).FirstOrDefault().Pontos);
        }

        /*[TestMethod]
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

        [TestMethod]
        public void ExcluirCampeonatoRealTest()
        {
            container = GetRealContainer();
            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            campeonato.CampeonatoId = 2;

            Resultado retorno = target.ExcluirCampeonato(campeonato);

            Assert.AreEqual(0, container.Campeonatos.Count());
        }*/
    }
}
