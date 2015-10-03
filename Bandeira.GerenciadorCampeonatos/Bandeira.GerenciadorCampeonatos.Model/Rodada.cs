using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Rodada")]
    public partial class Rodada
    {
        public Rodada()
        {
            this.Partidas = new HashSet<Partida>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RodadaId { get; set; }
    
        public int CampeonatoId { get; set; }
        public int Numero { get; set; }

        [Required]
        [ForeignKey("CampeonatoId")]
        public virtual Campeonato Campeonato { get; set; }
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}
