using Microsoft.Extensions.DependencyInjection;
using ParkingAudit.Infrastructure.Adapters;
using ParkingAudit.Infrastructure.Ports;

namespace ParkingAudit.Infrastructure.Extensions
{
    public static class RabbitMqService
    {
        public static IServiceCollection AddRabbitMqService(this IServiceCollection service)
        {
            service.AddScoped<IConfigureRabbitMq, ConfigureRabbitMq>();
            return service;
        }
    }
}
