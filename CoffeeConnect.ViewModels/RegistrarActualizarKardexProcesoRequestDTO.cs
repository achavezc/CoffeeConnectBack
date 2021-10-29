using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public  class RegistrarActualizarKardexProcesoRequestDTO
    {
        public int ContratoId { get; set; }
        public String TipoDocumentoInternoId { get; set; }
        public String TipoOperacionId { get; set; }

        public int EmpresaId { get; set; }
        public String Numero { get; set; }

        public String NumeroComprobanteInterno { get; set; }
        public String NumeroGuiaRemision { get; set; }

        public String NumeroContrato { get; set; }


        public String RucCliente { get; set; }

        public String TipoCertificacionId { get; set; }

        public String CalidadId { get; set; }

        public int CantidadSacosIngresados { get; set; }

        public int CantidadSacosDespachados { get; set; }

        public Decimal KilosIngresados { get; set; }
        public Decimal KilosDespachados { get; set; }

        public Decimal QQIngresados { get; set; }

        public Decimal QQDespachados { get; set; }
        public DateTime? FechaFactura { get; set; }
        public String NumeroFactura { get; set; }

        public Decimal PrecioUnitarioCP { get; set; }
        public Decimal PrecioUnitarioVenta { get; set; }

        public Decimal TotalVenta { get; set; }

        public Decimal TotalCP { get; set; }

        public String PlantaProcesoAlmacenId { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public String Usuario { get; set; }

        public int KardexProcesoId { get; set; }

    }
}
