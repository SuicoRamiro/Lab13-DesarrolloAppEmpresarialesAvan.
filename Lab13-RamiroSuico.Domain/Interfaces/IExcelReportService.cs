using Lab13_RamiroSuico.Domain.Models;

namespace Lab13_RamiroSuico.Domain.Interfaces;

public interface IExcelReportService
{
    byte[] GenerateClientsReport(IEnumerable<Client> clients);
    byte[] GenerateOrdersReport(IEnumerable<Order> orders);
}
