﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<bool> Delete(TEntity entityToDelete);
        Task<bool> Delete(object id);
        Task<ICollection<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> Get(object id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entityToUpdate);
        
    }
}
