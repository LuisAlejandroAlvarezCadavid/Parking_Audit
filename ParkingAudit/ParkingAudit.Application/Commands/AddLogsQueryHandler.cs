using MediatR;
using ParkingAudit.Infrastructure.Adapters.Logs;

namespace ParkingAudit.Application.Commands
{
    public class AddLogsQueryHandler : IRequestHandler<AddLogsQuery, bool>
    {
        readonly AddLogsRepository _addLogsRepository;
        public AddLogsQueryHandler(AddLogsRepository addLogsRepository)
        {
            _addLogsRepository = addLogsRepository;
        }

        public async Task<bool> Handle(AddLogsQuery request, CancellationToken cancellationToken)
        {
            return await _addLogsRepository.AddLogAsync(request.log, cancellationToken);
        }
    }
}
