using ParkingAudit.Infrastructure.Ports;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ParkingAudit.Infrastructure.Adapters
{

    public class ConfigureRabbitMq : IConfigureRabbitMq
    {

        public HanddleRabbitMqEventMessages _handdleRabbitMqEventMessages { get; set; } = default!;

        public void ConfgiAdnInitilizeRabbitMq()
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "alejo", Password = "alejo" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += HandlerMessages;
            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);


            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }

        private async void HandlerMessages(object? model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            await _handdleRabbitMqEventMessages(message);
        }

    }
}
