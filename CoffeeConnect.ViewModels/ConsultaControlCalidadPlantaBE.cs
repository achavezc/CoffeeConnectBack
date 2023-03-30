using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaControlCalidadPlantaBE
    {
        public int NotaIngresoPlantaId { get; set; }

        public int ControlCalidadPlantaId { get; set; }

        public string NumeroCalidadPlanta { get; set; }

        public string Numero { get; set; }

        public string NumeroGuiaRemision { get; set; }

        public int EmpresaOrigenId { get; set; }

        public string TieneDefectosGrave { get; set; }
        


       
        public string TipoProduccionId { get; set; }
        public string TipoProduccion { get; set; }


        public string Producto { get; set; }

        public string ProductoId
        { get; set; }
        public string SubProducto { get; set; }



        public string SubProductoId { get; set; }


        public string CertificacionId { get; set; }
        public string Certificacion { get; set; }
        public string EntidadCertificadoraId { get; set; }
        public string EntidadCertificadora { get; set; }

        public string MotivoIngresoId { get; set; }
        public string MotivoIngreso { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public string EstadoCalidadId { get; set; }
        public string EstadoCalidad { get; set; }

        public decimal KilosBrutos
        { get; set; }

        public decimal KilosNetos
        { get; set; }

        public decimal Cantidad
        { get; set; }

        public decimal RendimientoPorcentaje
        { get; set; }

        public decimal HumedadPorcentaje
        { get; set; }

        public decimal PuntajeFinal
        { get; set; }
        public decimal Tara
        { get; set; }

        //////campos nuevos a la tabla y grilla ///

        public decimal CantidadProcesada
        { get; set; }
        public decimal KilosNetosProcesado
        { get; set; }
        public decimal CantidadRechazada
        { get; set; }
        public decimal KilosNetosRechazados
        { get; set; }
        public decimal CantidadDisponible
        { get; set; }
        public decimal KilosNetosDisponibles
        { get; set; }

        ///campos nuevos en grilla  ///(/>

        public decimal CantidadControlCalidad {get;set;}
        public decimal PesoBrutoControlCalidad { get; set; }
        public decimal TaraControlCalidad { get; set; }
        public decimal KilosNetosControlCalidad { get; set; }


        ///campos nuevos ((/
        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaGuiaRemision { get; set; }

        public string UsuarioRegistro { get; set; }



        public string CodigoCampania { get; set; }

        public string CodigoTipoConcepto { get; set; }
        public string DescripcionConcepto
        {
            get; set;
        }
    }
}
