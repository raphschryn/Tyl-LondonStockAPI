namespace Tyl.LondonStock.Shared.DbModels
{
    public class DbStock
    {
        public string Ticker { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
