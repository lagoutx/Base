using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Base.DAL.Models.EF
{
    /// <summary>
    /// Basic repository class for a database context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitOfWork<T> : IDataContext<T> where T : DbContext
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="dataContext"></param>
        public UnitOfWork(IDataContext<T> dataContext)
        {
            DataContext = dataContext;
        }

        /// <summary>
        /// Save all pending changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DataContext.SaveChanges();
        }

        /// <summary>
        /// Saves all pending changes async
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return DataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Start a new transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return DataContext.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Underlying context
        /// </summary>
        public T Context
        {
            get { return DataContext.Context; }
        }

        /// <summary>
        /// Database context
        /// </summary>
        public IDataContext<T> DataContext { get; set; }
    }
}
