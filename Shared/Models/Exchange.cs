namespace Tyl.LondonStock.Shared.Models
{
    public class Exchange
    {
        public Guid Id { get; set; }

        public Broker Broker { get; set; } = new Broker();    

        public Stock Stock { get; set; } = new Stock();

        public decimal NumberOrShares { get; set; }

        public DateTimeOffset DateTimeOfExecution { get; set; } = DateTimeOffset.Now;

        public override bool Equals(object? obj)
        {
            return obj is Exchange exchange &&
                   Id.Equals(exchange.Id) &&
                   EqualityComparer<Broker>.Default.Equals(Broker, exchange.Broker) &&
                   EqualityComparer<Stock>.Default.Equals(Stock, exchange.Stock) &&
                   NumberOrShares == exchange.NumberOrShares &&
                   DateTimeOfExecution.Equals(exchange.DateTimeOfExecution);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Broker, Stock, NumberOrShares, DateTimeOfExecution);
        }
    }
}
