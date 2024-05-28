using MediatR;

namespace ParkingAudit.Application.Commands
{
    public class AddLogsQueryHandler : IRequestHandler<AddLogsQuery, bool>
    {
        public AddLogsQueryHandler() { }

        public async Task<bool> Handle(AddLogsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }
    }
}
