using Lab13_RamiroSuico.Appication.Reports.Queries;
using MediatR;

using Lab13_RamiroSuico.Domain.Interfaces;

namespace Lab13_RamiroSuico.Appication.Reports.Handlers;

public class GetClientsReportHandler : IRequestHandler<GetClientsReportQuery, byte[]>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExcelReportService _excelReportService;

    public GetClientsReportHandler(IUnitOfWork unitOfWork, IExcelReportService excelReportService)
    {
        _unitOfWork = unitOfWork;
        _excelReportService = excelReportService;
    }

    public async Task<byte[]> Handle(GetClientsReportQuery request, CancellationToken cancellationToken)
    {
        var clients = await _unitOfWork.ClientRepository.GetAllAsync();
        return _excelReportService.GenerateClientsReport(clients);
    }
}
