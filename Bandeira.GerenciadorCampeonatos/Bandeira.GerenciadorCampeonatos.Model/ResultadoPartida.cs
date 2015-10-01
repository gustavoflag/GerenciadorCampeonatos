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

        [Key]
        public int ResultadoPartidaId { get; set; }

        [ForeignKey("PontuacaoId")]
        public virtual Pontuacao Pontuacao { get; set; }
        
        public virtual Competidor Competidor { get; set; }

        [ForeignKey("PartidaId")]
        public virtual Partida Partida { get; set; }
    }
}
