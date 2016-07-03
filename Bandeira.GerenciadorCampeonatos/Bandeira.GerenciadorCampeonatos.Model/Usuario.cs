using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        public int PerfilId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [JsonIgnore]
        public string Senha { get; set; }

        [Required]
        [ForeignKey("PerfilId")]
        [JsonIgnore]
        public virtual Perfil Perfil { get; set; }
    }
}
