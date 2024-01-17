using Microsoft.Extensions.Logging;
using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Repositories.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Handlers
{
    public class ExchangeHandler : IExchangeHandler
    {
        private readonly ILogger<ExchangeHandler> _logger;
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeHandler(IExchangeRepository exchangeRepository, ILogger<ExchangeHandler> logger)
        {
            _exchangeRepository = exchangeRepository;
            _logger = logger;
        }

        public void Add(Exchange exchange)
        {
            // TODO:
            // Check stock exists
            // Check numberOrShares > 0
            // Somehow check price is OK?

            _exchangeRepository.Add(exchange);
            _logger.LogInformation(message: $"Exchange added:{exchange.Id}");
        }
    }
}
