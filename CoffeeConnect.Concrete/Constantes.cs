using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Service
{   

    public static class GuiaRecepcionMateriaPrimaEstados
    {
        public static String Pesado { get { return "01"; } }
        public static String Analizado { get { return "02"; } }
      
        public static String EnviadoAlmacen { get { return "03"; } }
        public static String Anulado { get { return "00"; } }
    }

    public static class Documentos
    {
        public static String GuiaRecepcion { get { return "GuiaRecepcion"; } }
        public static String NotaCompra { get { return "NotaCompra"; } }

        public static String NotaIngresoAlmacen { get { return "NotaIngresoAlmacen"; } }

        public static String Lote { get { return "Lote"; } }

        public static String Productor { get { return "Productor"; } }

        public static String Socio { get { return "Socio"; } }

        public static String NotaSalidaAlmacen { get { return "NotaSalidaAlmacen"; } }

        public static String GuiaRemisionAlmacen { get { return "GuiaRemisionAlmacen"; } }


    }

    public static class NotaCompraEstados
    {
        public static String PorLiquidar { get { return "01"; } }
        public static String Liquidado { get { return "02"; } }
        public static String Anulado { get { return "00"; } }
    }

    public static class NotaCompraTipos
    {
        public static String Liquidado { get { return "01"; } }
        public static String Guardado { get { return "02"; } }
       
    }

    public static class NotaIngresoAlmacenEstados
    {
        public static String Ingresado { get { return "01"; } }

        public static String Lotizado { get { return "02"; } }
        public static String Anulado { get { return "00"; } }
    }

    public static class NotaSalidaAlmacenEstados
    {
        public static String Ingresado { get { return "01"; } }
      
        public static String Anulado { get { return "00"; } }

        public static String Analizado { get { return "02"; } }
    }

    public static class LoteEstados
    {
        public static String Ingresado { get { return "01"; } }
        public static String Anulado { get { return "00"; } }
        public static String GeneradoNotaSalida { get { return "02"; } }
    }

    public static class OrdenServicioControlCalidadEstados
    {
        public static String Ingresado { get { return "01"; } }
        public static String Anulado { get { return "00"; } }

        public static String Analizado { get { return "02"; } }
    }


    public static class ProductorEstados
    {
        public static String Activo { get { return "01"; } }

        public static String Anulado { get { return "00"; } }


    }

    public static class SocioEstados
    {
        public static String Activo { get { return "01"; } }

        public static String Anulado { get { return "00"; } }


    }


    public static class MaestroEstados
    {
        public static String Activo { get { return "01"; } }

        public static String Anulado { get { return "00"; } }


    }
}
