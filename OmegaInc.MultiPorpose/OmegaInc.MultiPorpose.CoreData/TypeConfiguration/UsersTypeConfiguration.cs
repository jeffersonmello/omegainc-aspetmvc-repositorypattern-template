using OmegaInc.Common.Entity;
using OmegaInc.MultiPorpose.Data.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaInc.MultiPorpose.CoreData.TypeConfiguration
{
    public class UsersTypeConfiguration : OmegaIncEntityAbstractConfig<User>
    {
        #region Protected Methods

        protected override void ConfigureFieldsTable()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("guid");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("name");

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");
        }

        protected override void ConfigureFK()
        {
           
        }

        protected override void ConfigurePK()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigureTableName()
        {
            ToTable("users");
        }

        #endregion
    }
}
