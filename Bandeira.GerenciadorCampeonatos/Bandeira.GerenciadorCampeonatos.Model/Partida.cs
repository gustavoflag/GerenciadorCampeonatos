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
    
    public partial class Partida
    {
        public Partida()
        {
            this.Competidores = new HashSet<Competidor>();
            this.Resultados = new HashSet<Resultado>();
        }
    
        public int Id { get; set; }
        public int RodadaId { get; set; }
        public int LocalId { get; set; }
    
        public virtual Rodada Rodada { get; set; }
        public virtual ICollection<Competidor> Competidores { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
        public virtual Local Local { get; set; }
    }
}
