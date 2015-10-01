using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bandeira.GerenciadorCampeonatos.Model
{   
    public partial class Competidor : EntityBase
    {
        [Key]
        public int CompetidorId { get; set; }

        public int PartidaId { get; set; }

        public int JogadorId { get; set; }

        [ForeignKey("PartidaId")]
        public virtual Partida Partida { get; set; }

        [ForeignKey("JogadorId")]
        public virtual Jogador Jogador { get; set; }


        //public virtual ResultadoPartida Resultado { get; set; }
    }
}
