using MyApp.Models;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        //bool AddCategory(Category entity);
        void Update(Product product);

    }
}