﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
