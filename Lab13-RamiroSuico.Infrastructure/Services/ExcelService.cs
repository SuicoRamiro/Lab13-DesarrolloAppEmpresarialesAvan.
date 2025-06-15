using ClosedXML.Excel;

namespace Lab13_RamiroSuico.Infrastructure.Services
{
    public class ExcelService
    {
        public void FirstExample()
        {
            using (var workbook = new XLWorkbook())
            {
                // Crear hoja
                var worksheet = workbook.Worksheets.Add("Hoja1");

                // Datos de ejemplo
                worksheet.Cell(1, 1).Value = "Nombre";
                worksheet.Cell(1, 2).Value = "Edad";
                worksheet.Cell(2, 1).Value = "Juan";
                worksheet.Cell(2, 2).Value = 28;

                // Guardar archivo
                workbook.SaveAs("/Users/ramiro/Documents/Semestre6/Desarrollo de Aplicaciones Empresariales Avanzado/Proyectos/ArchivosExcel/primer_archivo.xlsx");
            }
        }
        public void SecondExample()
        {
            using (var workbook = new XLWorkbook("/Users/ramiro/Documents/Semestre6/Desarrollo de Aplicaciones Empresariales Avanzado/Proyectos/ArchivosExcel/primer_archivo.xlsx"))
            {
                var worksheet = workbook.Worksheet(1); // Primera hoja

                // Cambiar Edad de Juan a 30
                worksheet.Cell(2, 2).Value = 30;

                workbook.Save(); // Sobrescribe el archivo
            }
        }
        public void ThirdExample()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Edad";

                // Datos
                worksheet.Cell(2, 1).Value = 1;
                worksheet.Cell(2, 2).Value = "Juan";
                worksheet.Cell(2, 3).Value = 28;

                worksheet.Cell(3, 1).Value = 2;
                worksheet.Cell(3, 2).Value = "Maria";
                worksheet.Cell(3, 3).Value = 34;

                // Crear tabla
                var range = worksheet.Range("A1:C3");
                range.CreateTable();

                // Guardar archivo
                workbook.SaveAs("/Users/ramiro/Documents/Semestre6/Desarrollo de Aplicaciones Empresariales Avanzado/Proyectos/ArchivosExcel/tabla.xlsx");
            }
        }
        public void FourthExample()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Estilos");

                // Aplicar estilos al encabezado (fila 1)
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.Cyan;
                headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Encabezados
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Edad";

                // Datos
                worksheet.Cell(2, 1).Value = 1;
                worksheet.Cell(2, 2).Value = "Juan";
                worksheet.Cell(2, 3).Value = 28;

                // Guardar con formato
                workbook.SaveAs("/Users/ramiro/Documents/Semestre6/Desarrollo de Aplicaciones Empresariales Avanzado/Proyectos/ArchivosExcel/archivo_con_estilos.xlsx");
            }
        }
    }
}