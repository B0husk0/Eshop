using Eshop.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Eshop.Api.Queue
{
    public class StockUpdateWorker : BackgroundService
    {
        private readonly IStockUpdateQueue _queue;
        private readonly IServiceProvider _services;
        private readonly ILogger<StockUpdateWorker> _logger;

        public StockUpdateWorker(IStockUpdateQueue queue, IServiceProvider services, ILogger<StockUpdateWorker> logger)
        {
            _queue = queue;
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var request in ReadQueueAsync(stoppingToken))
            {
                try
                {
                    using var scope = _services.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var product = await db.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId, stoppingToken);
                    if (product != null)
                    {
                        product.Quantity = request.Quantity;
                        await db.SaveChangesAsync(stoppingToken);

                        _logger.LogInformation("Stock updated for product {ProductId} -> {Quantity}", request.ProductId, request.Quantity);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing stock update");
                }
            }
        }

        private async IAsyncEnumerable<StockUpdateRequest> ReadQueueAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                yield return await _queue.DequeueAsync(cancellationToken);
            }
        }
    }
}
