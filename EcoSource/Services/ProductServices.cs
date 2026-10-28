using EcoSource.Data;
using EcoSource.Model;

namespace EcoSource.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       

        public Task DeleteProduct(Product productId)
        {
           // throw new NotImplementedException();
           return _productRepository.DeleteProduct(productId);
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetProductsById(productId);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();

        }

        public async Task UpdateProduct(Product product)
        {
             await _productRepository.UpdateProduct(product);
        }

      
    }
}
