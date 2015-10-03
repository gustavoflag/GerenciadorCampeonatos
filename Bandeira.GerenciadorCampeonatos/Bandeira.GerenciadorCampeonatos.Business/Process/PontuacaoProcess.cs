using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class PontuacaoProcess : BaseProcess<Pontuacao>
    {
        public PontuacaoProcess(IContainer container)
            :base(container)
        {
            this.container = container;
        }

        public PontuacaoProcess()
            : base(new GerenciadorCampeonatosContainer())
        {

        }

        internal IList<Pontuacao> Consultar(Pontuacao pontuacao)
        {
            return Select().Where(p => p.CampeonatoId == pontuacao.CampeonatoId
                                        && p.Colocacao == pontuacao.Colocacao
                                        && p.Ativo).ToList();
        }

        protected override IQueryable<Pontuacao> Select()
        {
            return container.Pontuacoes;
        }

        protected override Pontuacao SelectByUnique(Pontuacao obj)
        {
            return Select().Where(p => p.PontuacaoId == obj.PontuacaoId).FirstOrDefault();
        }

        protected override void Insert(Pontuacao obj)
        {
            container.Pontuacoes.Add(obj);
        }

        protected override void Update(Pontuacao objBanco, Pontuacao obj)
        {
            objBanco.Ativo = obj.Ativo;
            objBanco.Pontos = obj.Pontos;
            objBanco.Colocacao = obj.Colocacao;
        }

        protected override void Delete(Pontuacao obj)
        {
            container.Pontuacoes.Remove(obj);
        }

        protected override Resultado ValidateInsert(Pontuacao obj)
        {
            Resultado resultado = new Resultado();

            return resultado;
        }

        protected override Resultado ValidateUpdate(Pontuacao obj)
        {
            Resultado resultado = new Resultado();

            return resultado;
        }

        protected override Resultado ValidateDelete(Pontuacao obj)
        {
            Resultado resultado = new Resultado();

            return resultado;
        }
    }
}
