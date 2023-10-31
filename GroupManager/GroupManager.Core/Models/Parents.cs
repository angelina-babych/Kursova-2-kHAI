using GroupManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Models
{
    public class Parents
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
