using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Models;

namespace CoffeeConnect.Service.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<RegistrarActualizarProductorRequestDTO, Productor> ();

        }
    }

}
