﻿using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class CompetidorProcess : BaseProcess<Competidor>
    {
        public CompetidorProcess(IContainer container)
            :base(container)
        {
            this.container = container;
        }

        public CompetidorProcess()
            : base(new GerenciadorCampeonatosContainer())
        {

        }

        protected override IQueryable<Competidor> Select()
        {
            return container.Competidores.Include("Jogador");
        }

        protected override Competidor SelectByUnique(Competidor obj)
        {
            return Select().Where(c => c.CompetidorId == obj.CompetidorId).FirstOrDefault();
        }

        protected override void Insert(Competidor obj)
        {
            container.Competidores.Add(obj);
        }

        protected override void Update(Competidor objBanco, Competidor obj)
        {
            
        }

        protected override void Delete(Competidor obj)
        {
            container.Competidores.Remove(obj);
        }

        protected override Resultado ValidateInsert(Competidor obj)
        {
            Resultado resultado = new Resultado();

            if (container.Competidores.Any(c => c.PartidaId == obj.PartidaId && c.JogadorId == obj.JogadorId))
            {
                resultado.AddMensagemErro("Esse jogador já foi associado a essa partida.");
            }

            return resultado;
        }

        protected override Resultado ValidateUpdate(Competidor obj)
        {
            return new Resultado();
        }

        protected override Resultado ValidateDelete(Competidor obj)
        {
            return new Resultado();
        }

        internal Competidor ConsultarCompetidor(string nomeJogador, int partidaId)
        {
            return Select().FirstOrDefault(c => c.Jogador.Nome == nomeJogador && c.PartidaId == partidaId);
        }
    }
}
