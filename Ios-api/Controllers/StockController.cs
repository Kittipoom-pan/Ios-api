using Ios_api.DBContext;
using Ios_api.DBContext.Entities;
using Ios_api.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

namespace Ios_api.Controllers
{
    public class StockController : Controller
    {
        private ILogger _logger;
        private IStockRepository _service;
        private IosDBContext _context;

        public StockController(ILogger<ProductController> logger, IStockRepository service, IosDBContext context)
        {
            _logger = logger;
            _context = context;
            _service = service;
        }

        [HttpGet("/api/stock")]
        public async Task<IActionResult> GetStock()
        {
            var result = _service.GetStocks();

            if (result == null) return NotFound("Stock not found");

            return Ok(result);
        }

        [HttpGet("/api/stock/available")]
        public async Task<IActionResult> GetStockByProductID(int productId)
        {
            var result = (from s in _context.Set<Stock>()
                          join p in _context.Set<Product>()
                          on s.productId equals p.id
                          where s.productId == productId
                          select new
                          {
                              productId = p.id,
                              name = p.name,
                              imageUrl = p.imageUrl,
                              price = p.price,
                              stockId = s.id,
                              amount = s.amount
                          }).ToList();

            if (result == null || result.Count == 0) return NotFound("Stock not found");

            return Ok(result);
        }

        [HttpPost("/api/stock")]
        public async Task<IActionResult> AddStock(Stock product)
        {
            if (product == null) return BadRequest();

            var result = _service.AddStock(product);

            return Ok(result);
        }

        [HttpPut("/api/stock/{id}")]
        public async Task<IActionResult> UpdateStock(int id, Stock product)
        {
            if (product == null || product.id != id) return BadRequest();

            var result = _service.UpdateStock(id, product);

            if (result == null) return NotFound("Stock not found");

            return Ok(result);
        }

        [HttpDelete("/api/stock/{id}")]
        public ActionResult<int> DeleteStock(int id)
        {
            var result = _service.DeleteStock(id);

            if (!result) return NotFound("Stock not found");
            //_logger.LogInformation("products", _products);
            return Ok("Delete stock successfully");
        }
    }
}
