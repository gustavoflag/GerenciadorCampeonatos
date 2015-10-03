using Bandeira.GerenciadorCampeonatos.Model.DataAnnotations;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocalId { get; set; }

        [UniqueKey]
        public string Nome { get; set; }
        public DbGeography Localizacao { get; set; }
    
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}
