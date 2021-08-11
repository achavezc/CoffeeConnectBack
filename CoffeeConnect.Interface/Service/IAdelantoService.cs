using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IAdelantoService
    {
        List<ConsultaAdelantoBE> ConsultarAdelanto(ConsultaAdelantoRequestDTO request);
        GenerarPDFAdelantoResponseDTO GenerarPDF(int id);

        int RegistrarAdelanto(RegistrarActualizarAdelantoRequestDTO request);
        int ActualizarAdelanto(RegistrarActualizarAdelantoRequestDTO request);
        ConsultaAdelantoPorIdBE ConsultarAdelantoPorId(ConsultaAdelantoPorIdRequestDTO request);


        int AnularAdelanto(AnularAdelantoRequestDTO request);

        int AsociarAdelanto(AsociarAdelantoRequestDTO request);


    }
}
