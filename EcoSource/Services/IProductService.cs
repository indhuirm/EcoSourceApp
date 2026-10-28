using EcoSource.Model;

namespace EcoSource.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<List<Product>> GetProductById(int productId);

       Task UpdateProduct(Product product);

        Task DeleteProduct(Product productId);

    }
}
