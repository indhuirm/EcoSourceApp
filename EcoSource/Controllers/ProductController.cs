using EcoSource.Model;
using EcoSource.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EcoSource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService? _productService;

        public ProductController(IProductService? productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products); // create 200 response , serialization concerting json kesterl swagger display
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
          
            var products = _productService.GetProducts();

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            return Ok(product); // Return the found product with a 200 response
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
           
            var products = _productService.GetProducts();
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            // Update the existing product with the values from the updatedProduct
            existingProduct.product_name = updatedProduct.product_name;
            return Ok(existingProduct); // Return the updated product with a 200 response
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            ArgumentNullException.ThrowIfNull(patchDoc);

            
            var products = _productService.GetProducts();
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            patchDoc.ApplyTo(existingProduct); // Apply the patch to the existing product
            return Ok(existingProduct); // Return the patched product with a 200 response
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
          
            var products = _productService.GetProducts();

            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            products.Remove(existingProduct); // Remove the existing product from the list
            return NoContent(); // Return a 204 response indicating successful deletion
        }
    }
}
