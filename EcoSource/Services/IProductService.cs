using EcoSource.Model;

namespace EcoSource.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(int id);

       Task UpdateProduct(Product product);

        Task DeleteProduct(Product productId);

    }
}
