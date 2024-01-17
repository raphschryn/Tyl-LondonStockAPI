using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Tyl.LondonStock.MockDatabase.Interfaces;
using Tyl.LondonStock.Shared.Models;
using Xunit;

namespace Tyl.LondonStock.IntegrationTests;

public class ExchangeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ExchangeTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task AddExchange_ExchangeAddedToDB()
    {
        var client = _factory.CreateClient();

        var externalExchange = new ExternalExchange
        {
            BrokerId = Guid.NewGuid(),
            Stock = new Stock
            {
                Ticker = "Ticker1",
                Price = 1.23M
            },
            NumberOrShares = 2.34M
        };

        var json = JsonConvert.SerializeObject(externalExchange);
        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/exchange/add", httpContent);

        response.EnsureSuccessStatusCode();

        using (var _scope = _factory.Services.CreateScope())
        {
            var mockDbservice = _scope.ServiceProvider.GetRequiredService<IMockDatabase>();
            var exchanges = mockDbservice.GetExchanges();

            Assert.Single(exchanges.Where(ex => ex.Broker.Id == externalExchange.BrokerId));
            //Would be best to check 'exchanges' really contains the full expected data of 'externalExchange', instead of just the BrokerId
        }

    }

    // TODO:
    // More Integration tests to check more cases
}