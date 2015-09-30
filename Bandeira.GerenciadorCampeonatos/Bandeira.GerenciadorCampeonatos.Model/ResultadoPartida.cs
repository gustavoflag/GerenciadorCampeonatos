using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class ResultadoPartida : EntityBase
    {
        public int PontuacaoId { get; set; }
        public int PartidaId { get; set; }
        public int? Valor { get; set; }
    
        public virtual Pontuacao Pontuacao { get; set; }
        public virtual Competidor Competidor { get; set; }
        public virtual Partida Partida { get; set; }
    }
}
