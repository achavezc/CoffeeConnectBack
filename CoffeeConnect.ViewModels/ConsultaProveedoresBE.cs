using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaProveedoresBE
    {

        public int ProveedorId { get; set; }
        public int ProductorId { get; set; }

        public string TipoProveedorId { get; set; }

        

        public string NombreRazonSocial { get; set; }

        public string TipoDocumentoId { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Direccion { get; set; }

        public string DepartamentoId { get; set; }

        public string ProvinciaId { get; set; }

        public string Provincia { get; set; }

        public string Departamento { get; set; }

        public int? ZonaId { get; set; }

        public string Zona { get; set; }

        public string PredioFinca { get; set; }

        public string DistritoId { get; set; }
        public string Distrito { get; set; }

        public int? SocioId { get; set; }

        public string CodigoSocio { get; set; }


        
    }
}
