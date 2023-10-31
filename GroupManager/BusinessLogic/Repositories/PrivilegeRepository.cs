using GroupManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class PrivilegeRepository : GenericRepository<Privilege>
    {
        public PrivilegeRepository(DbContext context) : base(context)
        {
        }
    }
}
