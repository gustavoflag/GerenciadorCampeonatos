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
    
    public partial class Local
    {
        public Local()
        {
            this.Partidas = new HashSet<Partida>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.Data.Spatial.DbGeography Localizacao { get; set; }
    
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}