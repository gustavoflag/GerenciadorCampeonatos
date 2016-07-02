using System;
using System.Linq;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.Tests.Mocks;
using Bandeira.GerenciadorCampeonatos.Business;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void CriarRodadasTest()
        {
            container = GetRealContainer();

            target = new CampeonatoFacade(container);

            Campeonato campeonato = new Campeonato();
            //campeonato.CampeonatoId = 4;
            campeonato.QuantidadeJogadoresPorPartida = 2;

            Resultado resultado = target.CriarCampeonato(campeonato);

            //campeonato = target.ConsultarCampeonato(campeonato);

            Jogador jogador1 = new Jogador() { Nome = "Jogador 1" };
            Jogador jogador2 = new Jogador() { Nome = "Jogador 2" };
            Jogador jogador3 = new Jogador() { Nome = "Jogador 3" };
            Jogador jogador4 = new Jogador() { Nome = "Jogador 4" };

            target.CriarJogador(jogador1, campeonato.CampeonatoId);
            target.CriarJogador(jogador2, campeonato.CampeonatoId);
            target.CriarJogador(jogador3, campeonato.CampeonatoId);
            target.CriarJogador(jogador4, campeonato.CampeonatoId);

            target.CriarRodadas(campeonato.CampeonatoId, 5);

            campeonato = target.ConsultarCampeonato(new Campeonato() { CampeonatoId = campeonato.CampeonatoId });

            Assert.AreEqual(5, campeonato.Rodadas.Count); 
            
        }

        [TestMethod]
        public void GerarConfrontosTest()
        {
            container = GetFakeContainer();
            target = new CampeonatoFacade(container);

            Jogador jogador1 = new Jogador() { JogadorId = 1, Nome = "Jogador 1" };
            Jogador jogador2 = new Jogador() { JogadorId = 2, Nome = "Jogador 2" };
            Jogador jogador3 = new Jogador() { JogadorId = 3, Nome = "Jogador 3" };
            Jogador jogador4 = new Jogador() { JogadorId = 4, Nome = "Jogador 4" };
            Jogador jogador5 = new Jogador() { JogadorId = 5, Nome = "Jogador 5" };
            //Jogador jogador6 = new Jogador() { JogadorId = 6, Nome = "Jogador 6" };
            

            IList<Jogador> jogadores = new List<Jogador>();
            jogadores.Add(jogador1);
            jogadores.Add(jogador2);
            jogadores.Add(jogador3);
            jogadores.Add(jogador4);
            jogadores.Add(jogador5);
            //jogadores.Add(jogador6);

            IList<Rodada> rodadas = target.GerarConfrontos(jogadores, 2);
        }

        [TestMethod]
        public void GerarCampeonatoPokerTest()
        {
            container = GetRealContainer();

            CampeonatoFacade campeonatoFacade = new CampeonatoFacade(container);

            //Campeonato campeonatoPoker = new Campeonato();
            //campeonatoPoker.Nome = "TQSOP Poker";

            //campeonatoFacade.CriarCampeonato(campeonatoPoker);

            ////campeonatoPoker = campeonatoFacade.ConsultarCampeonato("TQSOP Poker");

            //Pontuacao primeiro = new Pontuacao() { CampeonatoId = campeonatoPoker.CampeonatoId, Colocacao = 1, Pontos = 10 };
            //Pontuacao segundo = new Pontuacao() { CampeonatoId = campeonatoPoker.CampeonatoId, Colocacao = 2, Pontos = 6 };
            //Pontuacao terceiro = new Pontuacao() { CampeonatoId = campeonatoPoker.CampeonatoId, Colocacao = 3, Pontos = 4 };
            //Pontuacao quarto = new Pontuacao() { CampeonatoId = campeonatoPoker.CampeonatoId, Colocacao = 4, Pontos = 3 };
            //Pontuacao quinto = new Pontuacao() { CampeonatoId = campeonatoPoker.CampeonatoId, Colocacao = 5, Pontos = 2 };
            //Pontuacao sexto = new Pontuacao() { CampeonatoId = campeonatoPoker.CampeonatoId, Colocacao = 6, Pontos = 1 };

            //campeonatoFacade.CriarPontuacao(primeiro);
            //campeonatoFacade.CriarPontuacao(segundo);
            //campeonatoFacade.CriarPontuacao(terceiro);
            //campeonatoFacade.CriarPontuacao(quarto);
            //campeonatoFacade.CriarPontuacao(quinto);
            //campeonatoFacade.CriarPontuacao(sexto);

            //Jogador flag = new Jogador() { Nome = "Flag" };
            //Jogador andre = new Jogador() { Nome = "Andre" };
            //Jogador julio = new Jogador() { Nome = "Julio" };
            //Jogador fernando = new Jogador() { Nome = "Fernando" };
            //Jogador bento = new Jogador() { Nome = "Bento" };

            //campeonatoFacade.CriarJogador(flag, campeonatoPoker.CampeonatoId);
            //campeonatoFacade.CriarJogador(andre, campeonatoPoker.CampeonatoId);
            //campeonatoFacade.CriarJogador(julio, campeonatoPoker.CampeonatoId);
            //campeonatoFacade.CriarJogador(fernando, campeonatoPoker.CampeonatoId);
            //campeonatoFacade.CriarJogador(bento, campeonatoPoker.CampeonatoId);

            

            Campeonato campeonatoPoker = campeonatoFacade.ConsultarCampeonato("TQSOP Poker");

            //rodada = campeonatoFacade.ConsultarRodada(campeonatoPoker.CampeonatoId, 1);

            Rodada rodada = new Rodada() { CampeonatoId = campeonatoPoker.CampeonatoId, Numero = 2 };

            campeonatoFacade.CriarRodada(rodada);

            ////campeonatoFacade.

            PartidaFacade partidaFacade = new PartidaFacade(container);

            Partida partida = new Partida() { RodadaId = rodada.RodadaId };

            partidaFacade.CriarPartida(partida);

            //Jogador flag = new Jogador() { Nome = "Flag" };

            Jogador flag = campeonatoFacade.ConsultarJogador("Flag");
            Jogador andre = campeonatoFacade.ConsultarJogador("Andre");
            Jogador julio = campeonatoFacade.ConsultarJogador("Julio");
            Jogador fernando = campeonatoFacade.ConsultarJogador("Fernando");
            Jogador bento = campeonatoFacade.ConsultarJogador("Bento");

            

            Competidor cflag = new Competidor() { JogadorId = flag.JogadorId, PartidaId = partida.PartidaId };
            Competidor candre = new Competidor() { JogadorId = andre.JogadorId, PartidaId = partida.PartidaId };
            Competidor cjulio = new Competidor() { JogadorId = julio.JogadorId, PartidaId = partida.PartidaId };
            Competidor cfernando = new Competidor() { JogadorId = fernando.JogadorId, PartidaId = partida.PartidaId };
            Competidor cbento = new Competidor() { JogadorId = bento.JogadorId, PartidaId = partida.PartidaId };

            

            //Partida partida = partidaFacade.ConsultarPartida(new Partida() { PartidaId = 1 });

            //Competidor cflag = partidaFacade.ConsultarCompetidor(flag.Nome, partida.PartidaId);
            //Competidor candre = partidaFacade.ConsultarCompetidor(andre.Nome, partida.PartidaId);
            //Competidor cjulio = partidaFacade.ConsultarCompetidor(julio.Nome, partida.PartidaId);
            //Competidor cfernando = partidaFacade.ConsultarCompetidor(fernando.Nome, partida.PartidaId);
            //Competidor cbento = partidaFacade.ConsultarCompetidor(bento.Nome, partida.PartidaId);

            partidaFacade.CriarCompetidor(cflag);
            partidaFacade.CriarCompetidor(candre);
            partidaFacade.CriarCompetidor(cjulio);
            partidaFacade.CriarCompetidor(cfernando);
            partidaFacade.CriarCompetidor(cbento);

            

            partidaFacade.InsereResultadoPartida(partida, cfernando, campeonatoPoker.Pontuacoes.FirstOrDefault(p => p.Colocacao == 4), 15);
            partidaFacade.InsereResultadoPartida(partida, cflag, campeonatoPoker.Pontuacoes.FirstOrDefault(p => p.Colocacao == 1), 15);
            partidaFacade.InsereResultadoPartida(partida, candre, campeonatoPoker.Pontuacoes.FirstOrDefault(p => p.Colocacao == 5), 15);
            partidaFacade.InsereResultadoPartida(partida, cbento, campeonatoPoker.Pontuacoes.FirstOrDefault(p => p.Colocacao == 2), 15);
            partidaFacade.InsereResultadoPartida(partida, cjulio, campeonatoPoker.Pontuacoes.FirstOrDefault(p => p.Colocacao == 3), 15);

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
