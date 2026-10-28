using EcoSource.Model;

namespace EcoSource.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcoDbContext _context;
        public ProductRepository(EcoDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            Product product = new Product { Id = 1, product_name = "Toothbrush" };
            var products = new List<Product>
            {
                new Product { Id = 1, product_name = "Toothbrush" },
                 new Product { Id = 5, product_name = "Toothpaste" },
                new Product { Id = 2, product_name = "Soap" },
                new Product { Id = 3, product_name = "Shampoo" },
                new Product { Id = 4, product_name = "Conditioner" },
                new Product { Id = 6, product_name = "Lotion" },
                new Product { Id = 7, product_name = "Deodorant" },
                new Product { Id = 8, product_name = "Sunscreen" },
                new Product { Id = 9, product_name = "Face Wash" },
                new Product { Id = 10, product_name = "Hand Sanitizer" },
                new Product { Id = 11, product_name = "Body Wash" },
                new Product { Id = 12, product_name = "Hair Gel" },
                new Product { Id = 13, product_name = "Hair Spray" }
            };

            return _context.products;
        }
    }
}
