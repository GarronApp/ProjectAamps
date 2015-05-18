using System;

namespace .Repositories.Implementations
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public AppContext _dbContext;

        public BaseRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);

        }

        public T GetByStringId(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}
