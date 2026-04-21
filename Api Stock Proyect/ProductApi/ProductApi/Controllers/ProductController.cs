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
using ProductApi.DTOs;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // Dependency Injection of Service Layer
        // This allows us to separate business logic from the controller
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

     
        // GET Method for all products
       
        // This endpoint retrieves all products from the system
        // It maps the internal Product model to a Response DTO
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAll();

            // Mapping Product To ProductResponseDTO
            var response = products.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return Ok(response);
        }

   
        // GET PRODUCT Method By ID
 
        // Retrieves a single product by its ID
        // Returns 404 if not found

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Mapping to Response DTO
            var response = new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return Ok(response);
        }

      
        // POST PRODUCT Method
     
        // Receives data from client using DTO (clean input)
        // Converts DTO into internal Product model
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO dto)
        {
            // Convert DTO into a Domain Model
            var product = new Product
            {
                // Temporary ID generation (will be replaced by DB in future)
                Id = new Random().Next(1000),
                Name = dto.Name,
                Price = dto.Price
            };

            var result = _productService.Create(product);

            // Validation failure return 400 Bad Request
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            // Mapping response list
            var response = result.Products!.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return Ok(response);
        }


        // UPDATE PRODUCT Method By an existing product by ID

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var result = _productService.Update(id, updatedProduct);

            // If product does not exist returns 404 error
            if (!result.Success)
            {
                if (result.Message == "Product not found")
                {
                    return NotFound(result.Message);
                }

                // Other validation errors returns 400 error
                return BadRequest(result.Message);
            }

            // Mapping updated list
            var response = result.Products!.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return Ok(response);
        }

        // DELETE PRODUCT Method By ID
        
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.Delete(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            // Mapping remaining products
            var response = result.Products!.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return Ok(response);
        }
    }
}
