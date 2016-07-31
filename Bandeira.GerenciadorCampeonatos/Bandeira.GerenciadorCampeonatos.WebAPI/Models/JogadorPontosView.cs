using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class JogadorPontosView
    {
        public int JogadorId { get; set; }

        public string Nome { get; set; }

        public int Pontos { get; set; }

        public int RodadasParticipadas { get; set; }
    }
}