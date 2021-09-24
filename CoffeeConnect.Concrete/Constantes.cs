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

    public static class Documentos
    {
        public static string GuiaRecepcion { get { return "GuiaRecepcion"; } }
        public static string NotaCompra { get { return "NotaCompra"; } }
        public static string NotaIngresoAlmacen { get { return "NotaIngresoAlmacen"; } }
        public static string Lote { get { return "Lote"; } }
        public static string Productor { get { return "Productor"; } }
        public static string Socio { get { return "Socio"; } }
        public static string NotaSalidaAlmacen { get { return "NotaSalidaAlmacen"; } }

        public static string Aduana { get { return "Aduana"; } }
        public static string Adelanto { get { return "Adelanto"; } }


        public static string NotaSalidaAlmacenPlanta { get { return "NotaSalidaAlmacenPlanta"; } }

        public static string LiquidacionProcesoPlanta { get { return "LiquidacionProcesoPlanta"; } }

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

        public static string GeneradoNotaSalida { get { return "02"; } }
    }

    public static class NotaSalidaAlmacenEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
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

    

    public static class ContratoEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Asignado { get { return "02"; } }

        public static string Completado { get { return "03"; } }

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
}
