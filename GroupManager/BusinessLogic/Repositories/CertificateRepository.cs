using GroupManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class CertificateRepository:GenericRepository<Certificate>
    {
        public CertificateRepository(DbContext context):
            base(context) { }
    }
}
