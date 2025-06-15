using Lab13_RamiroSuico.Appication.Reports.Queries;
using Microsoft.AspNetCore.Mvc;

using MediatR;

namespace Lab13_RamiroSuico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("clientes")]
    public async Task<IActionResult> GetClientesReporte()
    {
        var excelBytes = await _mediator.Send(new GetClientsReportQuery());
        return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reporte_clientes.xlsx");
    }
    
    [HttpGet("pedidos")]
    public async Task<IActionResult> GetPedidosReporte()
    {
        var excelBytes = await _mediator.Send(new GetOrdersReportQuery());
        return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reporte_pedidos.xlsx");
    }
}
