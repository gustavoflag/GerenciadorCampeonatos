using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace Bandeira.GerenciadorCampeonatos.Model
{    
    public partial class Local : EntityBase
    {
        public Local()
        {
            this.Partidas = new HashSet<Partida>();
        }
    
        public string Nome { get; set; }
        public DbGeography Localizacao { get; set; }
    
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}
