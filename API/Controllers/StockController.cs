using Microsoft.AspNetCore.Mvc;
using Tyl.LondonStock.Handlers.Interfaces;
using Tyl.LondonStock.Shared.Models;

namespace Tyl.LondonStock.API.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockHandler _stockHandler;

        public StockController(IStockHandler stockHandler)
        {
            _stockHandler = stockHandler;
        }

        // TODO:
        // authenticate and authorise user
        [HttpPost]
        [Route("price")]
        public ActionResult<IEnumerable<Stock>> GetPrices(IEnumerable<string>? tickers)
        {
            return Ok(_stockHandler.GetStockPrices(tickers ?? Enumerable.Empty<string>()));
        }
    }
}
