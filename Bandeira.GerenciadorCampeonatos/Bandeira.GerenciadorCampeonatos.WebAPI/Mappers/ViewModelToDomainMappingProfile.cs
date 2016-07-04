using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UsuarioView, Usuario>();
            });
        }
    }
}