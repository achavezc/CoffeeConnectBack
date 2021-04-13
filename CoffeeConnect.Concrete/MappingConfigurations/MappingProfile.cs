using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Models;

namespace CoffeeConnect.Service.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RegistrarActualizarProductorRequestDTO, Productor>();
            CreateMap<RegistrarActualizarSocioRequestDTO, Socio>();
            CreateMap<RegistrarActualizarProductorFincaRequestDTO, ProductorFinca>();
            CreateMap<RegistrarActualizarSocioFincaRequestDTO, SocioFinca>();
            CreateMap<RegistrarActualizarSocioFincaCertificacionRequestDTO, SocioFincaCertificacion>();
            CreateMap<NotaSalidaAlmacen, GuiaRemisionAlmacen>();
            CreateMap<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE, GuiaRemisionAlmacenDetalleTipo>();
            CreateMap<RegistrarActualizarClienteRequestDTO, Cliente>();
            CreateMap<RegistrarActualizarContratoRequestDTO, Contrato>();
        }
    }

}
