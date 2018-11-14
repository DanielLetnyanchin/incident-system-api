using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IncidentSystem.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
