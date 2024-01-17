namespace Tyl.LondonStock.Shared.Models
{
    public class Broker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            return obj is Broker broker &&
                   Id.Equals(broker.Id) &&
                   FirstName == broker.FirstName &&
                   LastName == broker.LastName;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}