using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public interface IContainer
    {
        IDbSet<Campeonato> Campeonatos { get; set; }
        IDbSet<Rodada> Rodadas { get; set; }
        IDbSet<Partida> Partidas { get; set; }
        IDbSet<Competidor> Competidores { get; set; }
        IDbSet<Jogador> Jogadores { get; set; }
        IDbSet<Pontuacao> Pontuacoes { get; set; }
        IDbSet<ResultadoPartida> Resultados { get; set; }
        IDbSet<Local> Locais { get; set; }
        IDbSet<JogadorCampeonato> JogadorCampeonatos { get; set; }
        IDbSet<Perfil> Perfis { get; set; }
        IDbSet<Usuario> Usuarios { get; set; }

        int SaveChanges();
    }
}
