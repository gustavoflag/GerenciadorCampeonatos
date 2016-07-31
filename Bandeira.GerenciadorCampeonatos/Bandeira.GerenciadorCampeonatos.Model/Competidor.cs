using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Competidor")]
    public partial class Competidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetidorId { get; set; }

        public int PartidaId { get; set; }

        public int JogadorId { get; set; }

        public int? ResultadoPartidaId { get; set; }

        [ForeignKey("PartidaId")]
        public virtual Partida Partida { get; set; }

        [Required]
        [ForeignKey("JogadorId")]
        public virtual Jogador Jogador { get; set; }

        [ForeignKey("ResultadoPartidaId")]
        public virtual ResultadoPartida Resultado { get; set; }
    }
}
