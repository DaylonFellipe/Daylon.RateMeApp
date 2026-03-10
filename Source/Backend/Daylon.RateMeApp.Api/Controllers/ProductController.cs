using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Daylon.RateMeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

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
                return BadRequest(ResourceMessagesException.REQUEST_INVALID);

            return Ok(product);
        }

        // Post

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestCreateProductJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResourceMessagesException.REQUEST_INVALID);

            var productDTO = await _productService.CreateProductAsync(request);

            return Ok(productDTO);
        }

        // Delete

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
                return NotFound(ResourceMessagesException.PRODUCT_NO_FOUND);

            return NoContent();
        }
    }
}

//   /ᐠ - ˕ -マ D A Y L O N