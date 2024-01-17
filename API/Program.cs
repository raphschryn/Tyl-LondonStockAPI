using Tyl.LondonStock.Handlers;
using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Mock3rdPartyLibrary;
using Tyl.LondonStock.Mock3rdPartyLibrary.Interfaces;
using Tyl.LondonStock.MockDatabase;
using Tyl.LondonStock.MockDatabase.Interfaces;
using Tyl.LondonStock.Repositories;
using Tyl.LondonStock.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBrokerHandler, BrokerHandler>();
builder.Services.AddTransient<IExchangeHandler, ExchangeHandler>();
builder.Services.AddTransient<IBrokerHandler, BrokerHandler>();
builder.Services.AddTransient<IStockHandler, StockHandler>();

builder.Services.AddTransient<IExchangeRepository, ExchangeRepository>();

builder.Services.AddTransient<IMockDatabase, MockDatabase>();
builder.Services.AddTransient<IMockLondonStockSDK, MockLondonStockSDK>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
