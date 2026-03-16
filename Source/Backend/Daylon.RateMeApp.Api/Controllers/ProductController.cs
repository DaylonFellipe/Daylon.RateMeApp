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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products == null || !products.Any())
                return NotFound(ResourceMessagesException.PRODUCT_NO_FOUND);

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResourceMessagesException.REQUEST_INVALID);

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(ResourceMessagesException.PRODUCT_ID_NO_FOUND);

            return Ok(product);
        }

        // Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] RequestCreateProductJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResourceMessagesException.REQUEST_INVALID);

            var productDTO = await _productService.CreateProductAsync(request);

            return Created("", productDTO);
        }

        // Put
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] RequestUpdateProductJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResourceMessagesException.REQUEST_INVALID);

            var result = await _productService.UpdateProductAsync(request);

            return Ok(result);
        }

        // Delete
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResourceMessagesException.REQUEST_INVALID);

            var result = await _productService.DeleteProductAsync(id);

            if (!result)
                return NotFound(ResourceMessagesException.PRODUCT_NO_FOUND);

            return NoContent();
        } 
    }
}

//   /ᐠ - ˕ -マ D A Y L O N