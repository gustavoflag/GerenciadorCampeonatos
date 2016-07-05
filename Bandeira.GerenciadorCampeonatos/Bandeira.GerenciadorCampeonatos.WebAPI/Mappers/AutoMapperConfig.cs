using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;

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

                cfg.CreateMap<UsuarioView, Usuario>();
                cfg.CreateMap<PerfilView, Perfil>();
            });
        }

    }
}