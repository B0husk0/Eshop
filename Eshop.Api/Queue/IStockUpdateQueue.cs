using System.Threading.Channels;

namespace Eshop.Api.Queue
{
    public interface IStockUpdateQueue
    {
        ValueTask QueueStockUpdateAsync(StockUpdateRequest request, CancellationToken cancellationToken = default);
        ValueTask<StockUpdateRequest> DequeueAsync(CancellationToken cancellationToken);
    }

    public class StockUpdateQueue : IStockUpdateQueue
    {
        private readonly Channel<StockUpdateRequest> _queue;

        public StockUpdateQueue()
        {
            // Unbounded channel (no size limit)
            _queue = Channel.CreateUnbounded<StockUpdateRequest>();
        }

        public async ValueTask QueueStockUpdateAsync(StockUpdateRequest request, CancellationToken cancellationToken = default)
        {
            await _queue.Writer.WriteAsync(request, cancellationToken);
        }

        public async ValueTask<StockUpdateRequest> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _queue.Reader.ReadAsync(cancellationToken);
        }
    }
}
