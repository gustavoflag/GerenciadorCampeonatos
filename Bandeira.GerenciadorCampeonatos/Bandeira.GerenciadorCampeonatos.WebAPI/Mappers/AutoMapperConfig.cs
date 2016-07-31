using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;
using System.Linq;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioView>();
                cfg.CreateMap<Usuario, UsuarioViewList>()
                    .ForMember(uvl => uvl.PerfilNome, u => u.MapFrom(src => src.Perfil.Nome));
                cfg.CreateMap<Perfil, PerfilView>();
                cfg.CreateMap<Campeonato, CampeonatoView>();
                cfg.CreateMap<Jogador, JogadorView>();
                cfg.CreateMap<Local, LocalView>();
                cfg.CreateMap<Pontuacao, PontuacaoView>();
                cfg.CreateMap<Rodada, RodadaView>();
                cfg.CreateMap<JogadorCampeonato, JogadorPontosView>()
                    .ForMember(jpv => jpv.Pontos, j => j.MapFrom(src => src.Jogador.Competidores.Sum(c => c.Resultado.Pontuacao.Pontos)))
                    .ForMember(jpv => jpv.RodadasParticipadas, j => j.MapFrom(src => src.Jogador.Competidores.Count()))
                    .ForMember(jpv => jpv.Nome, j => j.MapFrom(src => src.Jogador.Nome));

                cfg.CreateMap<UsuarioView, Usuario>();
                cfg.CreateMap<PerfilView, Perfil>();
                cfg.CreateMap<CampeonatoView, Campeonato>();
                cfg.CreateMap<JogadorView, Jogador>();
                cfg.CreateMap<LocalView, Local>();
                cfg.CreateMap<PontuacaoView, Pontuacao>();
                cfg.CreateMap<RodadaView, Rodada>();
            });
        }

    }
}