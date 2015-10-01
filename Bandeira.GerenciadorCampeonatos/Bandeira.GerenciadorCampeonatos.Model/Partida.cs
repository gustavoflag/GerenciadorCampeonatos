using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{   
    public partial class Partida : EntityBase
    {
        public Partida()
        {
            this.Competidores = new HashSet<Competidor>();
            this.Resultados = new HashSet<ResultadoPartida>();
        }

        [Key]
        public int PartidaId { get; set; }

        public int RodadaId { get; set; }
        public int LocalId { get; set; }

        [ForeignKey("RodadaId")]
        public virtual Rodada Rodada { get; set; }
        public virtual ICollection<Competidor> Competidores { get; set; }
        public virtual ICollection<ResultadoPartida> Resultados { get; set; }

        [ForeignKey("LocalId")]
        public virtual Local Local { get; set; }
    }
}
