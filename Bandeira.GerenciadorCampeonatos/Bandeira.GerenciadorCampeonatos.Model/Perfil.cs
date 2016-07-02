using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Perfil")]
    public class Perfil
    {
        public Perfil()
        {
            this.Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerfilId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool PermissaoPartida { get; set; }

        [Required]
        public bool PermissaoCampeonato { get; set; }

        [Required]
        public bool PermissaoAcesso { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
