using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Handlers.Interfaces
{
    public interface IStockHandler
    {
        IEnumerable<Stock> GetStockPrices(IEnumerable<string> tickers);
    }
}
