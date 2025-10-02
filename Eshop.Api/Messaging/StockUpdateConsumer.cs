using System.Text;
using System.Text.Json;
using Eshop.Api.Data;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Eshop.Api.Messaging
{
    public class StockUpdateConsumer : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly IServiceProvider _services;
        private readonly string _queueName;

        public StockUpdateConsumer(IConfiguration config, IServiceProvider services)
        {
            _services = services;
            _queueName = config["RabbitMQ:QueueName"] ?? "stock_updates";

            _factory = new ConnectionFactory
            {
                HostName = config["RabbitMQ:Host"] ?? "localhost",
                UserName = config["RabbitMQ:User"] ?? "guest",
                Password = config["RabbitMQ:Pass"] ?? "guest"
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connection = await _factory.CreateConnectionAsync(stoppingToken);
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            var consumer = new CustomConsumer(channel, _services);

            await channel.BasicConsumeAsync(
                queue: _queueName,
                autoAck: true,
                consumer: consumer,
                cancellationToken: stoppingToken);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        private class CustomConsumer : IAsyncBasicConsumer
        {
            public IChannel Channel { get; }
            private readonly IServiceProvider _services;

            public CustomConsumer(IChannel channel, IServiceProvider services)
            {
                Channel = channel;
                _services = services;
            }

            public Task HandleBasicCancelAsync(string consumerTag, CancellationToken cancellationToken = default)
                => Task.CompletedTask;

            public Task HandleBasicCancelOkAsync(string consumerTag, CancellationToken cancellationToken = default)
                => Task.CompletedTask;

            public Task HandleBasicConsumeOkAsync(string consumerTag, CancellationToken cancellationToken = default)
                => Task.CompletedTask;

            public async Task HandleBasicDeliverAsync(
                string consumerTag,
                ulong deliveryTag,
                bool redelivered,
                string exchange,
                string routingKey,
                IReadOnlyBasicProperties properties,
                ReadOnlyMemory<byte> body,
                CancellationToken cancellationToken = default)
            {
                var json = Encoding.UTF8.GetString(body.Span);
                var message = JsonSerializer.Deserialize<StockUpdateMessage>(json);

                if (message != null)
                {
                    using var scope = _services.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var product = await db.Products.FirstOrDefaultAsync(p => p.Id == message.ProductId, cancellationToken);
                    if (product != null)
                    {
                        product.Quantity = message.Quantity;
                        await db.SaveChangesAsync(cancellationToken);
                        Console.WriteLine($"[Consumer] Updated stock for Product {product.Id} → {product.Quantity}");
                    }
                }
            }

            public Task HandleChannelShutdownAsync(object channel, ShutdownEventArgs reason)
                => Task.CompletedTask;
        }
    }
}
