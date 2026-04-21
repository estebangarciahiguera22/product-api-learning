/*
API ACCESS (LOCAL DEVELOPMENT)

Swagger UI:
https://localhost:{port}/swagger

Base Endpoint:
https://localhost:{port}/api/product

NOTE:
The port may vary depending on your environment.
*/


using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController] // Marks  class as an API controller
    [Route("api/[controller]")] // Base route = /api/Product
    public class ProductController : ControllerBase
    {
        // Dependency injection of the service layer
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

    
        // GET ALL PRODUCTS METHOD 
      
        [HttpGet]
        public IActionResult GetProducts()
        {
            // Calls service layer (no business logic here)
            var products = _productService.GetAll();

            // Returns HTTP 200 OK with data
            return Ok(products);
        }


        // GET PRODUCT METHOD applied on products BY ID

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetById(id);

            // If not found → return 404
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }


        // POST METHOD applied on products

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var result = _productService.Create(product);

            // If validation fails → return 400
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Products);
        }

        // PUT METHOD applied on products

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var result = _productService.Update(id, updatedProduct);

            if (!result.Success)
            {
                // Specific case: not found
                if (result.Message == "Product not found")
                {
                    return NotFound(result.Message);
                }

                // Other validation errors → 400
                return BadRequest(result.Message);
            }

            return Ok(result.Products);
        }


        // DELETE PRODUCT applied on products

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.Delete(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Products);
        }
    }
}

