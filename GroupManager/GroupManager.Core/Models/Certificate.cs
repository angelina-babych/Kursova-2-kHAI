using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Model
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public string Publisher { get; set; }
        public string Date { get; set; } = "дд.мм.рррр";
        public string Institution { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string CertificatePhoto { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
