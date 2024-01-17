using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Handlers.Interfaces
{
    public interface IBrokerHandler
    {
        Broker GetBroker(Guid brokerId);
    }
}
