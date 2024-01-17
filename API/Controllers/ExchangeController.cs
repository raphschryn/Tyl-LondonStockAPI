using Microsoft.AspNetCore.Mvc;
using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.API.Controllers
{
    [ApiController]
    [Route("exchange")]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeHandler _exchangeHandler;
        private readonly IBrokerHandler _brokerHandler;

        public ExchangeController(IExchangeHandler exchangeHandler, IBrokerHandler brokerHandler)
        {
            _exchangeHandler = exchangeHandler;
            _brokerHandler = brokerHandler;
        }

        // TODO:
        // authenticate and authorise user
        [HttpPost]
        [Route("add")]
        public IActionResult Add(ExternalExchange externalExchange)
        {
            var broker = _brokerHandler.GetBroker(externalExchange.BrokerId);
            // TODO
            // Handle broker doesn't exist

            _exchangeHandler.Add(ExchangeMapper(externalExchange, broker));

            return Ok();
        }

        //Best to remove this from here and have a Mapper service
        private Exchange ExchangeMapper(ExternalExchange externalExchange, Broker broker) 
        {
            return new Exchange
            {
                Id = Guid.NewGuid(),
                Broker = broker,
                Stock = externalExchange.Stock,
                NumberOrShares = externalExchange.NumberOrShares
            };
        }
    }
}
