using MediatR;

namespace Lab13_RamiroSuico.Appication.Reports.Queries;

public record GetClientsReportQuery : IRequest<byte[]>;
