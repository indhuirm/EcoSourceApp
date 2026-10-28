using EcoSource.Model;

using Microsoft.EntityFrameworkCore;

namespace EcoSource.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcoDbContext _context;
        public ProductRepository(EcoDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(int id)
        { 
            return await _context.Products.FindAsync(id); 
        }

        public async Task<List<Product>> GetProducts()
        {
            //Product product = new Product { Id = 1, product_name = "Toothbrush" };
            //var products = new List<Product>
            //{
            //    new Product { Id = 1, product_name = "Toothbrush" },
            //     new Product { Id = 5, product_name = "Toothpaste" },
            //    new Product { Id = 2, product_name = "Soap" },
            //    new Product { Id = 3, product_name = "Shampoo" },
            //    new Product { Id = 4, product_name = "Conditioner" },
            //    new Product { Id = 6, product_name = "Lotion" },
            //    new Product { Id = 7, product_name = "Deodorant" },
            //    new Product { Id = 8, product_name = "Sunscreen" },
            //    new Product { Id = 9, product_name = "Face Wash" },
            //    new Product { Id = 10, product_name = "Hand Sanitizer" },
            //    new Product { Id = 11, product_name = "Body Wash" },
            //    new Product { Id = 12, product_name = "Hair Gel" },
            //    new Product { Id = 13, product_name = "Hair Spray" }
            //};
            //return products;
            return await _context.Products.ToListAsync();
        }

       

        public async Task UpdateProduct(Product product)
        {
            // throw new NotImplementedException();
            await _context.SaveChangesAsync();
        }

        Task IProductRepository.AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return _context.SaveChangesAsync();
        }
    }
}
