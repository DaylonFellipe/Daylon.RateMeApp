using Daylon.RateMeApp.Application.DTOs.Product;
using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Daylon.RateMeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Get

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (!ModelState.IsValid)
                return BadRequest("Invalid request data.");

            return Ok(product);
        }

        // Post

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestCreateProductJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request data.");

            var productDTO = await _productService.CreateProductAsync(request);

            return Ok(productDTO);
        }

        // Delete

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
                return NotFound("Product not found.");

            return NoContent();
        }
    }
}

//   /ᐠ - ˕ -マ D A Y L O N