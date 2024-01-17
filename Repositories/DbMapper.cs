using Tyl.LondonStock.Shared.DbModels;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.Repositories
{
    //Could use Automapper instead
    public static class DbMapper
    {
        public static DbExchange Map(Exchange trade) 
        {
            return new DbExchange
            {
                Id = trade.Id,
                Broker = new DbBroker
                {
                    Id = trade.Broker.Id,
                    FirstName = trade.Broker.FirstName,
                    LastName = trade.Broker.LastName,
                },
                Stock = new DbStock
                {
                    Ticker = trade.Stock.Ticker,
                    Price = trade.Stock.Price
                },
                NumberOrShares = trade.NumberOrShares,
                DateTimeOfExecution = trade.DateTimeOfExecution
            };
        }

        public static Exchange Map(DbExchange dbTrade)
        {
            return new Exchange
            {
                Id = dbTrade.Id,
                Broker = new Broker
                {
                    Id = dbTrade.Broker.Id,
                    FirstName = dbTrade.Broker.FirstName,
                    LastName = dbTrade.Broker.LastName,
                },
                Stock = new Stock
                {
                    Ticker = dbTrade.Stock.Ticker,
                    Price = dbTrade.Stock.Price
                },
                NumberOrShares = dbTrade.NumberOrShares,
                DateTimeOfExecution = dbTrade.DateTimeOfExecution
            };
        }
    }
}
