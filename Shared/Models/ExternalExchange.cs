namespace Tyl.LondonStock.Shared.Models
{
    public class ExternalExchange
    {
        public Guid BrokerId { get; set; }

        public Stock Stock { get; set; } = new Stock();

        public decimal NumberOrShares { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ExternalExchange exchange &&
                   BrokerId.Equals(exchange.BrokerId) &&
                   EqualityComparer<Stock>.Default.Equals(Stock, exchange.Stock) &&
                   NumberOrShares == exchange.NumberOrShares;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
