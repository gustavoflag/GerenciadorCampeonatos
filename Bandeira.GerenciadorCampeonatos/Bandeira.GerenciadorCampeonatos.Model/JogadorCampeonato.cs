using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class JogadorCampeonato : EntityBase
    {
        [Key]
        public int JogadorCampeonatoId { get; set; }

        public int CampeonatoId { get; set; }
        public int JogadorId { get; set; }

        [ForeignKey("CampeonatoId")]
        public virtual Campeonato Campeonato { get; set; }

        [ForeignKey("JogadorId")]
        public virtual Jogador Jogador { get; set; }
    }
}
