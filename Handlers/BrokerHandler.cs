using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Handlers
{
    public class BrokerHandler : IBrokerHandler
    {
        public Broker GetBroker(Guid brokerId)
        {
            // TODO:
            // check logged in user can use that broker
            // get it from the DB or ERROR if not found + log with ILogger

            var rnd = new Random();

            return new Broker
            {
                Id = brokerId,
                FirstName = rnd.Next(0, 100).ToString(),
                LastName = rnd.Next(0, 100).ToString()
            };
        }
    }
}
