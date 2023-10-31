using GroupManager.Core.Model;
using GroupManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class StudentRepository :GenericRepository<Student>,IStudentsRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
            
        }

        public IQueryable<Student> GetStudentsFromGroup(Guid groupId)
        {
            return table.Where(s => s.GroupId == groupId);
        }
    }
}
