using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System.Linq.Expressions;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet?.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRange(IEnumerable<T> entity)

        {
            try
            {
                _dbSet.RemoveRange(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}