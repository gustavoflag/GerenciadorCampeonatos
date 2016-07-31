using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class JogadorCampeonatoView
    {
        [Required(ErrorMessage = "Informe o campeonato")]
        public int CampeonatoId { get; set; }

        [Required(ErrorMessage = "Informe o jogador")]
        public int JogadorId { get; set; }

        public string CampeonatoNome { get; set; }

        public string JogadorNome { get; set; }
    }
}