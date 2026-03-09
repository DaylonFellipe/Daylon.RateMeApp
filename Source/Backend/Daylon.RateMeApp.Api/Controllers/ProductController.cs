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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestCreateProductJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request data.");

           var product = await _productService.CreateProductAsync(request);

            return Ok(product);
        }
    }
}

//   /ᐠ - ˕ -マ D A Y L O N