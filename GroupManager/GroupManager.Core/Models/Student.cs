using GroupManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Model
{
    public enum PlaceType
    {
        City,
        Country
    }
    public class Student
    {
        public Guid Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; } = "дд.мм.рррр";
        public string Gender { get; set; }  
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssueDate { get; set; } = "дд.мм.рррр";
        public string PassportEndDate { get; set; } = "дд.мм.рррр";
        public string IdentificationCode { get; set; }
        public string Note { get; set; }
        public string PromYear { get; set; }
        public string StartStudyYear { get; set; }
        public string PlaceLiveType { get; set; }
        public string Dormitory { get; set; }
        public string AverageGrade { get; set; }


        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public virtual IList<Certificate> Certificates { get; set; }
        public IList<Parents> Parents { get; set; }
        public IList<Privilege> Privileges { get; set; }
    
    }
}
