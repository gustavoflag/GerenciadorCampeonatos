﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class GerenciadorCampeonatosContainer : DbContext, IContainer
    {
        public GerenciadorCampeonatosContainer()
            : base("name=GerenciadorCampeonatosContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<GerenciadorCampeonatosContainer>(new DropCreateDatabaseIfModelChanges<GerenciadorCampeonatosContainer>());
            //Database.SetInitializer<GerenciadorCampeonatosContainer>(new DropCreateDatabaseAlways<GerenciadorCampeonatosContainer>());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();   
        }

        public IDbSet<Campeonato> Campeonatos { get; set; }
        public IDbSet<Rodada> Rodadas { get; set; }
        public IDbSet<Partida> Partidas { get; set; }
        public IDbSet<Competidor> Competidores { get; set; }
        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Pontuacao> Pontuacoes { get; set; }
        public IDbSet<ResultadoPartida> Resultados { get; set; }
        public IDbSet<Local> Locais { get; set; }
        public IDbSet<JogadorCampeonato> JogadorCampeonatos { get; set; }
        public IDbSet<Perfil> Perfis { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }

    }
}
