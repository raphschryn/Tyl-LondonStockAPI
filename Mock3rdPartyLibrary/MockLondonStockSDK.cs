using Tyl.LondonStock.Mock3rdPartyLibrary.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Mock3rdPartyLibrary
{
    public class MockLondonStockSDK : IMockLondonStockSDK
    {
        public IEnumerable<Stock> GetStocksWithPrice(IEnumerable<string> tickers)
        {
            var rnd = new Random();

            var Stocks = new List<Stock>
            {
                new Stock
                {
                    Ticker = "TYL",
                    Price = new decimal(rnd.NextDouble()) * 100
                },
                new Stock
                {
                    Ticker = "MSFT",
                    Price = new decimal(rnd.NextDouble()) * 100
                },
                new Stock
                {
                    Ticker = "TSLA",
                    Price = new decimal(rnd.NextDouble()) * 100
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = new decimal(rnd.NextDouble()) * 100
                }
            };

            return tickers.Any() ? Stocks.Where(s => tickers.Contains(s.Ticker)) : Stocks;
        }

    }
}
