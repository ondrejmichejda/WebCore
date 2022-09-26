using AspCoreBE.Models;
using System.Collections.Generic;

namespace AspCoreBE.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Return single instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id);

        /// <summary>
        /// Return all instances
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get();

        /// <summary>
        /// Add new instance and returns it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Add(T data);

        /// <summary>
        /// Update instance and resturns it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Update(T data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
