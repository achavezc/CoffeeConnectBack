using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Anticipo;
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
            CreateMap<NotaSalidaAlmacenPlanta, GuiaRemisionAlmacenPlanta>();
            CreateMap<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE, GuiaRemisionAlmacenDetalleTipo>();
            CreateMap<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE, GuiaRemisionAlmacenPlantaDetalleTipo>();
            CreateMap<RegistrarActualizarClienteRequestDTO, Cliente>();
            CreateMap<RegistrarActualizarEmpresaTransporteRequestDTO, EmpresaTransporte>();
            CreateMap<RegistrarActualizarTransporteRequestDTO, Transporte>();
            CreateMap<RegistrarActualizarFincaMapaRequestDTO, FincaMapa>();
            CreateMap<RegistrarActualizarFincaDocumentoAdjuntoRequestDTO, FincaDocumentoAdjunto>();
            CreateMap<RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO, FincaFotoGeoreferenciada>();
            CreateMap<RegistrarActualizarContratoRequestDTO, Contrato>();
            CreateMap<RegistrarActualizarContratoCompraRequestDTO, ContratoCompra>();
            CreateMap<RegistrarActualizarZonaRequestDTO, Zona>();

            CreateMap<RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO, AduanaDocumentoAdjunto>();

            CreateMap<RegistrarActualizarAduanaRequestDTO, Aduana>();
            CreateMap<RegistrarActualizarDetalleCatalogoRequestDTO, DetalleCatalogo>();
            CreateMap<RegistrarSocioDocumentoRequestDTO, SocioDocumento>();
            CreateMap<RegistrarProductorDocumentoRequestDTO, ProductorDocumento>();
            CreateMap<RegistrarActualizarSocioProyectoRequestDTO, SocioProyecto>();
            CreateMap<RegistrarActualizarLiquidacionProcesoPlantaRequestDTO, LiquidacionProcesoPlanta>();
            CreateMap<RegistrarActualizarOrdenProcesoPlantaRequestDTO, OrdenProcesoPlanta>();
            CreateMap<RegistrarActualizarOrdenProcesoRequestDTO, OrdenProceso>();
            CreateMap<RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO, NotaIngresoPlanta>();
            CreateMap<RegistrarActualizarUbigeoRequestDTO, Ubigeo>();
            CreateMap<RegistrarActualizarProductoPrecioDiaRequestDTO, ProductoPrecioDia>();
            CreateMap<RegistrarActualizarTipoCambioDiaRequestDTO, TipoCambioDia>();
            CreateMap<RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO, EmpresaProveedoraAcreedora>();
            CreateMap<RegistrarActualizarInspeccionInternaRequestDTO, InspeccionInterna>();
            CreateMap<RegistrarActualizarDiagnosticoRequestDTO, Diagnostico>();
            CreateMap<RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO, NotaIngresoPlantaDocumentoAdjunto>();
            CreateMap<RegistrarActualizarAdelantoRequestDTO, Adelanto>();
            CreateMap<RegistrarActualizarAnticipoRequestDTO, Anticipo>();
            CreateMap<RegistrarActualizarKardexProcesoRequestDTO, KardexProceso>();
            CreateMap<RegistrarActualizarKardexPlantaRequestDTO, KardexPlanta>();

            CreateMap<RegistrarActualizarCorrelativoPlantaRequestDTO, CorrelativoPlanta>();

            CreateMap<RegistrarActualizarPesadoControlCalidadPlantaRequestDTO, ControlCalidadPlanta>();

            CreateMap<RegistrarActualizarEstadoControlCalidadPlantaRequestDTO, ControlCalidadPlanta>();




        }
    }

}
