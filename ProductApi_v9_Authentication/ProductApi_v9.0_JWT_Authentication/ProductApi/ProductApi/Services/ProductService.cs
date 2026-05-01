using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Exceptions;

namespace ProductApi.Services
{
    public class ProductService
    {
        // Dependency Injection of DbContext.
        // This allows the service layer to interact with the database using Entity Framework Core.
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL PRODUCTS
        // Retrieves all products from the database asynchronously.
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // GET PRODUCT BY ID
        // Retrieves a single product by ID.
        // Throws NotFoundException if the product does not exist.
        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            return product;
        }

        // CREATE PRODUCT
        // Validates input and saves a new product into the database.
        // Throws BadRequestException when business rules are violated.
        public async Task<List<Product>> CreateAsync(Product product)
        {
            ValidateProduct(product);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        // UPDATE PRODUCT
        // Updates an existing product by ID.
        // Throws NotFoundException if the product does not exist.
        // Throws BadRequestException if the updated data is invalid.
        public async Task<List<Product>> UpdateAsync(int id, Product updatedProduct)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                throw new NotFoundException("Product not found");
            }

            ValidateProduct(updatedProduct);

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        // DELETE PRODUCT
        // Removes a product from the database by ID.
        // Throws NotFoundException if the product does not exist.
        public async Task<List<Product>> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        // CENTRALIZED PRODUCT VALIDATION
        // Keeps validation rules in one place inside the service layer.
        private static void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new BadRequestException("Product name is required");
            }

            if (product.Price <= 0)
            {
                throw new BadRequestException("Product price must be greater than zero");
            }
        }
    }
}