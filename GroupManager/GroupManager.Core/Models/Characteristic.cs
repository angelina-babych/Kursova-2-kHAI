using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Model
{
    public enum CharacteristicMode
    {
        ForMilitary,
        ForProm
    }
    public class Characteristic
    {
        public Guid Id { get; set; }
        public CharacteristicMode Type { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public string Institution { get; set; }
        public string Header { get; set; }
        public string Description { get; set; } 
        public Guid StudentId { get; set; }
    }
}
