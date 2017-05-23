using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc.EntityFrameworkCore.Repositories
{
    public class GenericRepository<TEntity> :
        IGenericRepository<TEntity> where TEntity : class 

    {

    protected readonly ApplicationContext _context;

    protected readonly DbSet<TEntity> _entities;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public ApplicationContext Context
    {
        get { return _context; }
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);
        return query;
    }

    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Save()
    {
        _context.SaveChanges();
    }


    }

}