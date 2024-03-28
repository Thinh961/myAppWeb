using System.Linq.Expressions;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties=null);

        T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null);

        bool Add(T entity);

        bool Delete(T entity);

        bool DeleteRange(IEnumerable<T> entity);
    }
}