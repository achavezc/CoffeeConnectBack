﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Service
{   

    public static class GuiaRecepcionMateriaPrimaEstados
    {
        public static String Pesado { get { return "01"; } }
        public static String Analizado { get { return "02"; } }

        public static String EnviadoGuardiola { get { return "03"; } }

        public static String EnviadoAlmacen { get { return "04"; } }
        public static String Anulado { get { return "00"; } }
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
        public static String Anulado { get { return "00"; } }
    }
}
