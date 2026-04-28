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
        // Retrieves all products from the database
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        // GET PRODUCT BY ID
        // Retrieves a single product based on its ID
        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        // CREATE PRODUCT
        // Validates input and saves a new product into the database
        public ServiceResult Create(Product product)
        {
            // Validation: Name must not be empty
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product name is required"
                };
            }

            // Validation: Price must be greater than zero
            if (product.Price <= 0)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product price must be greater than zero"
                };
            }

            // Add product to database
            _context.Products.Add(product);

            // Persist changes to database
            _context.SaveChanges();

            return new ServiceResult
            {
                Success = true,
                Message = "Product created successfully",
                Products = _context.Products.ToList()
            };
        }

        // UPDATE PRODUCT
        // Updates an existing product based on its ID
        public ServiceResult Update(int id, Product updatedProduct)
        {
            // Find existing product
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);

            // If product does not exist
            if (existingProduct == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            // Validation: Name must not be empty
            if (string.IsNullOrWhiteSpace(updatedProduct.Name))
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product name is required"
                };
            }

            // Validation: Price must be greater than zero
            if (updatedProduct.Price <= 0)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product price must be greater than zero"
                };
            }

            // Update fields
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            // Save changes
            _context.SaveChanges();

            return new ServiceResult
            {
                Success = true,
                Message = "Product updated successfully",
                Products = _context.Products.ToList()
            };
        }

        // DELETE PRODUCT
        // Removes a product from the database based on its ID
        public ServiceResult Delete(int id)
        {
            // Find product
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            // If product does not exist
            if (product == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            // Remove product from database
            _context.Products.Remove(product);

            // Save changes
            _context.SaveChanges();

            return new ServiceResult
            {
                Success = true,
                Message = "Product deleted successfully",
                Products = _context.Products.ToList()
            };
        }
    }
}