using System.ComponentModel.DataAnnotations;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class JogadorView
    {
        public int JogadorId { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }
    }
}