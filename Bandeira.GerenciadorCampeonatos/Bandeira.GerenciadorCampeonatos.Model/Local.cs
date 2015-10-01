using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace Bandeira.GerenciadorCampeonatos.Model
{    
    public partial class Local : EntityBase
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
