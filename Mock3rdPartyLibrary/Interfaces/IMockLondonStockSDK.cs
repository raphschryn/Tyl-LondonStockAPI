using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Mock3rdPartyLibrary.Interfaces
{
    public interface IMockLondonStockSDK
    {
        IEnumerable<Stock> GetStocksWithPrice(IEnumerable<string> tickers);
    }
}
