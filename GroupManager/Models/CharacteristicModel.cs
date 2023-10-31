using GroupManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Models
{
    public class CharacteristicModel
    {
        public Student Student { get; set; }
        public bool IsGoodStudent { get; set; }
        public string Name { get; set; }
        public string Lastname { get;set; }
        public string Patronymic { get; set; }
        public string StartStudyDate { get; set; }
        public string Specialization { get; set; }
        public string Course { get; set;}
        public string Group { get; set; }
        public List<string> StudentRecomendations { get; set; }=new List<string>();
        public string PhysicalCharacteristic { get; set; }
        public string Collective { get; set; }
        public string Behavior { get; set; }
        public string PoliceSituations { get; set; }
        public string LawAndOrderViolations { get; set; }
        public string AlchogolSituations { get; set; }
        public string ReadyToArmy { get; set; }
        public string Courses { get; set; }
        public string Director { get; set; } = "Олександр ПIТЯКОВ";
        public string Tutor { get; set; } = "Свiтлана ГРИЦЕНКО";

    }
}
