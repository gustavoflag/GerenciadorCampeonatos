using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class PartidaProcess : BaseProcess<Partida>
    {
        public PartidaProcess(IContainer container)
            :base(container)
        {
            this.container = container;
        }

        public PartidaProcess()
            : base(new GerenciadorCampeonatosContainer())
        {

        }

        protected override Partida SelectByUnique(Partida obj)
        {
            return Select().Where(p => p.PartidaId == obj.PartidaId).FirstOrDefault();
        }

        protected override IQueryable<Partida> Select()
        {
            return container.Partidas;
        }

        protected override void Insert(Partida obj)
        {
            container.Partidas.Add(obj);
        }

        protected override void Delete(Partida obj)
        {
            container.Partidas.Remove(obj);
        }

        protected override void Update(Partida objBanco, Partida obj)
        {
            objBanco.LocalId = obj.LocalId;
        }

        protected override Resultado ValidateInsert(Partida obj)
        {
            return new Resultado();
        }

        protected override Resultado ValidateUpdate(Partida obj)
        {
            return new Resultado();
        }

        protected override Resultado ValidateDelete(Partida obj)
        {
            return new Resultado();
        }

        internal Resultado InsereResultado(Partida partida, Competidor competidor, Pontuacao pontuacao, int valor)
        {
            Resultado resultado = new Resultado();

            try
            {
                ResultadoPartida resultadoPartida = new ResultadoPartida();

                resultadoPartida.Competidor = competidor;
                resultadoPartida.Partida = partida;
                resultadoPartida.Pontuacao = pontuacao;
                resultadoPartida.Valor = valor;

                container.Resultados.Add(resultadoPartida);

                container.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;

        }

        internal Resultado ApagaResultado(ResultadoPartida resultadoPartida)
        {
            Resultado resultado = new Resultado();

            try
            {
                resultadoPartida = container.Resultados.Where(rp => rp.ResultadoPartidaId == resultadoPartida.ResultadoPartidaId).FirstOrDefault();

                container.Resultados.Remove(resultadoPartida);

                container.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;
        }

        internal IList<Partida> Listar(int campeonatoId, int rodadaNumero)
        {
            return Select().Where(p => p.Rodada != null && p.Rodada.Numero == rodadaNumero && p.Rodada.CampeonatoId == campeonatoId).ToList();
        }
    }
}
