using Moq;
using Tyl.LondonStock.Handlers.Interfaces;
using Xunit;


namespace Tyl.LondonStock.Handlers.HandlersTests
{
    public class BrokerHandlerTests
    {
        private readonly Mock<IBrokerHandler> _mockBrokerHandler = new();

        private BrokerHandler _handler;

        public BrokerHandlerTests()
        {
            _handler = new BrokerHandler();
        }

        #region GetBroker

        [Fact]
        public void GetBroker_ReturnsBroker()
        {
            var brokerId = Guid.NewGuid();

            var result = _handler.GetBroker(brokerId);

            Assert.NotNull(result);
            Assert.Equal(brokerId, result.Id);
            Assert.NotNull(result.FirstName);
            Assert.NotNull(result.LastName);
        }

        #endregion
    }
}
