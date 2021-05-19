using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class OrdenProcesoDTO
    {
        public OrdenProcesoDTO()
        {

        }

        public int OrdenProcesoId { get; set; }
        public int EmpresaId { get; set; }
        public int EmpresaProcesadoraId { get; set; }
        public string EmpresaDestinoRazonSocial { get; set; }
        public string EmpresaDestinoDireccion { get; set; }
        public string TipoProcesoId { get; set; }
        public string TipoProceso { get; set; }
        public string TipoProduccionId { get; set; }
        public string TipoProduccion { get; set; }
        public int ContratoId { get; set; }
        public string TipoCertificacionId { get; set; }
        public string Certificacion { get; set; }
        public string EntidadCertificadoraId { get; set; }
        public string EntidadCertificadora { get; set; }
        public string EmpaqueId { get; set; }
        public string Empaque { get; set; }
        public string TipoId { get; set; }
        public string TipoEmpaque { get; set; }
        public string ProductoId { get; set; }
        public string Producto { get; set; }
        public string SubProductoId { get; set; }
        public string SubProducto { get; set; }
        public string CalidadId { get; set; }
        public string Calidad { get; set; }
        public string GradoId { get; set; }
        public string Grado { get; set; }
        public string ClienteId { get; set; }
        public string NumeroCliente { get; set; }
        public string RazonSocialCliente { get; set; }
        public string Numero { get; set; }
        public string Observacion { get; set; }
        public decimal RendimientoEsperadoPorcentaje { get; set; }
        public decimal PesoPorSaco { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal PesoKilos { get; set; }
        public decimal PreparacionCantidadDefectos { get; set; }
        public DateTime FechaFinProceso { get; set; }
        public decimal CantidadContenedores { get; set; }
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public string PathArchivo { get; set; }
        public string EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public int Activo { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }
}
