using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaDevolucionPrestamoPlantaBE
    {
        public ConsultaDevolucionPrestamoPlantaBE()
        {
            
        }

        public int DevolucionPrestamoPlantaId { get; set; }

        public int PrestamoPlantaId { get; set; }
        public int EmpresaId { get; set; }

        public string Numero { get; set; }

        public string DestinoDevolucionId { get; set; }

        public string DestinoDevolucion { get; set; }

        public string BancoId { get; set; }

        public string Banco { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public string MonedaId { get; set; }

        public string Moneda { get; set; }




        public decimal Importe
        { get; set; }

        public decimal? ImporteCambio
        { get; set; }

        

        public string Observaciones
        { get; set; }

        public string ObservacionAnulacion { get; set; }

        public string EstadoId
        { get; set; }
          
 
        public string Estado { get; set; }
       
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }       

        public string UsuarioUltimaActualizacion { get; set; }


    }
}
