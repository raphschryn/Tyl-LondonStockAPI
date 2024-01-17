using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Tyl.LondonStock.Shared.Models;
using Xunit;

namespace Tyl.LondonStock.IntegrationTests;

public class StockTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public StockTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetPrices_EmptyTickers_ReturnsAllStocks()
    {
        var client = _factory.CreateClient();

        var json = JsonConvert.SerializeObject(Enumerable.Empty<string>());
        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/stock/price", httpContent);

        response.EnsureSuccessStatusCode();

        string jsonContent = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<IEnumerable<Stock>>(jsonContent);

        Assert.NotNull(content);
        Assert.NotEmpty(content);
        Assert.True(content is IEnumerable<Stock>);
    }

    [Fact]
    public async Task GetPrices_SpecificTickers_ReturnsTheStock()
    {
        var client = _factory.CreateClient();

        var json = JsonConvert.SerializeObject(new List<string> { "TYL" });
        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/stock/price", httpContent);

        response.EnsureSuccessStatusCode();

        string jsonContent = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<IEnumerable<Stock>>(jsonContent);

        Assert.NotNull(content);
        Assert.NotEmpty(content);
        Assert.Single(content);
        Assert.Equal("TYL", content.Single().Ticker);
    }

    // TODO:
    // More Integration tests to check more cases
}