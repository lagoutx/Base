using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Base.DAL.Models
{
    /// <summary>
    /// Data Context interface for comunication with data persistant layer
    /// </summary>
    public interface IDataContext<out T> where T : class
    {
        /// <summary>
        /// Save outstanding changes 
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Save outstanding changes async
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Start a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Data context
        /// </summary>
        T Context { get; }
    }
    
    
}
