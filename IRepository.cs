using System;

namespace Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        void Add(T entity);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        T GetById(int id);

        T GetByStringId(string id);
    }
}
