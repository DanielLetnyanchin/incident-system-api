using IncidentSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentSystem.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;
        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            T existing = _dbContext.Set<T>().Find(entity);
            if (existing != null) _dbContext.Set<T>().Remove(existing);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return _dbContext.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Attach(entity);
            _dbContext.SaveChanges();
        }
    }
}
