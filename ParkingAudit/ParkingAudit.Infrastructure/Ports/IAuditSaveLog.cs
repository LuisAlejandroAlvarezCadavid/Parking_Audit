using ParkingAudit.Infrastructure.Entities;

namespace ParkingAudit.Infrastructure.Ports
{
    public interface IAuditSaveLog
    {
        Task<bool> AuditSaveLogAsync(Logs logs);
    }
}
