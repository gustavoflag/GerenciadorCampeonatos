using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            Mapper.Initialize(cfg =>
            {
                
            });
        }
    }
}
