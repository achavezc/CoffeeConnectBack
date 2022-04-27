﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaKardexPlantaBE
    {
        public String KardexPlantaId { get; set; }

        public String ContratoId { get; set; }

        public String TipoDocumentoInternoId { get; set; }
        public String TipoOperacionId { get; set; }

        public String TipoRegistro { get; set; }
        public String TipoRegistroId { get; set; }
        public String EmpresaId { get; set; }
        public String Numero { get; set; }
        public String NumeroComprobanteInterno { get; set; }
        public String NumeroGuiaRemision { get; set; }
        public String NumeroContrato { get; set; }
        public String FechaContrato { get; set; }
        public String RucCliente { get; set; }

        public String Cliente { get; set; }

        public String TipoCertificacionId { get; set; }

        public String CalidadId { get; set; }

        public int CantidadSacosIngresados { get; set; }

        public int CantidadSacosDespachados { get; set; }

        public Decimal KilosIngresados { get; set; }

        public Decimal KilosDespachados { get; set; }

        public Decimal QQIngresados { get; set; }

        public Decimal QQDespachados { get; set; }

        public String FechaFactura { get; set; }

        public String NumeroFactura { get; set; }

        public Decimal PrecioUnitarioCP { get; set; }

        public Decimal PrecioUnitarioVenta { get; set; }

        public Decimal TotalVenta { get; set; }

        public Decimal TotalCP { get; set; }

        public String PlantaProcesoAlmacenId { get; set; }

        public String FechaIngreso { get; set; }

        public String FechaRegistro { get; set; }

        public String UsuarioRegistro { get; set; }

        public String FechaUltimaActualizacion { get; set; }

        public String UsuarioUltimaActualizacion { get; set; }

        public String EstadoId { get; set; }

        public int Activo { get; set; }

        public String RazonSocial { get; set; }

        public String Ruc { get; set; }

        public String Logo { get; set; }

        public String Direccion { get; set; }
        public String Estado { get; set; }
        public String TipoDocumentoInterno { get; set; }
        public String TipoOperacion { get; set; }
        public String PlantaProcesoAlmacen { get; set; }
        public String Calidad { get; set; }

        public String TipoCertificacion { get; set; }



        public Decimal? CompraBruta { get; set; }
        public Decimal? Tara { get; set; }
        public Decimal? PorcentajeRendimiento { get; set; }
        public Decimal? PorcentajeHumedad { get; set; }
        public Decimal? Tasa { get; set; }
        public Decimal? AproxExp { get; set; }
        public Decimal? AproxSacos { get; set; }
        public Decimal? AproxSeg { get; set; }


    }
}
