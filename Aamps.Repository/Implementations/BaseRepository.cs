using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Aamps.Repository.Implementations
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public AampsContext _dbContext;

        public BaseRepository(AampsContext dbContext)
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

        public int Update(T entity, Expression<Func<T, object>>[] properties)
        {
            _dbContext.Entry(entity).State = EntityState.Unchanged;
            foreach (var property in properties)
            {
                var propertyName = ExpressionHelper.GetExpressionText(property);
                _dbContext.Entry(entity).Property(propertyName).IsModified = true;
            }
            return _dbContext.SaveChanges();
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
