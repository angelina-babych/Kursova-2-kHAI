using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GroupManager.ViewModels
{
    internal class DeleteRequestViewModel:Screen
    {
        public Student CurrentStudent { get; set; }
        public Group CurrentGroup { get; set; }
        IRepository<Student> studentRepository;
        public DeleteRequestViewModel(IRepository<Student> _student)
        {
            this.studentRepository= _student;
        }
        public void DeleteStudent()
        {
            if (CurrentStudent is null)
                return;

            studentRepository.Delete(CurrentStudent);
            ReturnBack();
        }
        public void ReturnBack()
        {
            var studentsList = IoC.Get<StudentsListViewModel>();
            studentsList.CurrentGroup = CurrentGroup;
            Switcher.SwitchAsync(studentsList, new System.Threading.CancellationToken());
        }
    }
}
