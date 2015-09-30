namespace Bandeira.GerenciadorCampeonatos.Model
{
    public partial class JogadorCampeonato : EntityBase
    {
        public int CampeonatoId { get; set; }
    
        public virtual Campeonato Campeonato { get; set; }
        public virtual Jogador Jogador { get; set; }
    }
}
