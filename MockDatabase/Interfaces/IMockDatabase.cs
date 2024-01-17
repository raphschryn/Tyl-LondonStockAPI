using Tyl.LondonStock.Shared.DbModels;

namespace Tyl.LondonStock.MockDatabase.Interfaces
{
    public interface IMockDatabase
    {
        void AddExchange(DbExchange exchange);

        IQueryable<DbExchange> GetExchanges();
    }
}
