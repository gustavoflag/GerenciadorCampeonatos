using System.ComponentModel.DataAnnotations;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class CampeonatoView
    {
        public int CampeonatoId { get; set; }

        public int? QuantidadeJogadoresPorPartida { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]   
        public string Nome { get; set; }
    }
}