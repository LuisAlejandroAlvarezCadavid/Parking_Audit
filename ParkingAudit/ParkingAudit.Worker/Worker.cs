using MediatR;
using Microsoft.Extensions.Hosting;
using ParkingAudit.Application.Commands;
using ParkingAudit.Infrastructure.Entities;
using ParkingAudit.Infrastructure.Ports;
using System.Text.Json;


namespace ParkingAudit.Worker
{
    public class Worker : BackgroundService
    {
        readonly IConfigureRabbitMq _configureRabbitMq;
        readonly IMediator _mediator;
        public Worker(IConfigureRabbitMq configureRabbitMq, IMediator mediator)
        {
            _configureRabbitMq = configureRabbitMq;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _configureRabbitMq._handdleRabbitMqEventMessages = HandlerMessages;
            _configureRabbitMq.ConfgiAdnInitilizeRabbitMq();
        }

        private async Task HandlerMessages(string message)
        {
            var log = JsonSerializer.Deserialize<Logs>(message);
            await _mediator.Send(new AddLogsQuery(log));
        }
    }
}
