using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DAL.Models
{
   public interface ITransaction : IDisposable
    {
        /// <summary>
        /// Comit all outstanding changes
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback all outstanding changes
        /// </summary>
        void Rollback();
    }
}
