namespace Base.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseContext()
            : base("name=DefaultConnection")
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public BaseContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
