using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public  class RegistrarActualizarKardexPlantaRequestDTO
    {
        public int ContratoId { get; set; }
        public String TipoDocumentoInternoId { get; set; }
        public String TipoOperacionId { get; set; }
        public String TipoRegistroId { get; set; }

        public int EmpresaId { get; set; }
        public String Numero { get; set; }

        public String NumeroComprobanteInterno { get; set; }
        public String NumeroGuiaRemision { get; set; }

        public String NumeroContrato { get; set; }

        public DateTime? FechaContrato { get; set; }

        public String RucCliente { get; set; }

        public String TipoCertificacionId { get; set; }

        public String CalidadId { get; set; }

        public int CantidadSacosIngresados { get; set; }

        public int CantidadSacosDespachados { get; set; }

        public decimal KilosIngresados { get; set; }
        public decimal KilosDespachados { get; set; }

        public decimal QQIngresados { get; set; }

        public decimal QQDespachados { get; set; }
        public DateTime? FechaFactura { get; set; }
        public String NumeroFactura { get; set; }

        public decimal PrecioUnitarioCP { get; set; }
        public decimal PrecioUnitarioVenta { get; set; }

        public decimal TotalVenta { get; set; }

        public decimal TotalCP { get; set; }

        public String PlantaProcesoAlmacenId { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public String Usuario { get; set; }

        public int KardexPlantaId { get; set; }

        public decimal? CompraBruta { get; set; }
        public decimal? Tara { get; set; }
        public decimal? PorcentajeRendimiento { get; set; }
        public decimal? PorcentajeHumedad { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? AproxExp { get; set; }
        public decimal? AproxSacos { get; set; }
        public decimal? AproxSeg { get; set; }

    }
}
