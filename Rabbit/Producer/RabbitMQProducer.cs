using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Rabbit.Producer
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void sendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Queue");
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "Queue", body: body);
        }
    }
}