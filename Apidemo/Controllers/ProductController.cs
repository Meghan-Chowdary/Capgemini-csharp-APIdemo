using Apidemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace Apidemo.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000 },
            new Product { Id = 2, Name = "Phone", Price = 500 }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)

        {
            var product = products.FirstOrDefault(p => p.Id == id); if (product == null) return NotFound("Product not found"); return Ok(product);
        }
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            product.Id = products.Count + 1; products.Add(product); return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id); if (product == null) return NotFound("Product not found"); product.Name = updatedProduct.Name; product.Price = updatedProduct.Price; return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id); if (product == null) return NotFound("Product not found"); products.Remove(product); return NoContent();
        }
        //[HttpPost("Sample")] public ActionResult SampleProduct() { return "Sample"; }
    }
}