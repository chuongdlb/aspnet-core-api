using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NetcoreMvc.EntityFrameworkCore.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class  {
    
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}