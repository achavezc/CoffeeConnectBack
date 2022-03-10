using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Anticipo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IAnticipoService
    {
        List<ConsultaAnticipoBE> ConsultarAnticipo(ConsultaAnticipoRequestDTO request);
        GenerarPDFAnticipoResponseDTO GenerarPDF(int id);

        int RegistrarAnticipo(RegistrarActualizarAnticipoRequestDTO request);
        int ActualizarAnticipo(RegistrarActualizarAnticipoRequestDTO request);
        ConsultaAnticipoPorIdBE ConsultarAnticipoPorId(ConsultaAnticipoPorIdRequestDTO request);


        int AnularAnticipo(AnularAnticipoRequestDTO request);

        int AsociarAnticipo(AsociarAnticipoRequestDTO request);


    }
}
