using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fase3JavierGarcia.Generators
{
    public class ReportGenerator
    {
        
        public void GeneratePilaReport(Stack<EstructuraDatosUsuario> pila, TextBox outputTextBox)
        {
            decimal totalCopago = pila.Sum(u => u.ValorCopago);
            outputTextBox.Text = $"${totalCopago:N0}";
        }

        public void GenerateColaReport(Queue<EstructuraDatosUsuario> cola, TextBox outputTextBox)
        {
            int count = cola.Count;
            outputTextBox.Text = $"{count}";
        }

        public void GenerateListaReport(List<EstructuraDatosUsuario> lista, TextBox outputTextBox)
        {
            if (lista.Any())
            {
                double averageAge = lista.Average(u => u.Edad);
                if (averageAge % 1 == 0)
                {
                    outputTextBox.Text = $"{(int)averageAge}";
                }
                else
                {
                    outputTextBox.Text = $"{averageAge:N2}";
                }
            }
            else
            {
                outputTextBox.Text = "0";
            }
        }

        public void ExportAllReportsToExcel(Stack<EstructuraDatosUsuario> pila, Queue<EstructuraDatosUsuario> cola, List<EstructuraDatosUsuario> lista)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar Todos los Reportes en Excel";
                saveFileDialog.FileName = $"Reportes_Completos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var package = new ExcelPackage())
                        {
                            // Hoja 1: Pila
                            var worksheetPila = package.Workbook.Worksheets.Add("Reporte_Pila");
                            worksheetPila.Cells["A1"].LoadFromCollection(pila.Reverse(), true);

                            // Hoja 2: Cola
                            var worksheetCola = package.Workbook.Worksheets.Add("Reporte_Cola");
                            worksheetCola.Cells["A1"].LoadFromCollection(cola, true);

                            // Hoja 3: Lista
                            var worksheetLista = package.Workbook.Worksheets.Add("Reporte_Lista");
                            worksheetLista.Cells["A1"].LoadFromCollection(lista, true);

                            // Guarda el archivo
                            File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        }
                        MessageBox.Show("Todos los reportes han sido guardados exitosamente en un solo archivo de Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}