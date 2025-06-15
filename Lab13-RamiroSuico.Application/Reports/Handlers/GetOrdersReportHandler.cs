using Lab13_RamiroSuico.Appication.Reports.Queries;
using Lab13_RamiroSuico.Domain.Interfaces;
using MediatR;

namespace Lab13_RamiroSuico.Application.Features.Reportes.Handlers
{
    public class GetOrdersReportHandler : IRequestHandler<GetOrdersReportQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelReportService _excelReportService;

        public GetOrdersReportHandler(IUnitOfWork unitOfWork, IExcelReportService excelReportService)
        {
            _unitOfWork = unitOfWork;
            _excelReportService = excelReportService;
        }

        public async Task<byte[]> Handle(GetOrdersReportQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(includeProperties: "Client");
            return _excelReportService.GenerateOrdersReport(orders);
        }
    }
}