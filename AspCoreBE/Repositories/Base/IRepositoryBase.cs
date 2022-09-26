using AspCoreBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspCoreBE.Repositories.Base
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Return by expresssion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<T> Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Return all instances
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Get();

        /// <summary>
        /// Add new instance and returns it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Create(T entity);

        /// <summary>
        /// Update instance and resturns it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(T entity);
    }
}
