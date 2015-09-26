using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class RodadaProcess : BaseProcess<Rodada>
    {
        protected override Rodada SelectByUnique(Rodada obj)
        {
            return Select().Where(r => r.Id == obj.Id).FirstOrDefault();
        }

        protected override IQueryable<Rodada> Select()
        {
            return container.Rodadas;
        }

        protected override void Insert(Rodada obj)
        {
            container.Rodadas.Add(obj);
        }

        protected override void Delete(Rodada obj)
        {
            container.Rodadas.Remove(obj);
        }

        protected override Resultado ValidateInsert(Rodada obj)
        {
            Resultado resultado = new Resultado();

            if (container.Rodadas.Any(r => r.Numero == obj.Numero && r.CampeonatoId == obj.Id))
                resultado.AddMensagemErro("Já existe uma rodada com o mesmo número nesse campeonato");

            return resultado;
        }

        protected override Resultado ValidateUpdate(Rodada obj)
        {
            Resultado resultado = new Resultado();

            if (container.Rodadas.Any(r => r.Numero == obj.Numero && r.CampeonatoId == obj.Id && r.Id != obj.Id))
                resultado.AddMensagemErro("Já existe outra rodada com o mesmo número nesse campeonato");

            return resultado;
        }

        protected override Resultado ValidateDelete(Rodada obj)
        {
            return new Resultado();
        }
    }
}
