using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{   
    public partial class Partida : EntityBase
    {
        public Partida()
        {
            this.Competidores = new HashSet<Competidor>();
            this.Resultados = new HashSet<ResultadoPartida>();
        }
    
        public int RodadaId { get; set; }
        public int LocalId { get; set; }
    
        public virtual Rodada Rodada { get; set; }
        public virtual ICollection<Competidor> Competidores { get; set; }
        public virtual ICollection<ResultadoPartida> Resultados { get; set; }
        public virtual Local Local { get; set; }
    }
}
