using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // LIST DEFINED 
        private static List<Product> products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Price = 1200 },
    new Product { Id = 2, Name = "Phone", Price = 800 },
    new Product { Id = 3, Name = "Keyboard", Price = 100 }
};

        // GET METHOD (devuelve una lista de objetos)
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // POST METHOD (Ahora debe recibir un Product)
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        // PUT METHOD
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct) 
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Producto no encontrado");
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return Ok(products);
        }



        //DELETE METHOD 
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Producto no encontrado");
            }

            products.Remove(product);

            return Ok(products);
        }


    }
}



// https://localhost:44356/swagger/index.html
// https://localhost:44356/api/product