using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService
    {
        // Simulated in-memory database
        // NOTE: In a real-world application, this would be replaced by a database (SQL, NoSQL, etc or Any Database)
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Phone", Price = 800 },
            new Product { Id = 3, Name = "Keyboard", Price = 100 }
        };


        // GET ALL PRODUCTS Method applied on products


        public List<Product> GetAll()
        {
            // Returns the full list of products
            return products;
        }


        // GET METHOD applied on product BY ID 
        
        public Product? GetById(int id)
        {
            // Searches for a product by its ID
            // Returns null if is not found
            return products.FirstOrDefault(p => p.Id == id);
        }


        //  POST METHOD applied on products
        public (bool Success, string Message, List<Product>? Products) Create(Product product)
        {
            // VALIDATION 1: Name cannot be empty
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return (false, "Product name cannot be empty", null);
            }

            // VALIDATION 2: Price must be greater than zero
            if (product.Price <= 0)
            {
                return (false, "Product price must be greater than zero", null);
            }

            // VALIDATION 3: Prevent duplicate IDs
            if (products.Any(p => p.Id == product.Id))
            {
                return (false, "A product with this ID already exists", null);
            }

            // If all validations pass, add the product
            products.Add(product);

            // Return success with updated list
            return (true, "Product created successfully", products);
        }

        
        // PUT PRODUCT METHOD applied on products
       
        public (bool Success, string Message, List<Product>? Products) Update(int id, Product updatedProduct)
        {
            // Find existing product
            var product = products.FirstOrDefault(p => p.Id == id);

            // If not found → return error
            if (product == null)
            {
                return (false, "Product not found", null);
            }

            // VALIDATION: Name
            if (string.IsNullOrWhiteSpace(updatedProduct.Name))
            {
                return (false, "Product name cannot be empty", null);
            }

            // VALIDATION: Price
            if (updatedProduct.Price <= 0)
            {
                return (false, "Product price must be greater than zero", null);
            }

            // Apply updates
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return (true, "Product updated successfully", products);
        }


        // DELETE PRODUCT METHOD applied on products


        public (bool Success, string Message, List<Product>? Products) Delete(int id)
        {
            // Find product
            var product = products.FirstOrDefault(p => p.Id == id);

            // If not found → error
            if (product == null)
            {
                return (false, "Product not found", null);
            }

            // Remove product from list
            products.Remove(product);

            return (true, "Product deleted successfully", products);
        }
    }
}