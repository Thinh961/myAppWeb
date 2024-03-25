using MyApp.Models;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //bool AddCategory(Category entity);
        void Update(Category category);

    }
}