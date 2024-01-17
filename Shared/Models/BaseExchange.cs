namespace Tyl.LondonStock.Shared.Models
{
    public class BaseExchange
    {
        public Stock Stock { get; set; } = new Stock();

        public decimal NumberOrShares { get; set; }
    }
}
