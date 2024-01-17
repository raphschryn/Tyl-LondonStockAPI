using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Mock3rdPartyLibrary.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Handlers
{
    public class StockHandler : IStockHandler
    {
        private readonly IMockLondonStockSDK _londonStockSDK;

        public StockHandler(IMockLondonStockSDK londonStockAPI)
        {
            _londonStockSDK = londonStockAPI;
        }

        public IEnumerable<Stock> GetStockPrices(IEnumerable<string> tickers)
        {
            // I assume the complexe and fast paste price calculation is done externally
            return _londonStockSDK.GetStocksWithPrice(tickers);
        }
    }
}
