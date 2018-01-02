using OmegaInc.MultiPorpose.Data.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmegaInc.Common.Repository.Entity;
using System.Data.Entity;

namespace OmegaInc.MultiPorpose.Repository.Entity.Example
{
    public class UserRepository : GenericRepositoryEntity<User, int>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
