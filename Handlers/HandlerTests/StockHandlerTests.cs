using Moq;
using Tyl.LondonStock.Mock3rdPartyLibrary.Interfaces;
using Tyl.LondonStock.Shared.Models;
using Xunit;

namespace Tyl.LondonStock.Handlers.HandlersTests
{
    public class StockHandlerTests
    {
        private readonly Mock<IMockLondonStockSDK> _mockLondonStockAPI = new();
        private IEnumerable<Stock> _stock;
        private StockHandler _handler;

        public StockHandlerTests()
        {
            Setups();
            _handler = new StockHandler(_mockLondonStockAPI.Object);
        }

        private void Setups()
        {
            _stock = new List<Stock>
            {
                new Stock
                {
                    Ticker = "TYL",
                    Price = 1.2M
                },
                new Stock
                {
                    Ticker = "MSFT",
                    Price = 2.3M
                },
                new Stock
                {
                    Ticker = "TSLA",
                    Price = 4.5M
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 6.7M
                }
            };

            _mockLondonStockAPI.Setup(ml => ml.GetStocksWithPrice(It.IsAny<IEnumerable<string>>())).Returns(_stock);
        }

        #region GetStockPrices

        [Fact]
        public void GetStockPrices_Calls3rdPartySDK()
        {
            _handler.GetStockPrices(new List<string>());

            _mockLondonStockAPI.Verify(ml => ml.GetStocksWithPrice(new List<string>()), Times.Once);
        }

        [Fact]
        public void GetStockPrices_ReturnsStocks()
        {
            var result = _handler.GetStockPrices(new List<string>());

            Assert.Equal(_stock, result);
        }

        #endregion
    }
}
