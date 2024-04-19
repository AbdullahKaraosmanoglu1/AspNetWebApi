using Logging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<ProductModel>()
            {
                new ProductModel { Id = 1,Name="Computer"},
                new ProductModel { Id = 2,Name="Keyboard"},
                new ProductModel { Id = 3,Name="Mouse"}
            };

            _logger.LogInformation("GetAllProducts action has been called");

            return Ok(products);
        }
    }
}
