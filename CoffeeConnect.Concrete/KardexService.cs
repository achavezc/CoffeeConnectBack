using ClosedXML.Excel;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffeeConnect.Service
{
    public class KardexService : IKardexService
    {
        public ExportarKardexResponseDTO ExportarKardex()
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

                    ws.Cell(2, 2).Value = "Kardex:";
                    ws.Cell(2, 2).Style.Font.Bold = true;
                    ws.Cell(3, 2).Value = "Producto:";
                    ws.Cell(3, 2).Style.Font.Bold = true;
                    ws.Cell(4, 2).Value = "Sub Producto:";
                    ws.Cell(4, 2).Style.Font.Bold = true;
                    ws.Cell(5, 2).Value = "Fecha Inicio:";
                    ws.Cell(5, 2).Style.Font.Bold = true;
                    ws.Cell(6, 2).Value = "Fecha Fin:";
                    ws.Cell(6, 2).Style.Font.Bold = true;
                    //PRIMERA TABLA
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

                    ws.Cell(8, 2).Value = "INGRESOS";
                    ws.Cell(8, 2).Style.Font.Bold = true;
                    ws.Cell(8, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(8, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    IXLRange rangeIngresos = ws.Range(ws.Cell(8, 2), ws.Cell(8, 34));
                    rangeIngresos.Merge();
                    rangeIngresos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rangeIngresos.Style.Fill.BackgroundColor = XLColor.YellowProcess;

                    ws.Cell(8, 35).Value = "SALIDAS";
                    ws.Cell(8, 35).Style.Font.Bold = true;
                    ws.Cell(8, 35).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(8, 35).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    IXLRange rangeSalidas = ws.Range(ws.Cell(8, 35), ws.Cell(8, 52));
                    rangeSalidas.Merge();
                    rangeSalidas.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rangeSalidas.Style.Fill.BackgroundColor = XLColor.LightBlue;

                    //INGRESOS
                    ws.Cell(9, 2).Value = "Fecha Recepcion";
                    ws.Cell(9, 3).Value = "Nro. Guia de Recepcion";
                    ws.Cell(9, 4).Value = "Fecha Nota de Compra";
                    ws.Cell(9, 5).Value = "N° Nota de Compra";
                    ws.Cell(9, 6).Value = "Fecha Ingreso Almacen";
                    ws.Cell(9, 7).Value = "Nro. Nota Ingreso";
                    ws.Cell(9, 8).Value = "Producto";
                    ws.Cell(9, 9).Value = "Sub Producto";
                    ws.Cell(9, 10).Value = "Tipo Proveedor";
                    ws.Cell(9, 11).Value = "Nombre/Razon Social";
                    ws.Cell(9, 12).Value = "Tipo Documento";
                    ws.Cell(9, 13).Value = "Nro. Documento";
                    ws.Cell(9, 14).Value = "Departamento";
                    ws.Cell(9, 15).Value = "Provincia";
                    ws.Cell(9, 16).Value = "Distrito";
                    ws.Cell(9, 17).Value = "Zona";
                    ws.Cell(9, 18).Value = "Unidad Medida";
                    ws.Cell(9, 19).Value = "Cantidad";
                    ws.Cell(9, 20).Value = "Kilos Brutos";
                    ws.Cell(9, 21).Value = "Tara";
                    ws.Cell(9, 22).Value = "Kilos Netos";
                    ws.Cell(9, 23).Value = "Dscto por humedad";
                    ws.Cell(9, 24).Value = "Kg netos a descontar";
                    ws.Cell(9, 25).Value = "Kg neto a pagar";
                    ws.Cell(9, 26).Value = "Moneda";
                    ws.Cell(9, 27).Value = "Precio pagado";
                    ws.Cell(9, 28).Value = "Importe";
                    ws.Cell(9, 29).Value = "% Humedad";
                    ws.Cell(9, 30).Value = "% Rendimiento";
                    ws.Cell(9, 31).Value = "Analisis Sensorial";
                    ws.Cell(9, 32).Value = "P.H.";
                    ws.Cell(9, 33).Value = "P.R.";
                    ws.Cell(9, 34).Value = "Nro. Nota de Salida";
                    //SALIDAS
                    ws.Cell(9, 35).Value = "Fecha Nota de Salida";
                    ws.Cell(9, 36).Value = "N° Nota de Salida";
                    ws.Cell(9, 37).Value = "Motivo";
                    ws.Cell(9, 38).Value = "Producto";
                    ws.Cell(9, 39).Value = "Sub Producto";
                    ws.Cell(9, 40).Value = "Unidad Medida";
                    ws.Cell(9, 41).Value = "Cantidad";
                    ws.Cell(9, 42).Value = "Kilos Brutos";
                    ws.Cell(9, 43).Value = "Tara";
                    ws.Cell(9, 44).Value = "Kilos Netos";
                    ws.Cell(9, 45).Value = "Dscto por humedad";
                    ws.Cell(9, 46).Value = "Kg netos a descontar";
                    ws.Cell(9, 47).Value = "Kg neto a pagar";
                    ws.Cell(9, 48).Value = "Moneda";
                    ws.Cell(9, 49).Value = "Precio";
                    ws.Cell(9, 50).Value = "Importe";
                    ws.Cell(9, 51).Value = "% Humedad";
                    ws.Cell(9, 52).Value = "% Rendimiento";

                    for (int i = 2; i <= 34; i++)
                    {
                        ws.Cell(9, i).Style.Fill.SetBackgroundColor(XLColor.OrangeColorWheel);
                        ws.Cell(9, i).Style.Font.Bold = true;
                        ws.Cell(9, i).Style.Alignment.WrapText = true;
                        ws.Cell(9, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(9, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(9, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }

                    for (int i = 35; i <= 52; i++)
                    {
                        ws.Cell(9, i).Style.Fill.SetBackgroundColor(XLColor.LightSteelBlue);
                        ws.Cell(9, i).Style.Font.Bold = true;
                        ws.Cell(9, i).Style.Alignment.WrapText = true;
                        ws.Cell(9, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(9, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(9, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }

                    //INICIO: DATA HARDCODE
                    ws.Cell(2, 3).Value = "Almacén 01";
                    ws.Cell(3, 3).Value = "Café Pergamino";
                    ws.Cell(4, 3).Value = "Seco";
                    ws.Cell(5, 3).Value = "01/12/2020";
                    ws.Cell(6, 3).Value = "31/12/2020";
                    ws.Range("D2:D6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("D2:D6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

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

                    for (int i = 0; i <= 3; i++)
                    {
                        ws.Cell(11 + i, 2).Value = "01/12/2020";
                        ws.Cell(11 + i, 3).Value = "000000100";
                        ws.Cell(11 + i, 4).Value = "02/12/2020";
                        ws.Cell(11 + i, 5).Value = "000000400";
                        ws.Cell(11 + i, 6).Value = "01/12/2020";
                        ws.Cell(11 + i, 7).Value = "000000840";
                        ws.Cell(11 + i, 8).Value = "Café Pergamino";
                        ws.Cell(11 + i, 9).Value = "Seco";
                        ws.Cell(11 + i, 10).Value = "Socio";
                        ws.Cell(11 + i, 11).Value = "PEÑA ALANIA, ELIZABETH";
                        ws.Cell(11 + i, 12).Value = "DNI";
                        ws.Cell(11 + i, 13).Value = "07253907";
                        ws.Cell(11 + i, 14).Value = "JUNÍN";
                        ws.Cell(11 + i, 15).Value = "CHANCHAMAYO";
                        ws.Cell(11 + i, 16).Value = "PICHANAQUI";
                        ws.Cell(11 + i, 17).Value = "VISTA ALEGRE SHINGANARI";
                        ws.Cell(11 + i, 18).Value = "Saco";
                        ws.Cell(11 + i, 19).Value = 8;
                        ws.Cell(11 + i, 20).Value = 471;
                        ws.Cell(11 + i, 21).Value = 1.60;
                        ws.Cell(11 + i, 22).Value = 469.40;
                        ws.Cell(11 + i, 23).Value = "2.50%";
                        ws.Cell(11 + i, 24).Value = 11.74;
                        ws.Cell(11 + i, 25).Value = 457.67;
                        ws.Cell(11 + i, 26).Value = "Soles";
                        ws.Cell(11 + i, 27).Value = 7.2;
                        ws.Cell(11 + i, 28).Value = 3379.68;
                        ws.Cell(11 + i, 29).Value = "13%";
                        ws.Cell(11 + i, 30).Value = "75%";
                        ws.Cell(11 + i, 31).Value = "77.25%";
                        ws.Cell(11 + i, 32).Value = "61.02%";
                        ws.Cell(11 + i, 33).Value = 352.05;
                        ws.Cell(11 + i, 34).Value = "000000555";
                        ws.Cell(11 + i, 35).Value = "02/12/2020";
                        ws.Cell(11 + i, 36).Value = "000000555";
                        ws.Cell(11 + i, 37).Value = "Transformación";
                        ws.Cell(11 + i, 38).Value = "Café Pergamino";
                        ws.Cell(11 + i, 39).Value = "Seco";
                        ws.Cell(11 + i, 40).Value = "Saco";
                        ws.Cell(11 + i, 41).Value = 8;
                        ws.Cell(11 + i, 42).Value = 485;
                        ws.Cell(11 + i, 43).Value = 1.6;
                        ws.Cell(11 + i, 44).Value = 483.40;
                        ws.Cell(11 + i, 45).Value = "1.85%";
                        ws.Cell(11 + i, 46).Value = 8.94;
                        ws.Cell(11 + i, 47).Value = 474.46;
                        ws.Cell(11 + i, 48).Value = "Soles";
                        ws.Cell(11 + i, 49).Value = 7.2;
                        ws.Cell(11 + i, 50).Value = 3416.09;
                        ws.Cell(11 + i, 51).Value = "13%";
                        ws.Cell(11 + i, 52).Value = "75%";
                    }

                    int g = 0;

                    for (int i = 0; i <= 3; i++)
                    {
                        g = 11 + i;
                        for (int y = 2; y <= 52; y++)
                        {
                            ws.Cell(g, y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        }
                    }

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
