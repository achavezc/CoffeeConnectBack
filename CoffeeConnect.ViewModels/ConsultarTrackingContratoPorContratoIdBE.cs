using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultarTrackingContratoPorContratoIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the AduanaId value.
		/// </summary>
		public int AduanaId
		{ get; set; }

		public int ClienteId
		{ get; set; }


		public DateTime FechaContrato
		{ get; set; }




		public int EmpresaAgenciaAduaneraId
		{ get; set; }

		public string FloId
		{ get; set; }

		public string Courier
		{ get; set; }
		

		public string NumeroContrato
		{ get; set; }

		public string NumeroCliente
		{ get; set; }

		public string RazonSocialCliente
		{ get; set; }


		public string RucEmpresaAgenciaAduanera
		{ get; set; }

		public string RazonSocialEmpresaAgenciaAduanera
		{ get; set; }

		public string RucEmpresaExportadora
		{ get; set; }

		public string RazonSocialEmpresaExportadora
		{ get; set; }

		public string RucEmpresaProductora
		{ get; set; }

		public decimal TotalSacos
		{ get; set; }

		public decimal PesoPorSaco
		{ get; set; }

		public decimal PesoKilos
		{ get; set; }



		


		public string RazonSocialEmpresaProductora
		{ get; set; }

		public string EstadoContrato


		{ get; set; }

		public string EstadoAduana


		{ get; set; }



		public string Empaque
		{ get; set; }

		public string EmpaqueId
		{ get; set; }

		public string TipoEmpaque
		{ get; set; }

		public string TipoProduccionId
		{ get; set; }


		public string TipoProduccion
		{ get; set; }



		


		public string TipoId
		{ get; set; }



		public string Producto
		{ get; set; }

		public string ProductoId
		{ get; set; }


		public string SubProducto
		{ get; set; }

		public string SubProductoId
		{ get; set; }



		public string Calidad
		{ get; set; }


		public string CalidadId
		{ get; set; }

		public string GradoId
		{ get; set; }


		public string Grado
		{ get; set; }


		public string RazonSocial
		{ get; set; }

		public string Ruc
		{ get; set; }

		public string Logo
		{ get; set; }


		public string Direccion
		{ get; set; }


		/// <summary>
		/// Gets or sets the ContratoId value.
		/// </summary>
		public int ContratoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaExportadoraId value.
		/// </summary>
		public int EmpresaExportadoraId
		{ get; set; }

		public DateTime? FechaEmbarque
		{ get; set; }

		public DateTime? FechaFacturacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaProductoraId value.
		/// </summary>
		public int EmpresaProductoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string NumeroAduana
		{ get; set; }

		/// <summary>
		/// Gets or sets the Marca value.
		/// </summary>
		public string Marca
		{ get; set; }

		/// <summary>
		/// Gets or sets the PO value.
		/// </summary>
		public string PO
		{ get; set; }

	
		/// <summary>
		/// Gets or sets the FechaEnvioMuestra value.
		/// </summary>
		public DateTime? FechaEnvioMuestra
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroSeguimientoMuestra value.
		/// </summary>
		public string NumeroSeguimientoMuestra
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoMuestraId value.
		/// </summary>
		public string EstadoMuestraId
		{ get; set; }

		public string EstadoMuestra
		{ get; set; }

		public string EstadoSeguimiento
		{ get; set; }

		public string EstadoSeguimientoId
		{ get; set; }

		public string Observacion
		{ get; set; }

		public string UsuarioRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRecepcionMuestra value.
		/// </summary>
		public DateTime? FechaRecepcionMuestra
		{ get; set; }


		public DateTime? FechaEnvioDocumentos
		{ get; set; }

		public DateTime? FechaLlegadaDocumentos
		{ get; set; }




		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>


		/// <summary>
		/// Gets or sets the NombreArchivo value.
		/// </summary>


		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
	
		/// <summary>
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string UsuarioUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }


		public List<ConsultaAduanaCertificacionPorIdBE> Certificaciones
		{ get; set; }

		public IEnumerable<AduanaDetalle> Detalle { get; set; }
		public List<ConsultaAduanaCargamentoPorIdBE> Cargamentos
		{ get; set; }

		#endregion
	}
}
