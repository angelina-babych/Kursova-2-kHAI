using GroupManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class ParentsRepository : GenericRepository<Parents>
    {
        public ParentsRepository(DbContext context) : base(context)
        {
        }
    }
}
