using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Shared.Models;
using Tyl.LondonStock.API.Controllers;

namespace Tyl.LondonStock.API.ControllerTests
{
    public class ExchangeControllerTests
    {
        private readonly Mock<IExchangeHandler> _mockExchangeHandler = new();
        private readonly Mock<IBrokerHandler> _mockBrokerHandler = new();
        private ExternalExchange _externalExchange = new();
        private Broker _broker = new();

        private readonly ExchangeController _controller;

        public ExchangeControllerTests()
        {
            Setups();
            _controller = new ExchangeController(_mockExchangeHandler.Object, _mockBrokerHandler.Object);
        }

        private void Setups() 
        {
            _broker = new Broker
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe"
            };

            _externalExchange = new ExternalExchange
            {
                BrokerId = _broker.Id,
                Stock = new Stock
                {
                    Ticker = "Ticker",
                    Price = 1.2M
                },
                NumberOrShares = 3.4M
            };

            _mockBrokerHandler.Setup(mb => mb.GetBroker(It.IsAny<Guid>())).Returns(_broker);
        }

        #region Add

        [Fact]
        public void Add_ReturnsOk()
        {
            var result = _controller.Add(_externalExchange);

            Assert.NotNull(result);
            Assert.True(result is OkResult);
        }

        [Fact]
        public void Add_GetBroker_IsCalledWithBrokerId()
        {
            _controller.Add(_externalExchange);

            _mockBrokerHandler.Verify(mb => mb.GetBroker(_externalExchange.BrokerId), Times.Once());
        }

        [Fact]
        public void Add_HandlerAdd_IsCalledWithExchange()
        {
            _controller.Add(_externalExchange);

            _mockExchangeHandler.Verify(mb => mb.Add(It.Is<Exchange>(ex => 
                ex.Id != Guid.Empty &&
                ex.Broker.Equals(_broker) &&
                ex.Stock.Equals(_externalExchange.Stock) &&
                ex.NumberOrShares == _externalExchange.NumberOrShares
                )), Times.Once());
        }

        #endregion
    }
}
