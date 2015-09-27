using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class JogadorProcess : BaseProcess<Jogador>
    {
        public JogadorProcess(GerenciadorCampeonatosContainer container)
            :base(container)
        {
            this.container = container;
        }

        public JogadorProcess()
            : base(new GerenciadorCampeonatosContainer())
        {

        }

        protected override Jogador SelectByUnique(Jogador obj)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Jogador> Select()
        {
            return container.Jogadores;
        }

        protected override void Insert(Jogador obj)
        {
            container.Jogadores.Add(obj);
        }

        protected override void Delete(Jogador obj)
        {
            container.Jogadores.Remove(obj);
        }

        protected override void Update(Jogador objBanco, Jogador obj)
        {
            objBanco.Nome = obj.Nome;
        }

        protected override Resultado ValidateInsert(Jogador obj)
        {
            Resultado resultado = new Resultado();

            if (container.Jogadores.Any(j => j.Nome == obj.Nome))
                resultado.AddMensagemErro("Já existe um jogador com esse nome.");

            return resultado;
        }

        protected override Resultado ValidateUpdate(Jogador obj)
        {
            Resultado resultado = new Resultado();

            if (container.Jogadores.Any(j => j.Nome == obj.Nome && j.Id != obj.Id))
                resultado.AddMensagemErro("Já existe outro jogador com esse nome.");

            return resultado;
        }

        protected override Resultado ValidateDelete(Jogador obj)
        {
            return new Resultado();
        }

        internal Resultado AssociaCampeonato(Jogador jogador, Campeonato campeonato)
        {
            Resultado resultado = new Resultado();

            try
            {
                JogadorCampeonato jogadorCampeonato = new JogadorCampeonato();

                jogadorCampeonato.Campeonato = new CampeonatoProcess(container).Consultar(campeonato);

                jogadorCampeonato.Jogador = Consultar(jogador);

                container.JogadorCampeonatos.Add(jogadorCampeonato);

                container.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;
            
        }

        internal Resultado DesassociaCampeonato(JogadorCampeonato jogadorCampeonato)
        {
            Resultado resultado = new Resultado();

            try
            {
                jogadorCampeonato = container.JogadorCampeonatos.Where(jc => jc.Id == jogadorCampeonato.Id).FirstOrDefault();

                container.JogadorCampeonatos.Remove(jogadorCampeonato);

                container.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;
        }
    }
}
