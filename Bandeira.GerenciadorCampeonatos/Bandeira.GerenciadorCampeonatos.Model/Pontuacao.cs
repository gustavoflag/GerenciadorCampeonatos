using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class Pontuacao : EntityBase
    {
        public Pontuacao()
        {
            this.Resultados = new HashSet<ResultadoPartida>();
        }
    
        public int CampeonatoId { get; set; }
        public int Colocacao { get; set; }
        public int Pontos { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Campeonato Campeonato { get; set; }
        public virtual ICollection<ResultadoPartida> Resultados { get; set; }
    }
}
