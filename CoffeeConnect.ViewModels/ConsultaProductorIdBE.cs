using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaProductorIdBE
	{

		public int ProductorId { get; set; }
		public String Numero { get; set; }
		public String NombreRazonSocial { get; set; }
		public String TipoDocumentoId { get; set; }
		public String NumeroDocumento { get; set; }
		public String RazonSocial { get; set; }
		public String Nombres { get; set; }
		public String Apellidos { get; set; }
		public String Direccion { get; set; }
		public String DepartamentoId { get; set; }
		public String ProvinciaId { get; set; }
		public String DistritoId { get; set; }
		public int ZonaId { get; set; }
		public String NumeroTelefonoFijo { get; set; }
		public String NumeroTelefonoCelular { get; set; }
		public String CorreoElectronico { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public String LugarNacimiento { get; set; }
		public String EstadoCivilId { get; set; }
		public String ReligionId { get; set; }
		public String GeneroId { get; set; }
		public int CantidadHijos { get; set; }
		public String Idiomas { get; set; }
		public String Dialecto { get; set; }
		public int AnioIngresoZona { get; set; }
		public String TipoDocumentoIdConyuge { get; set; }
		public String NumeroDocumentoConyuge { get; set; }
		public String NombresConyuge { get; set; }
		public String ApellidosConyuge { get; set; }
		public String NumeroTelefonoCelularConyuge { get; set; }
		public DateTime FechaNacimientoConyuge { get; set; }
		public String LugarNacimientoConyuge { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		public String EstadoId { get; set; }
		public bool Activo { get; set; }
		public String GradoEstudiosIdConyuge { get; set; }
		public String GradoEstudiosId { get; set; }
	}
}
