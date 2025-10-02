namespace Eshop.Api.Messaging
{
    public class StockUpdateMessage
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
