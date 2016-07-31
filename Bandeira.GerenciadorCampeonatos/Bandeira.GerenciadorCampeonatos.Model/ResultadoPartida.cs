using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("ResultadoPartida")]
    public partial class ResultadoPartida
    {
        public int PontuacaoId { get; set; }
        public int PartidaId { get; set; }
        public int? Valor { get; set; }

        public int CompetidorId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultadoPartidaId { get; set; }

        [Required]
        [ForeignKey("PontuacaoId")]
        public virtual Pontuacao Pontuacao { get; set; }

        [Required]
        [ForeignKey("CompetidorId")]
        public virtual Competidor Competidor { get; set; }

        [Required]
        [ForeignKey("PartidaId")]
        public virtual Partida Partida { get; set; }
    }
}
