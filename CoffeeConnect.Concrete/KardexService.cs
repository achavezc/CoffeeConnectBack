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
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Kardex");
                    worksheet.Column("A").Width = 1.71;
                    worksheet.Column("B").Width = 11.29;
                    
                    worksheet.Cell(2, 2).Value = "Kardex:";
                    worksheet.Cell(2, 2).Style.Font.Bold = true;
                    worksheet.Cell(3, 2).Value = "Producto:";
                    worksheet.Cell(3, 2).Style.Font.Bold = true;
                    worksheet.Cell(4, 2).Value = "Sub Producto:";
                    worksheet.Cell(4, 2).Style.Font.Bold = true;
                    worksheet.Cell(5, 2).Value = "Fecha Inicio:";
                    worksheet.Cell(5, 2).Style.Font.Bold = true;
                    worksheet.Cell(6, 2).Value = "Fecha Fin:";
                    worksheet.Cell(6, 2).Style.Font.Bold = true;
                    //PRIMERA TABLA
                    worksheet.Cell(2, 8).Value = "Sacos";
                    worksheet.Cell(2, 8).Style.Font.Bold = true;
                    worksheet.Cell(2, 8).Style.Border.OutsideBorder = XLBorderStyleValues.Hair;
                    worksheet.Cell(2, 8).Style.Alignment.WrapText = true;
                    worksheet.Cell(2, 9).Value = "Kgs Netos a pagar";
                    worksheet.Cell(2, 9).Style.Font.Bold = true;
                    worksheet.Cell(2, 10).Value = "Moneda";
                    worksheet.Cell(2, 10).Style.Font.Bold = true;
                    worksheet.Cell(2, 11).Value = "Importe";
                    worksheet.Cell(2, 11).Style.Font.Bold = true;
                    worksheet.Cell(3, 7).Value = "Inventario Actual:";
                    worksheet.Cell(3, 7).Style.Font.Bold = true;

                    worksheet.Cell(8, 2).Value = "INGRESOS";
                    worksheet.Cell(8, 2).Style.Font.Bold = true;
                    worksheet.Cell(8, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    worksheet.Cell(8, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    IXLRange rangeIngresos = worksheet.Range(worksheet.Cell(8, 2), worksheet.Cell(8, 34));
                    rangeIngresos.Merge();

                    worksheet.Cell(8, 35).Value = "SALIDAS";
                    worksheet.Cell(8, 35).Style.Font.Bold = true;
                    worksheet.Cell(8, 35).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    worksheet.Cell(8, 35).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    IXLRange rangeSalidas = worksheet.Range(worksheet.Cell(8, 35), worksheet.Cell(8, 52));
                    rangeSalidas.Merge();

                    worksheet.Cell(9, 2).Value = "Fecha Recepcion";
                    worksheet.Cell(9, 3).Value = "Nro. Guia de Recepcion";
                    worksheet.Cell(9, 4).Value = "Fecha Nota de Compra";
                    worksheet.Cell(9, 5).Value = "N° Nota de Compra";
                    worksheet.Cell(9, 6).Value = "Fecha Ingreso Almacen";
                    worksheet.Cell(9, 7).Value = "Nro. Nota Ingreso";
                    worksheet.Cell(9, 8).Value = "Producto";
                    worksheet.Cell(9, 9).Value = "Sub Producto";
                    worksheet.Cell(9, 10).Value = "Tipo Proveedor";
                    worksheet.Cell(9, 11).Value = "Nombre/Razon Social";
                    worksheet.Cell(9, 12).Value = "Tipo Documento";
                    worksheet.Cell(9, 13).Value = "Nro. Documento";
                    worksheet.Cell(9, 14).Value = "Departamento";
                    worksheet.Cell(9, 15).Value = "Provincia";
                    worksheet.Cell(9, 16).Value = "Distrito";
                    worksheet.Cell(9, 17).Value = "Zona";
                    worksheet.Cell(9, 18).Value = "Unidad Medida";
                    worksheet.Cell(9, 19).Value = "Cantidad";
                    worksheet.Cell(9, 20).Value = "Kilos Brutos";
                    worksheet.Cell(9, 21).Value = "Tara";
                    worksheet.Cell(9, 22).Value = "Kilos Netos";
                    worksheet.Cell(9, 23).Value = "Dscto por humedad";
                    worksheet.Cell(9, 24).Value = "Kg netos a descontar";
                    worksheet.Cell(9, 25).Value = "Kg neto a pagar";
                    worksheet.Cell(9, 26).Value = "Moneda";
                    worksheet.Cell(9, 27).Value = "Precio pagado";
                    worksheet.Cell(9, 28).Value = "Importe";
                    worksheet.Cell(9, 29).Value = "% Humedad";
                    worksheet.Cell(9, 30).Value = "% Rendimiento";
                    worksheet.Cell(9, 31).Value = "Analisis Sensorial";
                    worksheet.Cell(9, 32).Value = "P.H.";
                    worksheet.Cell(9, 33).Value = "P.R.";
                    worksheet.Cell(9, 34).Value = "Nro. Nota de Salida";
                    worksheet.Cell(9, 35).Value = "Fecha Nota de Salida";
                    worksheet.Cell(9, 36).Value = "N° Nota de Salida";
                    worksheet.Cell(9, 37).Value = "Motivo";
                    worksheet.Cell(9, 38).Value = "Producto";
                    worksheet.Cell(9, 39).Value = "Sub Producto";
                    worksheet.Cell(9, 40).Value = "Unidad Medida";
                    worksheet.Cell(9, 41).Value = "Cantidad";
                    worksheet.Cell(9, 42).Value = "Kilos Brutos";
                    worksheet.Cell(9, 43).Value = "Tara";
                    worksheet.Cell(9, 44).Value = "Kilos Netos";
                    worksheet.Cell(9, 45).Value = "Dscto por humedad";
                    worksheet.Cell(9, 46).Value = "Kg netos a descontar";
                    worksheet.Cell(9, 47).Value = "Kg neto a pagar";
                    worksheet.Cell(9, 48).Value = "Moneda";
                    worksheet.Cell(9, 49).Value = "Precio";
                    worksheet.Cell(9, 50).Value = "Importe";
                    worksheet.Cell(9, 51).Value = "% Humedad";
                    worksheet.Cell(9, 52).Value = "% Rendimiento";

                    for (int i = 2; i <= 34; i++)
                    {
                        worksheet.Cell(9, i).Style.Fill.SetBackgroundColor(XLColor.YellowProcess);
                        worksheet.Cell(9, i).Style.Font.Bold = true;
                        worksheet.Cell(9, i).Style.Alignment.WrapText = true;
                        worksheet.Cell(9, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(9, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }

                    for (int i = 35; i <= 52; i++)
                    {
                        worksheet.Cell(9, i).Style.Fill.SetBackgroundColor(XLColor.BlueGray);
                        worksheet.Cell(9, i).Style.Font.Bold = true;
                        worksheet.Cell(9, i).Style.Alignment.WrapText = true;
                        worksheet.Cell(9, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(9, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }

                    worksheet.ColumnsUsed().AdjustToContents();
                    worksheet.RowsUsed().AdjustToContents();

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
