using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Local")]
    public partial class Local
    {
        public Local()
        {
            this.Partidas = new HashSet<Partida>();
        }

        [Key]
        public int LocalId { get; set; }

        public string Nome { get; set; }
        public DbGeography Localizacao { get; set; }
    
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}
