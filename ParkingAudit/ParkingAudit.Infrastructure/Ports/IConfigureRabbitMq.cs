namespace ParkingAudit.Infrastructure.Ports
{
    public delegate Task HanddleRabbitMqEventMessages(string message);
    public interface IConfigureRabbitMq
    {
        public HanddleRabbitMqEventMessages _handdleRabbitMqEventMessages { get; set; }
        void ConfgiAdnInitilizeRabbitMq();
    }
}
