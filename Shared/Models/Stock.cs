namespace Tyl.LondonStock.Shared.Models
{
    public class Stock
    {
        public string Ticker { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Stock stock &&
                   Ticker == stock.Ticker &&
                   Price == stock.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ticker, Price);
        }
    }
}
