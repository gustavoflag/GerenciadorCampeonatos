using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class Jogador : EntityBase
    {
        public Jogador()
        {
            this.Campeonatos = new HashSet<JogadorCampeonato>();
        }
    
        public int CampeonatoId { get; set; }
        public string Nome { get; set; }
    
        public virtual Competidor Competidor { get; set; }
        public virtual ICollection<JogadorCampeonato> Campeonatos { get; set; }
    }
}
