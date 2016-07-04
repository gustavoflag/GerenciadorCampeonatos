using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;
using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioView>();

                cfg.CreateMap<UsuarioView, Usuario>();

                cfg.CreateMap<Usuario, UsuarioViewList>()
                    .ForMember(uvl => uvl.PerfilNome, u => u.MapFrom(src => src.Perfil.Nome));
            });
        }

    }
}