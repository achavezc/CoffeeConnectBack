using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO
	{
		#region Properties
		public int EmpresaProveedoraAcreedoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string RazonSocial
		{ get; set; }

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string Ruc
		{ get; set; }

		/// <summary>
		/// Gets or sets the Direccion value.
		/// </summary>
		public string Direccion
		{ get; set; }

		/// <summary>
		/// Gets or sets the DepartamentoId value.
		/// </summary>
		public string DepartamentoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProvinciaId value.
		/// </summary>
		public string ProvinciaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DistritoId value.
		/// </summary>
		public string DistritoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ClasificacionId value.
		/// </summary>
		public string ClasificacionId
		{ get; set; }






		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
        { get; set; }



		public List<ActualizarEmpresaProveedoraAcreedoraCertificacionRequestDTO> Certificaciones { get; set; }


		#endregion
	}
}
