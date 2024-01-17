namespace Tyl.LondonStock.Shared.DbModels
{
    public class DbExchange
    {
        public Guid Id { get; set; } = new Guid();

        public DbBroker Broker { get; set; } = new DbBroker();

        public DbStock Stock { get; set; } = new DbStock();

        public decimal NumberOrShares { get; set; }

        public DateTimeOffset DateTimeOfExecution { get; set; } = DateTimeOffset.Now;
    }
}
