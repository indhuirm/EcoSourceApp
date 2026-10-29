using EcoSource.Model;

namespace EcoSource.Services
{
    public interface ICategoryservice
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int categoryId); 
        void AddCategory(Category category);
        void UpdateCategory(Category category); 
        void DeleteCategory(int categoryId);



    }
}
