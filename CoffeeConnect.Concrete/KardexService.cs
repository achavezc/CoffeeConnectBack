using ClosedXML.Excel;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models.Kardex;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public class KardexService : IKardexService
    {
        private IKardexProcesoRepository _IKardexProcesoRepository;
        public KardexService(IKardexProcesoRepository kardexProcesoRepository)
        {
            _IKardexProcesoRepository = kardexProcesoRepository;

        }
        public ExportarKardexResponseDTO ExportarKardex(KardexPergaminoIngresoConsultaRequest request)
        {
            ExportarKardexResponseDTO respose = new ExportarKardexResponseDTO();
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet ws = workbook.Worksheets.Add("Kardex");
                    ws.Style.Fill.BackgroundColor = XLColor.White;
                    ws.Range("A1:BA90").Style.Fill.BackgroundColor = XLColor.White;
                    ws.Column("A").Width = 1.71;
                    ws.Column("B").Width = 11.29;

                    //ws.Cell(2, 2).Value = "Kardex:";
                    //ws.Cell(2, 2).Style.Font.Bold = true;
                    //ws.Cell(3, 2).Value = "Producto:";
                    //ws.Cell(3, 2).Style.Font.Bold = true;
                    //ws.Cell(4, 2).Value = "Sub Producto:";
                    //ws.Cell(4, 2).Style.Font.Bold = true;
                    ws.Cell(3, 2).Value = "Fecha Inicio:";
                    ws.Cell(3, 2).Style.Font.Bold = true;
                    ws.Cell(4, 2).Value = "Fecha Fin:";
                    ws.Cell(4, 2).Style.Font.Bold = true;

                    ws.Cell(1, 7).Value = "KARDEX PERGAMINO";
                    ws.Cell(1, 7).Style.Font.Bold = true;
                    //PRIMERA TABLA
                    /*
                    ws.Cell(2, 8).Value = "Sacos";
                    ws.Cell(2, 8).Style.Font.Bold = true;
                    ws.Cell(2, 8).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(2, 8).Style.Alignment.WrapText = true;
                    ws.Cell(2, 9).Value = "Kgs Netos a pagar";
                    ws.Cell(2, 9).Style.Font.Bold = true;
                    ws.Cell(2, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(2, 10).Value = "Moneda";
                    ws.Cell(2, 10).Style.Font.Bold = true;
                    ws.Cell(2, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(2, 11).Value = "Importe";
                    ws.Cell(2, 11).Style.Font.Bold = true;
                    ws.Cell(2, 11).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(3, 7).Value = "Inventario Actual:";
                    ws.Cell(3, 7).Style.Font.Bold = true;
                    ws.Cell(3, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(3, 7).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Range("H2:K2").Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Range("H2:K2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("H2:K2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    */

                    ws.Cell(8, 2).Value = "INGRESOS";
                    ws.Cell(8, 2).Style.Font.Bold = true;
                    ws.Cell(8, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(8, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    IXLRange rangeIngresos = ws.Range(ws.Cell(8, 2), ws.Cell(8, 19));
                    rangeIngresos.Merge();
                    rangeIngresos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rangeIngresos.Style.Fill.BackgroundColor = XLColor.FromHtml("#479d9c");//XLColor.YellowProcess;

                    ws.Cell(8, 20).Value = "SALIDAS";
                    ws.Cell(8, 20).Style.Font.Bold = true;
                    ws.Cell(8, 20).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(8, 20).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    IXLRange rangeSalidas = ws.Range(ws.Cell(8, 20), ws.Cell(8, 30));
                    rangeSalidas.Merge();
                    rangeSalidas.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rangeSalidas.Style.Fill.BackgroundColor = XLColor.FromHtml("#479d9c");

                    //INGRESOS
                    ws.Cell(9, 2).Value = "Fecha Registro";
                    ws.Cell(9, 3).Value = "Nro. Guia de Recepcion";
                    ws.Cell(9, 4).Value = "Observaciones";
                    ws.Cell(9, 5).Value = "Nombre/Razon Social";
                    ws.Cell(9, 6).Value = "Nro. Documento";
                    ws.Cell(9, 7).Value = "Zona";
                    ws.Cell(9, 8).Value = "Producto";
                    ws.Cell(9, 9).Value = "Cantidad";
                    ws.Cell(9, 10).Value = "Kilos Brutos";
                    ws.Cell(9, 11).Value = "Tara";
                    ws.Cell(9, 12).Value = "Kilos Netos a Descontar";
                    ws.Cell(9, 13).Value = "Kilos Netos a Pagar";
                    ws.Cell(9, 14).Value = "Precio del Día";
                    ws.Cell(9, 15).Value = "Importe";
                    ws.Cell(9, 16).Value = "% Humedad";
                    ws.Cell(9, 17).Value = "% Rendimiento (Exportable)";
                    ws.Cell(9, 18).Value = "Calculo (kilos Netos a Pagar x % Humedad)";
                    ws.Cell(9, 19).Value = "Calculo (kilos Netos a Pagar x % Rendimiento (Exportable))";


                    //SALIDAS
                    ws.Cell(9, 20).Value = "Nro. Guia de Remisión Electronia";
                    ws.Cell(9, 21).Value = "Fecha Guia de Remisión Electronia";
                    ws.Cell(9, 22).Value = "Calculo (Kilos Netos * % Humedad)";
                    ws.Cell(9, 23).Value = "Calculo (Kilos Netos * % Rendimiento)";
                    ws.Cell(9, 24).Value = "Cantidad";
                    ws.Cell(9, 25).Value = "Kilos Brutos";
                    ws.Cell(9, 26).Value = "Tara";
                    ws.Cell(9, 27).Value = "Kilos Netos";
                    ws.Cell(9, 28).Value = "% Humedad";
                    ws.Cell(9, 29).Value = "% Rendimiento";
                    ws.Cell(9, 30).Value = "Saldo";

                    for (int i = 2; i <= 19; i++)
                    {
                        ws.Cell(9, i).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#479d9c"));
                        ws.Cell(9, i).Style.Font.Bold = true;
                        ws.Cell(9, i).Style.Alignment.WrapText = true;
                        ws.Cell(9, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(9, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(9, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }

                    for (int i = 20; i <= 30; i++)
                    {
                        ws.Cell(9, i).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#479d9c"));
                        ws.Cell(9, i).Style.Font.Bold = true;
                        ws.Cell(9, i).Style.Alignment.WrapText = true;
                        ws.Cell(9, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(9, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(9, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }

                    //INICIO: DATA HARDCODE
            
                    //ws.Cell(2, 3).Value = "Almacén 01";
                   // ws.Cell(3, 3).Value = "Café Pergamino";
                   // ws.Cell(4, 3).Value = "Seco";
                    ws.Cell(3, 3).Value = request.FechaInicio.ToShortDateString();
                    ws.Cell(4, 3).Value = request.FechaFin.ToShortDateString() ;
                    ws.Range("D2:D6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("D2:D6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    /*
                    ws.Cell(3, 8).Value = 24;
                    ws.Cell(3, 8).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(3, 9).Value = 1286.20;
                    ws.Cell(3, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(3, 10).Value = "Soles";
                    ws.Cell(3, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Cell(3, 11).Value = 9727.03;
                    ws.Cell(3, 11).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    
                    ws.Cell("G10").Value = "SALDO ANTERIOR";
                    ws.Cell("G10").Style.Font.Bold = true;
                    ws.Cell("G10").Style.Font.FontColor = XLColor.Red;

                    ws.Cell("R10").Value = "Saco";
                    ws.Cell("S10").Value = 20;
                    ws.Cell("V10").Value = 1096;
                    ws.Cell("X10").Value = 48.5;
                    ws.Cell("Y10").Value = 1047.5;
                    ws.Cell("Z10").Value = "Soles";
                    ws.Cell("AB10").Value = 7891.20;

                    ws.Range("B10:AH10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("AI10:AZ10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    */
                    /*
                    KardexPergaminoIngresoConsultaRequest requestIngreso = new KardexPergaminoIngresoConsultaRequest();
                    requestIngreso.EmpresaId = 1;
                    requestIngreso.FechaInicio = Convert.ToDateTime("2018-07-19T00:00:00");
                    requestIngreso.FechaFin = Convert.ToDateTime("2024-07-19T00:00:00");
                    */
                    var list = _IKardexProcesoRepository.KardexPergaminoIngresoConsulta(request);
                    List<KardexPergaminoIngresoConsultaResponse> listaIngreso =  list.ToList();
                   
                    decimal sumaKilosBrutos = 0;
                    decimal sumaKilosNetos = 0;
                    decimal sumaImporte = 0;
                    decimal sumaRemdimiento = 0;
                    for (int i = 1; i <= listaIngreso.Count; i++  )
                    {
                        ws.Cell(9 + i, 2).Value = listaIngreso[i - 1].FechaRegistro.ToShortDateString();
                        ws.Cell(9 + i, 3).Value = listaIngreso[i-1].Numero;
                        ws.Cell(9 + i, 4).Value = listaIngreso[i-1].ObservacionPesado;
                        ws.Cell(9 + i, 5).Value = listaIngreso[i - 1].NombreRazonSocial;
                        ws.Cell(9 + i, 6).Value = listaIngreso[i -1].NumeroDocumento;
                        ws.Cell(9 + i, 7).Value = listaIngreso[i-1].Zona;
                        ws.Cell(9 + i, 8).Value = listaIngreso[i-1].Producto;
                        ws.Cell(9 + i, 9).Value = listaIngreso[i-1].CantidadPesado;
                        ws.Cell(9 + i, 10).Value = listaIngreso[i-1].KilosBrutosPesado; 
                        ws.Cell(9 + i, 11).Value = listaIngreso[i-1].TaraPesado;
                        ws.Cell(9 + i, 12).Value = listaIngreso[i-1].KilosNetosDescontar;
                        ws.Cell(9 + i, 13).Value = listaIngreso[i-1].KilosNetosPagar;
                        ws.Cell(9 + i, 14).Value = listaIngreso[i-1].PrecioPagado;
                        ws.Cell(9 + i, 15).Value = listaIngreso[i-1].Importe;
                        ws.Cell(9 + i, 16).Value = listaIngreso[i-1].HumedadPorcentajeAnalisisFisico;
                        ws.Cell(9 + i, 17).Value = listaIngreso[i-1].ExportablePorcentajeAnalisisFisico;
                        ws.Cell(9 + i, 18).Value = listaIngreso[i-1].CalculoKilosNetosPagarPorHumedad;
                        ws.Cell(9 + i, 19).Value = listaIngreso[i-1].CalculoKilosNetosPagarPorRendimiento;
                        sumaKilosBrutos = sumaKilosBrutos + listaIngreso[i - 1].KilosBrutosPesado;
                        sumaKilosNetos = sumaKilosNetos + listaIngreso[i - 1].KilosNetosPagar;
                        sumaImporte = sumaImporte + listaIngreso[i - 1].Importe;
                        sumaRemdimiento = sumaRemdimiento + listaIngreso[i - 1].ExportablePorcentajeAnalisisFisico;
                    }
                    ws.Cell(9 + listaIngreso.Count + 1, 10).Value = sumaKilosBrutos;
                    ws.Cell(9 + listaIngreso.Count + 1, 10).Style.Font.Bold = true;

                    ws.Cell(9 + listaIngreso.Count + 1, 13).Value = sumaKilosNetos;
                    ws.Cell(9 + listaIngreso.Count + 1, 13).Style.Font.Bold = true;

                    ws.Cell(9 + listaIngreso.Count + 1, 15).Value = sumaImporte;
                    ws.Cell(9 + listaIngreso.Count + 1, 15).Style.Font.Bold = true;

                    ws.Cell(9 + listaIngreso.Count + 1, 17).Value = sumaRemdimiento / listaIngreso.Count;
                    ws.Cell(9 + listaIngreso.Count + 1, 17).Style.Font.Bold = true;

                    KardexPergaminoSalidaConsultaRequest requestSalida = new KardexPergaminoSalidaConsultaRequest();
                    requestSalida.EmpresaId = request.EmpresaId;
                    requestSalida.FechaInicio = request.FechaInicio;
                    requestSalida.FechaFin = request.FechaFin;
                    var listSalida = _IKardexProcesoRepository.KardexPergaminoSalidadConsulta(requestSalida);
                    List<KardexPergaminoSalidaConsultaResponse> listaSalida = listSalida.ToList();

                    decimal sumaKilosBrutosSalida = 0;
                    decimal sumaTaraSalida = 0;
                    decimal sumaKilosNetosSalida = 0;
                    for (int i = 1; i <= listaSalida.Count; i++)
                    {
                        ws.Cell(9 + i, 20).Value = listaSalida[i - 1].NumeroGuiaRemision;
                        ws.Cell(9 + i, 21).Value = listaSalida[i - 1].FechaGuiaRemision.ToShortDateString();
                        ws.Cell(9 + i, 22).Value = listaSalida[i - 1].CalculoKilosNetosPagarPorHumedad;
                        ws.Cell(9 + i, 23).Value = listaSalida[i - 1].CalculoKilosNetosPagarPorRendimiento;
                        ws.Cell(9 + i, 24).Value = listaSalida[i - 1].Cantidad;
                        ws.Cell(9 + i, 25).Value = listaSalida[i - 1].TotalKilosBrutosPesado;
                        ws.Cell(9 + i, 26).Value = listaSalida[i - 1].Tara;
                        ws.Cell(9 + i, 27).Value = listaSalida[i - 1].TotalKilosNetosPesado;
                        ws.Cell(9 + i, 28).Value = listaSalida[i - 1].HumedadPorcentajeAnalisisFisico;
                        ws.Cell(9 + i, 29).Value = listaSalida[i - 1].RendimientoPorcentaje;
                        sumaKilosBrutosSalida = sumaKilosBrutosSalida + listaSalida[i - 1].TotalKilosBrutosPesado;
                        sumaTaraSalida = sumaTaraSalida + listaSalida[i - 1].Tara;
                        sumaKilosNetosSalida = sumaKilosNetosSalida + listaSalida[i - 1].TotalKilosNetosPesado;
                    }

                    ws.Cell(9 + listaIngreso.Count + 1, 25).Value = sumaKilosBrutosSalida;
                    ws.Cell(9 + listaIngreso.Count + 1, 25).Style.Font.Bold = true;

                    ws.Cell(9 + listaIngreso.Count + 1, 26).Value = sumaTaraSalida;
                    ws.Cell(9 + listaIngreso.Count + 1, 26).Style.Font.Bold = true;

                    ws.Cell(9 + listaIngreso.Count + 1, 27).Value = sumaKilosNetosSalida;
                    ws.Cell(9 + listaIngreso.Count + 1, 27).Style.Font.Bold = true;

                    ws.Cell(9 + listaIngreso.Count + 1, 30).Value = sumaKilosNetos - sumaKilosNetosSalida;
                    ws.Cell(9 + listaIngreso.Count + 1, 30).Style.Font.Bold = true;

                    int g = 0;

                    for (int i = 0; i <= listaIngreso.Count -1; i++)
                    {
                        g = 10 + i;
                        for (int y = 2; y <= 30; y++)
                        {
                            ws.Cell(g, y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        }
                    }
                    /*
                    ws.Cell("R15").Value = 70;
                    ws.Cell("V15").Value = 4249.5;
                    ws.Cell("Y15").Value = 4111.32;
                    ws.Cell("Z15").Value = "Soles";
                    ws.Cell("AB15").Value = 31099.83;
                    ws.Cell("AO15").Value = 46;
                    ws.Cell("AR15").Value = 2963.30;
                    ws.Cell("AU15").Value = 2901.04;
                    ws.Cell("AX15").Value = 21372.80;

                    ws.Range("B15:AH15").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("B15:AH15").Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Range("AI15:AZ15").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("AI15:AZ15").Style.Fill.BackgroundColor = XLColor.LightGray;
                    */
                    //FIN: DATA HARDCODE

                    ws.ColumnsUsed().AdjustToContents();
                    ws.RowsUsed().AdjustToContents();

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        respose.content = stream.ToArray();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return respose;
        }
    }
}
