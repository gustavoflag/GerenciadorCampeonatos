using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class PontuacaoView
    {
        public int PontuacaoId { get; set; }

        [Required(ErrorMessage = "Campeonato Obrigatório")]
        public int CampeonatoId { get; set; }

        [Required(ErrorMessage = "Colocacao Obrigatório")]
        public int Colocacao { get; set; }

        [Required(ErrorMessage = "Pontos Obrigatório")]
        public int Pontos { get; set; }

        [Required(ErrorMessage = "Data Cadastro Obrigatório")]
        public System.DateTime DtCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}