using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Interfaces
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
