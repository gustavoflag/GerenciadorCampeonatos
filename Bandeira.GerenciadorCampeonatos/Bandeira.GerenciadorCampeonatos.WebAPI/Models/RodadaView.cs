using System.ComponentModel.DataAnnotations;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class RodadaView
    {
        public int RodadaId { get; set; }

        [Required(ErrorMessage = "Campeonato obrigatório")]
        public int CampeonatoId { get; set; }

        [Required(ErrorMessage = "Numero rodada obrigatório")]
        public int Numero { get; set; }
    }
}