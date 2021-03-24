using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaImpresionLotePorIdBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the NotaCompraId value.
        /// </summary>
        public string Numero
        { get; set; }

        public string CodigoSocio
        { get; set; }

        public string AgenciaCertificadora
        { get; set; }

        public string Socio
        { get; set; }

        public string Zona
        { get; set; }

        public string Finca
        { get; set; }

        public decimal Cantidad
        { get; set; }

        public decimal TotalKilosBrutosPesado
        { get; set; }

        public decimal PromedioTotalAnalisisSensorial
        { get; set; }

        public decimal PromedioRendimientoPorcentaje
        { get; set; }

        public decimal PromedioHumedadPorcentaje
        { get; set; }

        public string TipoProduccion
        { get; set; }

        public string Certificacion
        { get; set; }


        #endregion
    }
}
