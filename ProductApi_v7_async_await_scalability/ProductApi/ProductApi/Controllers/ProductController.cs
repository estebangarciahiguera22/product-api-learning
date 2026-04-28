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
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET all products asynchronously
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            var responseData = _mapper.Map<List<ProductResponseDTO>>(products);

            return Ok(new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = responseData
            });
        }

        // GET product by ID asynchronously
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

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

            return Ok(new ApiResponse<ProductResponseDTO>
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = responseData
            });
        }

        // CREATE product asynchronously
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);

            // ID generation is handled by the database
            var result = await _productService.CreateAsync(product);

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

            return Ok(new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Product created successfully",
                Data = responseData
            });
        }

        // UPDATE product asynchronously
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO dto)
        {
            var updatedProduct = _mapper.Map<Product>(dto);

            var result = await _productService.UpdateAsync(id, updatedProduct);

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

            return Ok(new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Product updated successfully",
                Data = responseData
            });
        }

        // DELETE product asynchronously
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteAsync(id);

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

            return Ok(new ApiResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Product deleted successfully",
                Data = responseData
            });
        }
    }
}