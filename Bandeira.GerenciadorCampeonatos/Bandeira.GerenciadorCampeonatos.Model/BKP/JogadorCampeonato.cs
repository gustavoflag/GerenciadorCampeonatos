//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class JogadorCampeonato
    {
        public int Id { get; set; }
        public int CampeonatoId { get; set; }
    
        public virtual Campeonato Campeonato { get; set; }
        public virtual Jogador Jogador { get; set; }
    }
}