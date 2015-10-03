using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("JogadorCampeonato")]
    public partial class JogadorCampeonato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogadorCampeonatoId { get; set; }

        public int CampeonatoId { get; set; }
        public int JogadorId { get; set; }

        [Required]
        [ForeignKey("CampeonatoId")]
        public virtual Campeonato Campeonato { get; set; }

        [Required]
        [ForeignKey("JogadorId")]
        public virtual Jogador Jogador { get; set; }
    }
}
