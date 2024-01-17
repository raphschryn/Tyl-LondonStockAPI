using System.Text.Json;
using Tyl.LondonStock.MockDatabase.Interfaces;
using Tyl.LondonStock.Shared.DbModels;

namespace Tyl.LondonStock.MockDatabase
{
    public class MockDatabase : IMockDatabase
    {
        public string _filePath = Path.GetFullPath(@"Exchanges.txt", AppDomain.CurrentDomain.BaseDirectory);

        public void AddExchange(DbExchange exchange) 
        {
            var tradeJson = JsonSerializer.Serialize(exchange);

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(tradeJson);
            }
        }

        public IQueryable<DbExchange> GetExchanges()
        {
            var exchanges = new List<DbExchange>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                string? line;

                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    var exchange = JsonSerializer.Deserialize<DbExchange>(line);
                    if (exchange != null)
                    {
                        exchanges.Add(exchange);
                    }
                }
            }

            return exchanges.AsQueryable();
        }
    }
}
