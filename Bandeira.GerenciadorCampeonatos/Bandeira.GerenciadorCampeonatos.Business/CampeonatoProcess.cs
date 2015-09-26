using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class CampeonatoProcess : BaseProcess<Campeonato>
    {
        public CampeonatoProcess(GerenciadorCampeonatosContainer container)
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
            return container.Campeonatos.Where(c => c.Id == obj.Id).FirstOrDefault();
        }

        protected override IQueryable<Campeonato> Select()
        {
            return container.Campeonatos;
        }

        protected override void Insert(Campeonato obj)
        {
            container.Campeonatos.Add(obj);
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

            if (container.Campeonatos.Any(c => c.Nome == obj.Nome && c.Id != obj.Id))
            {
                resultado.AddMensagemErro("Já existe outro campeonato com esse nome");
            }

            return resultado;
        }

        protected override Resultado ValidateDelete(Campeonato obj)
        {
            return new Resultado();
        }
    }
}
