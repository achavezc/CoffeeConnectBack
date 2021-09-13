using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaAduanaRequestDTO
    {

        public String Numero { get; set; }

        public String NumeroContrato { get; set; }

        public String RazonSocialCliente { get; set; }        

        public String RazonSocialEmpresaAgenciaAduanera { get; set; }

        public String RazonSocialEmpresaExportadora { get; set; }

        public String RazonSocialEmpresaProductora { get; set; }

        public String EstadoId { get; set; }

        public int EmpresaId { get; set; }   

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

    }
}
