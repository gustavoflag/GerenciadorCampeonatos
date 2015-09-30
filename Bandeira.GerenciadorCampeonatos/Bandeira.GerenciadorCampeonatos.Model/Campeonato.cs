using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{    
    public partial class Campeonato : EntityBase
    {
        public Campeonato()
        {
            this.Rodadas = new HashSet<Rodada>();
            this.Pontuacoes = new HashSet<Pontuacao>();
            this.Jogadores = new HashSet<JogadorCampeonato>();
        }
    
        public string Nome { get; set; }
    
        public virtual ICollection<Rodada> Rodadas { get; set; }
        public virtual ICollection<Pontuacao> Pontuacoes { get; set; }
        public virtual ICollection<JogadorCampeonato> Jogadores { get; set; }
    }
}
