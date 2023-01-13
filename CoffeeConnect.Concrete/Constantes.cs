using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Service
{
    public static class GuiaRecepcionMateriaPrimaEstados
    {
        public static string Pesado { get { return "01"; } }
        public static string Analizado { get { return "02"; } }
        public static string EnviadoAlmacen { get { return "03"; } }
        public static string Anulado { get { return "00"; } }
    }


    public static class GuiaRemisionAlmacenPlantaEstados
    {
        public static string Ingresado { get { return "01"; } }    
        public static string Anulado { get { return "00"; } }
    }

    public static class ClienteTipo
    {
        public static string Nacional { get { return "01"; } }
        public static string Internacional { get { return "02"; } }
    }


    public static class GuiaRemisionAlmacenEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class NotaIngresoPlantaEstados
    {
        public static string Pesado { get { return "01"; } }
        public static string Analizado { get { return "02"; } }
        public static string EnviadoAlmacen { get { return "03"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class PagoServicioPlantaEstados
    {
        public static string Registrado { get { return "01"; } }
        
        public static string Anulado { get { return "00"; } }

       
    }



    public static class ProductoTipo
    {
        public static string Pergamino { get { return "01"; } }
        public static string Exportacion { get { return "02"; } }

    }

    public static class SubProductoTipo
    {
        public static string Humedo { get { return "05"; } }

    }




    public static class ControlCalidadEstados
    {
        public static string  Anulado { get { return "00"; } }
        public static string Analizado { get { return "01"; } }
        public static string Rechazado { get { return "02"; } }
        public static string Procesado { get { return "03"; } }
        public static string EnviadoAlmacen { get { return "04"; } }

    }

    public static class TiposCorrelativosPlanta
    {
        public static string NotaIngresoPlantaTipo { get { return "01"; } }
        public static string NotaSalidaPlantaTipo { get { return "02"; } }
    }

        public static class Documentos
    {
        public static string GuiaRecepcion { get { return "GuiaRecepcion"; } }
        public static string NotaCompra { get { return "NotaCompra"; } }
        public static string NotaIngresoAlmacen { get { return "NotaIngresoAlmacen"; } }
        public static string Lote { get { return "Lote"; } }
        public static string Productor { get { return "Productor"; } }
        public static string Socio { get { return "Socio"; } }
        public static string NotaSalidaAlmacen { get { return "NotaSalidaAlmacen"; } }

        public static string ServicioPlanta { get { return "ServicioPlanta"; } }


        /// campo nuevo >


        public static string NotaIngresoProductoTerminadoAlmacenPlanta { get { return "NotaIngresoProductoTerminadoAlmacenPlanta"; } }

        
        /// //



        public static string Aduana { get { return "Aduana"; } }
        public static string Adelanto { get { return "Adelanto"; } }

        public static string Anticipo { get { return "Anticipo"; } }


        public static string NotaSalidaAlmacenPlanta { get { return "NotaSalidaAlmacenPlanta"; } }

        public static string LiquidacionProcesoPlanta { get { return "LiquidacionProcesoPlanta"; } }

        public static string LiquidacionSecadoPlanta { get { return "LiquidacionSecadoPlanta"; } }

        public static string LiquidacionReprocesoPlanta { get { return "LiquidacionReprocesoPlanta"; } }

        public static string UbigeoCiudad { get { return "UbigeoCiudad"; } }

        

        public static string GuiaRemisionAlmacen { get { return "GuiaRemisionAlmacen"; } }

        public static string GuiaRemisionAlmacenPlanta { get { return "GuiaRemisionAlmacenPlanta"; } }
        public static string OrdenServicioControlCalidad { get { return "OrdenServicioControlCalidad"; } }
        public static string OrdenProceso { get { return "OrdenProceso"; } }

        public static string OrdenProcesoPlanta { get { return "OrdenProcesoPlanta"; } }
        public static string Cliente { get { return "Cliente"; } }

        public static string InspeccionInterna { get { return "InspeccionInterna"; } }

        public static string Diagnostico { get { return "Diagnostico"; } }

        public static string Contrato { get { return "Contrato"; } }
        public static string NotaIngresoAlmacenPlanta { get { return "NotaIngresoAlmacenPlanta  "; } }

        public static string NotaIngresoPlanta { get { return "NotaIngresoPlanta  "; } }

        public static string PagoServicioPlanta { get { return "PagoServicioPlanta  "; } }

        public static string NotaControlCalidadPlanta { get { return "CalidadPlanta  "; } }

        public static string KardexProceso { get { return "KardexProceso"; } }

        public static string KardexPlanta { get { return "KardexPlanta"; } }

    }

    public static class NotaCompraEstados
    {
        public static string PorLiquidar { get { return "01"; } }
        public static string Liquidado { get { return "02"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class NotaCompraTipos
    {
        public static string Liquidado { get { return "01"; } }
        public static string Guardado { get { return "02"; } }
    }

    public static class NotaIngresoAlmacenEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Lotizado { get { return "02"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class NotaIngresoAlmacenPlantaEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Procesado { get { return "02"; } }
        public static string GeneradoNotaSalida { get { return "03"; } }
    }

    public static class NotaSalidaAlmacenEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
    }

    public static class NotaSalidaAlmacenPlantaMotivos
    {

        public static string Exportacion { get { return "01"; } }

        public static string Venta { get { return "02"; } }
        
        public static string Rechazo { get { return "03"; } }
        
    }

    public static class NotaIngresoAlmacenPlantaMotivos 
    {

        public static string Secado { get { return "01"; } }

        public static string Almacen { get { return "02"; } }

        public static string Transformacion { get { return "03"; } }

        public static string LiquidacionOrdenProceso { get { return "04"; } }

        public static string Compra { get { return "05"; } }

        public static string Reproceso { get { return "06"; } }


        public static string LiquidacionProcesoSecado { get { return "07"; } }

        public static string LiquidacionReproceso { get { return "08"; } }



    }


    public static class NotaSalidaAlmacenPlantaEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
    }

    public static class ClienteEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class AdelantoEstados
    {
        public static string PorLiquidar { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Liquidado { get { return "02"; } }

    }

    public static class ServicioPlantaEstados
    {
        public static string Deuda { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Cancelado { get { return "02"; } }

    }

    



    public static class NotaIngresoProductoTerminadoAlmacenPlantaEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Consumido { get { return "02"; } }
        public static string Procesado { get { return "03"; } }
        

    }

    public static class AnticipoEstados
    {
        public static string PorLiquidar { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Liquidado { get { return "02"; } }

    }
    public static class PrecioDiaRendimientoEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class TipoCambioDiaEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }




    public static class AduanaEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class KardexProcesoEstados
    {
        public static string Registrado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class KardexPlantaEstados
    {
        public static string Registrado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class ContratoEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Asignado { get { return "02"; } }

        public static string Completado { get { return "03"; } }

    }

    public static class ContratoCompraEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }       

        public static string Asignado { get { return "03"; } }

    }

    public static class LoteEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
        public static string GeneradoNotaSalida { get { return "03"; } }
    }

    public static class OrdenServicioControlCalidadEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
    }


    public static class ProductorEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class SocioEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class MaestroEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class OrdenProcesoEstados
    {
        public static string Anulado { get { return "00"; } }
    }

    public static class OrdenProcesoPlantaEstados
    {
        public static string Anulado { get { return "00"; } }

        public static string Registrado { get { return "01"; } }

        public static string Liquidado { get { return "02"; } }
    }


    public static class LiquidacionProcesoPlantaEstados
    {
        public static string Anulado { get { return "00"; } }

        public static string Liquidado { get { return "01"; } }

    }
}
