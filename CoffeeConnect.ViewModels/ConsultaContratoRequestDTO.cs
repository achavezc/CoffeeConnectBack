using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaContratoRequestDTO
    {

        public String Numero { get; set; }

        public String NumeroCliente { get; set; }

        public String RazonSocial { get; set; }

        public String ProductoId { get; set; }

        public String TipoProduccionId { get; set; }

        public String CalidadId { get; set; }

        public String EstadoId { get; set; }

        public int EmpresaId { get; set; }
        public string TipoContratoId { get; set; }


        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }


        public string EstadoFijacionId { get; set; }

        public string CondicionEmbarqueId
        { get; set; }

        public string EstadoPagoFacturaId { get; set; }
        public string CodigoInterno { get; set; }

    }
}
