using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Base.DAL.Models.EF
{
    /// <summary>
    /// Encapsulates a DbContextTransaction
    /// </summary>
    public class DataContextTransaction : ITransaction
    {
        private readonly DbContextTransaction _transaction;

        /// <summary>
        /// Contstructor
        /// </summary>
        /// <param name="transaction"></param>
        public DataContextTransaction(DbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_transaction.UnderlyingTransaction.Connection != null)
            {
                // Pretty sure this gets done on Dispose anyway
                _transaction.Rollback();
            }
            _transaction.Dispose();
        }

        /// <summary>
        /// Commit all changes
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
        }

        /// <summary>
        /// Cancel all changes
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
        }
    }

    public class DataContext<TDbContext, TInterface> : IDataContext<TInterface> where TInterface : class
        where TDbContext : DbContext, TInterface
    {
        private readonly TDbContext _context;
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context"></param>
        public DataContext(TDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Save all outstanding changes sync
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Save all outstanding changes async
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Start a new transaction. Calls to savechanges will
        /// not take effect intil the transaction is commited
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var transaction = _context.Database.BeginTransaction(isolationLevel);
            return new DataContextTransaction(transaction);
        }

        /// <summary>
        /// Databse interface
        /// </summary>
        public TInterface Context
        {
            get { return _context; }
        }

    }
    
}
