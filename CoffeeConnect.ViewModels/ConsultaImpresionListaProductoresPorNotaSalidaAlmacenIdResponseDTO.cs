using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO
    {
        public string RazonSocialEmpresa
        { get; set; }

        public string RucEmpresa
        { get; set; }

        public string DireccionEmpresa
        { get; set; }

        public string NumeroNotaSalidaAlmacen
        { get; set; }
        public string UsuarioNotaSalidaAlmacen
        { get; set; }

        public DateTime FechaNotaSalidaAlmacen
        { get; set; }
        public string FechaNotaSalidaAlmacenString { get; set; }

        public string FechaImpresion
        { get; set; }

        public string Producto
        { get; set; }

        public string TipoProduccion
        { get; set; }

        public string Certificacion
        { get; set; }


        public List<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE> ListaProductores
        { get; set; }
    }
}
