﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bandeira.GerenciadorCampeonatos.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GerenciadorCampeonatosContainer : DbContext
    {
        public GerenciadorCampeonatosContainer()
            : base("name=GerenciadorCampeonatosContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Rodada> Rodadas { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Pontuacao> Pontuacoes { get; set; }
        public DbSet<ResultadoPartida> Resultados { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<JogadorCampeonato> JogadorCampeonatos { get; set; }
        public DbSet<EntityBase> EntityBaseSet { get; set; }
    }
}