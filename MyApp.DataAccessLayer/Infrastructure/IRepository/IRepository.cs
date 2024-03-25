using System.Linq.Expressions;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetT(Expression<Func<T, bool>> predicate);

        bool Add(T entity);

        bool Delete(T entity);

        bool DeleteRange(IEnumerable<T> entity);
    }
}