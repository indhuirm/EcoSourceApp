using EcoSource.Model;

namespace EcoSource.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product product);
        Task<Product> GetProductsById(int productId);
    }
}
