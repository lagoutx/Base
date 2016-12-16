using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DAL.Models
{
    /// <summary>
    /// Represents a unit of work to be saved as a batch operation
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all pending changes synchronously
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Saves all pending changes asyncronously
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
