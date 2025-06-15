using ClosedXML.Excel;
using Lab13_RamiroSuico.Domain.Interfaces;
using Lab13_RamiroSuico.Domain.Models;

namespace Lab13_RamiroSuico.Infrastructure.Services;

public class ExcelReportService : IExcelReportService
{
    public byte[] GenerateClientsReport(IEnumerable<Client> clients)
    {
        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Clientes");

        ws.Cell(1, 1).Value = "ID";
        ws.Cell(1, 2).Value = "Nombre";
        ws.Cell(1, 3).Value = "Email";

        int row = 2;
        foreach (var client in clients)
        {
            ws.Cell(row, 1).Value = client.Clientid;
            ws.Cell(row, 2).Value = client.Name;
            ws.Cell(row, 3).Value = client.Email;
            row++;
        }

        using var ms = new MemoryStream();
        workbook.SaveAs(ms);
        return ms.ToArray();
    }

    public byte[] GenerateOrdersReport(IEnumerable<Order> orders)
    {
        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Pedidos");

        ws.Cell(1, 1).Value = "ID Pedido";
        ws.Cell(1, 2).Value = "Cliente";
        ws.Cell(1, 3).Value = "Fecha";

        int row = 2;
        foreach (var order in orders)
        {
            ws.Cell(row, 1).Value = order.Orderid;
            ws.Cell(row, 2).Value = order.Client.Name;
            ws.Cell(row, 3).Value = order.Orderdate;
            row++;
        }

        using var ms = new MemoryStream();
        workbook.SaveAs(ms);
        return ms.ToArray();
    }
}
