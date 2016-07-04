using System.ComponentModel.DataAnnotations;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class UsuarioView
    {
        public UsuarioView()
        {
        }        
        
        public int UsuarioId { get; set; }
        
        public int PerfilId { get; set; }

        [Required(ErrorMessage = "Informar o Login")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informar a senha")]
        public string Senha { get; set; }
    }
}