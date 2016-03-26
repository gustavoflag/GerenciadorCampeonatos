using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Partida")]
    public partial class Partida
    {
        public Partida()
        {
            this.Competidores = new HashSet<Competidor>();
            this.Resultados = new HashSet<ResultadoPartida>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartidaId { get; set; }

        public DateTime? Data { get; set; }

        public int RodadaId { get; set; }
        public int? LocalId { get; set; }

        [Required]
        [ForeignKey("RodadaId")]
        public virtual Rodada Rodada { get; set; }

        public virtual ICollection<Competidor> Competidores { get; set; }
        public virtual ICollection<ResultadoPartida> Resultados { get; set; }

        [ForeignKey("LocalId")]
        public virtual Local Local { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Competidores: ");
            
            foreach(Competidor competidor in Competidores)
            {
                sb.Append(competidor.JogadorId);
                sb.Append(",");
            }

            return sb.ToString(); 
        }
    }
}
