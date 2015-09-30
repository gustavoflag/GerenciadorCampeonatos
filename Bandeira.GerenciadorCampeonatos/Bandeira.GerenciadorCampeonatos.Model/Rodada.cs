using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{    
    public partial class Rodada : EntityBase
    {
        public Rodada()
        {
            this.Partidas = new HashSet<Partida>();
        }
    
        public int CampeonatoId { get; set; }
        public int Numero { get; set; }
    
        public virtual Campeonato Campeonato { get; set; }
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}
