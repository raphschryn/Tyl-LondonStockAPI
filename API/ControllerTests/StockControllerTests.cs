using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.API.Controllers;

namespace Tyl.LondonStock.API.ControllerTests
{
    public class StockControllerTests
    {
        private readonly Mock<IStockHandler> _mockStockHandler = new();

        private readonly StockController _controller;

        public StockControllerTests()
        {
            _controller = new StockController(_mockStockHandler.Object);
        }

        #region _mockStockHandler

        [Fact]
        public void GetPrices_NullTickers_ReturnsOk()
        {
            var result = _controller.GetPrices(null);

            Assert.NotNull(result);
            Assert.True(result.Result is OkObjectResult);
        }

        [Fact]
        public void GetPrices_EmptyTickers_ReturnsOk()
        {
            var result = _controller.GetPrices(new List<string>());

            Assert.NotNull(result);
            Assert.True(result.Result is OkObjectResult);
        }

        [Fact]
        public void GetPrices_PopulatedTickers_ReturnsOk()
        {
            var result = _controller.GetPrices(new List<string> { "TIC1", "TIC2" });

            Assert.NotNull(result);
            Assert.True(result.Result is OkObjectResult);
        }

        [Fact]
        public void GetPrices_NullTickers_IsCalledWithEmptyTickers()
        {
            var result = _controller.GetPrices(null);

            _mockStockHandler.Verify(ms => ms.GetStockPrices(Enumerable.Empty<string>()), Times.Once);
        }

        [Fact]
        public void GetPrices_EmptyTickers_IsCalledWithEmptyTickers()
        {
            var result = _controller.GetPrices(Enumerable.Empty<string>());

            _mockStockHandler.Verify(ms => ms.GetStockPrices(Enumerable.Empty<string>()), Times.Once);
        }

        [Fact]
        public void GetPrices_PopulatedTickers_IsCalledWithPopulatedTickers()
        {
            var tickers = new List<string> { "TIC1", "TIC2" };

            var result = _controller.GetPrices(tickers);

            _mockStockHandler.Verify(ms => ms.GetStockPrices(tickers), Times.Once);
        }

        #endregion
    }
}
