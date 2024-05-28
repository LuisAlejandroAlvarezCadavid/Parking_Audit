using MediatR;
using ParkingAudit.Infrastructure.Entities;

namespace ParkingAudit.Application.Commands
{
    public record AddLogsQuery(Logs log) : IRequest<bool> { }
}
