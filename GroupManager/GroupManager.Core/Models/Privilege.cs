using GroupManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Models
{
    public class Privilege
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
