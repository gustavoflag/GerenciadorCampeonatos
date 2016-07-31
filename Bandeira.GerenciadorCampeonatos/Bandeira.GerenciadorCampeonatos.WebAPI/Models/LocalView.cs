using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Models
{
    public class LocalView
    {
        public int LocalId { get; set; }

        [Required]
        public string Nome { get; set; }

        public DbGeography Localizacao { get; set; }
    }
}