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
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();

        }
    }
}
