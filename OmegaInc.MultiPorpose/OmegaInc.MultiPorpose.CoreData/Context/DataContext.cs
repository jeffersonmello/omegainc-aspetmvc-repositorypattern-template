using OmegaInc.MultiPorpose.CoreData.TypeConfiguration;
using OmegaInc.MultiPorpose.Data.Example;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaInc.MultiPorpose.CoreData.Context
{
    public class DataContext : DbContext
    {
        #region Public Properties

        public DbSet<User> Users { get; set; }

        #endregion

        #region Public Constructors

        public DataContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Protected Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersTypeConfiguration());
        }
        #endregion
    }
}
