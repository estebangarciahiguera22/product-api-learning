using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService
    {
        // Dependency Injection of DbContext
        // This allows us to interact with the database using Entity Framework
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL PRODUCTS
        // Retrieves all products from the database asynchronously
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // GET PRODUCT BY ID
        // Retrieves a single product based on its ID asynchronously
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        // CREATE PRODUCT
        // Validates input and saves a new product into the database asynchronously
        public async Task<ServiceResult> CreateAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product name is required"
                };
            }

            if (product.Price <= 0)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product price must be greater than zero"
                };
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Message = "Product created successfully",
                Products = await _context.Products.ToListAsync()
            };
        }

        // UPDATE PRODUCT
        // Updates an existing product based on its ID asynchronously
        public async Task<ServiceResult> UpdateAsync(int id, Product updatedProduct)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            if (string.IsNullOrWhiteSpace(updatedProduct.Name))
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product name is required"
                };
            }

            if (updatedProduct.Price <= 0)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product price must be greater than zero"
                };
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Message = "Product updated successfully",
                Products = await _context.Products.ToListAsync()
            };
        }

        // DELETE PRODUCT
        // Removes a product from the database based on its ID asynchronously
        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Message = "Product deleted successfully",
                Products = await _context.Products.ToListAsync()
            };
        }
    }
}