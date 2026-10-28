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
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products); // create 200 response , serialization concerting json kesterl swagger display
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {

            var products = await _productService.GetProducts();

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            return Ok(product); // Return the found product with a 200 response
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {

            var products = await _productService.GetProducts();
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            if (!TryValidateModel(existingProduct))
            {
                // Update the existing product with the values from the updatedProduct
                return ValidationProblem(ModelState);
            }
            existingProduct.product_name = updatedProduct.product_name;
            await _productService.UpdateProduct(existingProduct);
            return Ok(existingProduct); // Return the updated product with a 200 response
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            ArgumentNullException.ThrowIfNull(patchDoc);

            var existingProduct =
        await _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            if (!TryValidateModel(existingProduct))
            {
                // Update the existing product with the values from the updatedProduct
                return ValidationProblem(ModelState);
            }
            patchDoc.ApplyTo(existingProduct); // Apply the patch to the existing product
           
            await _productService.UpdateProduct(existingProduct);

            return Ok(existingProduct); // Return the patched product with a 200 response
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var products = await _productService.GetProducts();

            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(); // Return a 404 response if the product is not found
            }
            products.Remove(existingProduct); // Remove the existing product from the list
            await _productService.DeleteProduct(existingProduct);
            return NoContent(); // Return a 204 response indicating successful deletion
        }
    }
}
