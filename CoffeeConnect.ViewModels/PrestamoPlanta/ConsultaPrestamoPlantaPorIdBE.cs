using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaPrestamoPlantaPorIdBE
    {
        public ConsultaPrestamoPlantaPorIdBE()
        {
            
        }

        public int PrestamoPlantaId { get; set; }

        public int EmpresaId { get; set; }

        public string Numero { get; set; }

        public string FondoPrestamoId { get; set; }

        public string FondoPrestamo { get; set; }

        public string DetallePrestamo { get; set; }

        public decimal Saldo
        { get; set; }

        public decimal Importe
        { get; set; }

        public decimal ImporteProcesado
        { get; set; }


        public string MonedaId
        { get; set; }

        public string Moneda
        { get; set; }


        public string Observaciones { get; set; }

        public string EstadoId { get; set; }
        public string Estado { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }

        public string UsuarioUltimaActualizacion { get; set; }


    }
}
