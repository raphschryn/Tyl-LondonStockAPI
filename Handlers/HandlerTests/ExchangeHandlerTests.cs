using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using System.Net.NetworkInformation;
using Tyl.LondonStock.Repositories.Interfaces;
using Tyl.LondonStock.Shared.DbModels;
using Tyl.LondonStock.Shared.Models;
using Xunit;

namespace Tyl.LondonStock.Handlers.HandlersTests
{
    public class ExchangeHandlerTests
    {
        private readonly Mock<IExchangeRepository> _mockExchangeRepository = new();
        private readonly Mock<ILogger<ExchangeHandler>> _mockLogger = new();
        private Exchange _exchange = new();

        private ExchangeHandler _handler;

        public ExchangeHandlerTests()
        {
            Setups();
            _handler = new ExchangeHandler(_mockExchangeRepository.Object, _mockLogger.Object);
        }

        private void Setups()
        {
            _exchange = new Exchange
            {
                Id = Guid.NewGuid(),
                Broker = new Broker
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                },
                Stock = new Stock
                {
                    Ticker = "Ticker",
                    Price = 1.2M
                },
                NumberOrShares = 3.4M,
                DateTimeOfExecution = DateTimeOffset.Now
            };
        }

        #region Add

        [Fact]
        public void Add_CallsAddRespositoryWithExchange()
        {
            _handler.Add(_exchange);

            _mockExchangeRepository.Verify(er => er.Add(_exchange), Times.Once);
        }

        [Fact]
        public void Add_Logs()
        {
            _handler.Add(_exchange);
            _mockLogger.Verify(l =>
            l.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains($"Exchange added:{_exchange.Id}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ), Times.Once);

        }

        #endregion
    }
}
