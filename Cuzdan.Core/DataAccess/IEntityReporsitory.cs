﻿using Cuzdan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Core.DataAccess
{
    public interface IEntityReporsitory<T> 
        where T:class,IEntity,new()
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);

        T Update(T entity);
        Task<T> UpdateAsync(T entity);

        void Delete(T entity);
        Task DeleteAsync(T entity);

        T Get(Expression<Func<T, bool>>filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

    }
}
