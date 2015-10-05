using Bandeira.GerenciadorCampeonatos.Model.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Jogador")]
    public partial class Jogador
    {
        public Jogador()
        {
            this.Campeonatos = new HashSet<JogadorCampeonato>();
            this.Competidores = new HashSet<Competidor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogadorId { get; set; }

        [UniqueKey]
        public string Nome { get; set; }

        public virtual ICollection<Competidor> Competidores { get; set; }

        public virtual ICollection<JogadorCampeonato> Campeonatos { get; set; }
    }
}
