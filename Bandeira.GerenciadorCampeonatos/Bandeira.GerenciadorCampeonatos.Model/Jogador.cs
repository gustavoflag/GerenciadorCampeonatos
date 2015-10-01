using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class Jogador : EntityBase
    {
        public Jogador()
        {
            this.Campeonatos = new HashSet<JogadorCampeonato>();
        }

        [Key]
        public int JogadorId { get; set; }

        public string Nome { get; set; }

        //[ForeignKey("CompetidorId")]
        //public virtual Competidor Competidor { get; set; }

        public virtual ICollection<JogadorCampeonato> Campeonatos { get; set; }
    }
}
