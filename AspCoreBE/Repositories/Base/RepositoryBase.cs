using AspCoreBE.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspCoreBE.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected WebCoreContext Context { get; set; }

        public RepositoryBase(WebCoreContext context)
        {
            Context = context;
        }

        public T Create(T entity)
        {
            return Context.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> Get()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public T Update(T entity)
        {
            return Context.Set<T>().Update(entity).Entity;
        }
    }
}
