using EcoSource.Model;

namespace EcoSource.Data
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
    }
}
