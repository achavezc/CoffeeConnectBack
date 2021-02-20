//using CoffeeConnect.DTO;
//using CoffeeConnect.Models;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace CoffeeConnect.Interface.Repository
//{
//    public interface INotaSalidaRepository
//    {
//        int Insertar(NotaCompra notaCompra);

//        int Actualizar(NotaCompra notaCompra);

//        int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId);

//        IEnumerable<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalida(ConsultaNotaSalidaAlmacenRequestDTO request);

//        IEnumerable<NotaSalidaAlmacenAnalisisFisicoColorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoColorDetallePorId(int NotaSalidaAlmacenId);
//        IEnumerable<NotaSalidaAlmacenAnalisisFisicoOlorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoOlorDetallePorId(int NotaSalidaAlmacenId);

//        IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetallePorId(int NotaSalidaAlmacenId);
//        IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetallePorId(int NotaSalidaAlmacenId);
//        IEnumerable<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialAtributoDetallePorId(int NotaSalidaAlmacenId);
//        IEnumerable<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialDefectoDetallePorId(int NotaSalidaAlmacenId);
//        IEnumerable<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle> ConsultarNotaSalidaAlmacenRegistroTostadoIndicadorDetallePorId(int NotaSalidaAlmacenId);

//        int ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalle(List<NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo> request, int NotaSalidaAlmacenId);
//        int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaSalidaAlmacenId);
//        int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaSalidaAlmacenId);
//        int ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalle(List<NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo> request, int NotaSalidaAlmacenId);
//        int ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalle(List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo> request, int NotaSalidaAlmacenId);
//        int ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalle(List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo> request, int NotaSalidaAlmacenId);
//        int ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalle(List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo> request, int NotaSalidaAlmacenId);







//    }
//}