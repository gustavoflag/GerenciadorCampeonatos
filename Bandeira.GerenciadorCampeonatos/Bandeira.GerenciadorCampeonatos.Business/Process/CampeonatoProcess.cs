using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class CampeonatoProcess : BaseProcess<Campeonato>
    {
        public CampeonatoProcess(IContainer container)
            :base(container)
        {
            this.container = container;
        }

        public CampeonatoProcess()
            : base(new GerenciadorCampeonatosContainer())
        {

        }

        protected override Campeonato SelectByUnique(Campeonato obj)
        {
            return container.Campeonatos.Where(c => c.CampeonatoId == obj.CampeonatoId).FirstOrDefault();
        }

        protected override IQueryable<Campeonato> Select()
        {
            return container.Campeonatos;
        }

        protected override void Insert(Campeonato obj)
        {
            container.Campeonatos.Add(obj);
        }

        protected override void Update(Campeonato objBanco, Campeonato obj)
        {
            objBanco.Nome = obj.Nome;
        }

        protected override void Delete(Campeonato obj)
        {
            container.Campeonatos.Remove(obj);
        }

        protected override Resultado ValidateInsert(Campeonato obj)
        {
            Resultado resultado = new Resultado();

            if (container.Campeonatos.Any(c => c.Nome == obj.Nome))
            {
                resultado.AddMensagemErro("Já existe um campeonato com esse nome");
            }

            return resultado;
        }

        protected override Resultado ValidateUpdate(Campeonato obj)
        {
            Resultado resultado = new Resultado();

            if (container.Campeonatos.Any(c => c.Nome == obj.Nome && c.CampeonatoId != obj.CampeonatoId))
            {
                resultado.AddMensagemErro("Já existe outro campeonato com esse nome");
            }

            return resultado;
        }

        protected override Resultado ValidateDelete(Campeonato obj)
        {
            return new Resultado();
        }

        public Campeonato ConsultarPorNome(string nome)
        {
            return Select().Where(c => c.Nome == nome).FirstOrDefault();
        }
    }
}
