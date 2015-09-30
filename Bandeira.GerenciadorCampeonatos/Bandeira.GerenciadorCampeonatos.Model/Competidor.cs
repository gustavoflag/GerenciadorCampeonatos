namespace Bandeira.GerenciadorCampeonatos.Model
{   
    public partial class Competidor : EntityBase
    {
        public int PartidaId { get; set; }
    
        public virtual Partida Partida { get; set; }
        public virtual Jogador Jogador { get; set; }
        public virtual ResultadoPartida Resultado { get; set; }
    }
}
