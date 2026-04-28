/*
API ACCESS (LOCAL DEVELOPMENT)

Swagger UI:
https://localhost:{port}/swagger

Base Endpoint:
https://localhost:{port}/api/product

NOTE:
The port may vary depending on your environment.
*/

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;
using ProductApi.DTOs;
using ProductApi.Responses;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // Service layer handles business logic

        private readonly ProductService _productService;

        // AutoMapper handles object transformation between DTOs and models

        private readonly IMapper _mapper;

        public ProductController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET all products

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAll();
            var responseData = _mapper.Map<List<ProductResponseDTO>>(products);

            var response = new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = responseData
            };

            return Ok(response);
        }

        // GET product by ID

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Product not found",
                    Data = null
                });
            }

            var responseData = _mapper.Map<ProductResponseDTO>(product);

            var response = new ApiResponse<ProductResponseDTO>
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = responseData
            };

            return Ok(response);
        }

        // CREATE product

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);

            // Temporary ID generation
            // In a real-world project, the database would generate this value

            product.Id = new Random().Next(1000);

            var result = _productService.Create(product);

            if (!result.Success)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = result.Message,
                    Data = null
                });
            }

            var responseData = _mapper.Map<List<ProductResponseDTO>>(result.Products);

            var response = new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Product created successfully",
                Data = responseData
            };

            return Ok(response);
        }

        // UPDATE product

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductDTO dto)
        {
            var updatedProduct = _mapper.Map<Product>(dto);

            var result = _productService.Update(id, updatedProduct);

            if (!result.Success)
            {
                if (result.Message == "Product not found")
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null
                    });
                }

                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = result.Message,
                    Data = null
                });
            }

            var responseData = _mapper.Map<List<ProductResponseDTO>>(result.Products);

            var response = new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Product updated successfully",
                Data = responseData
            };

            return Ok(response);
        }

        // DELETE product

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.Delete(id);

            if (!result.Success)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = result.Message,
                    Data = null
                });
            }

            var responseData = _mapper.Map<List<ProductResponseDTO>>(result.Products);

            var response = new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Product deleted successfully",
                Data = responseData
            };

            return Ok(response);
        }
    }
}