using Ios_api.DBContext.Entities;
using Ios_api.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ios_api.Controllers
{
    public class ProductController : Controller
    {
        private ILogger _logger;
        private IProductRepository _service;

        public ProductController(ILogger<ProductController> logger, IProductRepository service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = _service.GetProducts();

            if (result == null) return NotFound("Product not found");

            return Ok(result);
        }

        [HttpPost("/api/products")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null) return BadRequest();

            var result = _service.AddProduct(product);

            return Ok(result);
        }

        [HttpPut("/api/products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (product == null || product.id != id) return BadRequest();

            var result = _service.UpdateProduct(id, product);

            if (result == null) return NotFound("Product not found");

            return Ok(result);
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<int> DeleteProduct(int id)
        {
            var result = _service.DeleteProduct(id);

            if (!result) return NotFound("Product not found");
            //_logger.LogInformation("products", _products);
            return Ok("Delete product successfully");
        }
    }
}
