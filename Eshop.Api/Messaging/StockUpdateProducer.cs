using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Eshop.Api.Messaging
{
    public class StockUpdateProducer
    {
        private readonly ConnectionFactory _factory;
        private readonly string _queueName;

        public StockUpdateProducer(IConfiguration config)
        {
            _queueName = config["RabbitMQ:QueueName"] ?? "stock_updates";

            _factory = new ConnectionFactory
            {
                HostName = config["RabbitMQ:Host"] ?? "localhost",
                UserName = config["RabbitMQ:User"] ?? "guest",
                Password = config["RabbitMQ:Pass"] ?? "guest"
            };
        }

        public async Task PublishAsync(StockUpdateMessage message, CancellationToken cancellationToken = default)
        {
            await using var connection = await _factory.CreateConnectionAsync(cancellationToken);
            await using var channel = await connection.CreateChannelAsync(null, cancellationToken);

            await channel.QueueDeclareAsync(
                queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: cancellationToken);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            await channel.BasicPublishAsync<BasicProperties>(
                exchange: "",
                routingKey: _queueName,
                mandatory: false,
                basicProperties: new BasicProperties(),
                body: body,
                cancellationToken: cancellationToken);

            Console.WriteLine($"[Producer] Sent stock update for Product {message.ProductId} → {message.Quantity}");
        }
    }
}
