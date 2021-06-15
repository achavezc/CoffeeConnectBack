using System;

namespace CoffeeConnect.DTO
{
    public class ConsultarSocioProductorPorSocioFincaId
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
        public DateTime? FechaNacimiento { get; set; }
        public String LugarNacimiento { get; set; }
        public String EstadoCivilId { get; set; }
        public string EstadoCivil { get; set; }
        public String ReligionId { get; set; }
        public string Religion { get; set; }
        public String GeneroId { get; set; }
        public string Genero { get; set; }
        public int CantidadHijos { get; set; }
        public String Idiomas { get; set; }
        public String Dialecto { get; set; }
        public int? AnioIngresoZona { get; set; }
        public String TipoDocumentoIdConyuge { get; set; }
        public String NumeroDocumentoConyuge { get; set; }
        public String NombresConyuge { get; set; }
        public String ApellidosConyuge { get; set; }
        public String NumeroTelefonoCelularConyuge { get; set; }
        public DateTime? FechaNacimientoConyuge { get; set; }
        public String LugarNacimientoConyuge { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public String UsuarioUltimaActualizacion { get; set; }
        public String EstadoId { get; set; }
        public bool Activo { get; set; }
        public String GradoEstudiosIdConyuge { get; set; }
        public string GradoEstudiosConyuge { get; set; }
        public String GradoEstudiosId { get; set; }
        public string GradoEstudios { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Zona { get; set; }
        public string NombreFinca
        { get; set; }



        /// <summary>
        /// Gets or sets the SubProducto value.
        /// </summary>
        public decimal? Latitud
        { get; set; }

        public decimal? Longuitud
        { get; set; }

        public decimal? LatitudDms
        { get; set; }

        public decimal? LonguitudDms
        { get; set; }

        public decimal? Altitud
        { get; set; }

        public string FuenteEnergiaId
        { get; set; }
        public string FuenteEnergia { get; set; }

        public string FuenteAguaId
        { get; set; }
        public string FuenteAgua { get; set; }

        public string InternetId
        { get; set; }

        public string SenialTelefonicaId
        { get; set; }

        public string EstablecimientoSaludId
        { get; set; }

        public string CentroEducativoId
        { get; set; }

        public string CentroEducativoNivel
        { get; set; }

        public decimal? TiempoTotalEstablecimientoSalud
        { get; set; }


        public int? CantidadAnimalesMenores
        { get; set; }

        public string MaterialVivienda
        { get; set; }

        public string Suelo
        { get; set; }
    }
}
