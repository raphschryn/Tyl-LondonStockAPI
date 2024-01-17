using Tyl.LondonStock.MockDatabase.Interfaces;
using Tyl.LondonStock.Repositories.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        IMockDatabase _mockDb;
        public ExchangeRepository(IMockDatabase mockDb)
        {
            _mockDb = mockDb;
        }

        public void Add(Exchange exchange)
        {
            _mockDb.AddExchange(DbMapper.Map(exchange));
        }
    }
}
