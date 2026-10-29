using EcoSource.Model;

using Microsoft.EntityFrameworkCore;

namespace EcoSource.Services
{
    public class Categoryservice : ICategoryservice
    {
        private readonly EcoDbContext _context;
        public Categoryservice(EcoDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            // throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            _context.Categories.Remove(_context.Categories.FirstOrDefault(c => c.CategoryId == categoryId));
            _context.SaveChanges();
            // throw new NotImplementedException();
        }

        public async Task<List<Category>> GetCategories()
        {
           return await _context.Categories.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return  _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            // throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
