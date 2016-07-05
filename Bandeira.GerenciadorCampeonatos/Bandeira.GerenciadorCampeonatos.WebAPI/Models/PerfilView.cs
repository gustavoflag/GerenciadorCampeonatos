using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class PerfilView
    {
        public PerfilView()
        {
        }

        public int PerfilId { get; set; }

        [Required(ErrorMessage = "Nome Perfil Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Permissão Partida Obrigatório")]
        public bool PermissaoPartida { get; set; }

        [Required(ErrorMessage = "Permissão Campeonato Obrigatório")]
        public bool PermissaoCampeonato { get; set; }

        [Required(ErrorMessage = "Permissão Acesso Obrigatório")]
        public bool PermissaoAcesso { get; set; }
    }
}