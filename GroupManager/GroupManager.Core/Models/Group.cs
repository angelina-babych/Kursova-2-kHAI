using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Model
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
