using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaDetalleTablaBE
    {
        public string Codigo { get; set; }
        public string CodigoTabla { get; set; }
        public string Label { get; set; }
        public string Descripcion { get; set; }
        public string Mnemonico { get; set; }
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public int IdCatalogoPadre { get; set; }
    }
}
