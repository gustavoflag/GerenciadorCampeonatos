using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{    
    [Table("Campeonato")]
    public partial class Campeonato
    {
        public Campeonato()
        {
            this.Rodadas = new HashSet<Rodada>();
            this.Pontuacoes = new HashSet<Pontuacao>();
            this.Jogadores = new HashSet<JogadorCampeonato>();
        }
    
        [Key]
        public int CampeonatoId { get; set; } 

        public string Nome { get; set; }
    
        public virtual ICollection<Rodada> Rodadas { get; set; }
        public virtual ICollection<Pontuacao> Pontuacoes { get; set; }
        public virtual ICollection<JogadorCampeonato> Jogadores { get; set; }
    }
}
