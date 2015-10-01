using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class LocalProcess : BaseProcess<Local>
    {
        public LocalProcess(IContainer container)
            :base(container)
        {
            this.container = container;
        }

        public LocalProcess()
            : base(new GerenciadorCampeonatosContainer())
        {

        }

        protected override IQueryable<Local> Select()
        {
            return container.Locais;
        }

        protected override Local SelectByUnique(Local obj)
        {
            return Select().Where(l => l.LocalId == obj.LocalId).FirstOrDefault();
        }

        protected override void Insert(Local obj)
        {
            container.Locais.Add(obj);
        }

        protected override void Update(Local objBanco, Local obj)
        {
            objBanco.Localizacao = obj.Localizacao;
            objBanco.Nome = obj.Nome;
        }

        protected override void Delete(Local obj)
        {
            container.Locais.Remove(obj);
        }

        protected override Resultado ValidateInsert(Local obj)
        {
            Resultado resultado = new Resultado();

            if (container.Locais.Any(l => l.Localizacao.Latitude == obj.Localizacao.Latitude && l.Localizacao.Longitude == obj.Localizacao.Longitude))
                resultado.AddMensagemErro("Já existe uma localização com a mesma geolocalização");

            if (container.Locais.Any(l => l.Nome == obj.Nome))
                resultado.AddMensagemErro("Já existe uma localização com o mesmo nome");

            return resultado;
        }

        protected override Resultado ValidateUpdate(Local obj)
        {
            Resultado resultado = new Resultado();

            if (container.Locais.Any(l => l.Nome == obj.Nome && l.LocalId != obj.LocalId))
                resultado.AddMensagemErro("Já existe outra localização com o mesmo nome");

            return resultado;
        }

        protected override Resultado ValidateDelete(Local obj)
        {
            return new Resultado();
        }
    }
}
