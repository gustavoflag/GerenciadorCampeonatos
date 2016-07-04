using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class UsuarioViewList
    {
        public UsuarioViewList()
        {
        }

        public int UsuarioId { get; set; }

        public int PerfilId { get; set; }

        public string PerfilNome { get; set; }  

        public string Login { get; set; }
    }
}