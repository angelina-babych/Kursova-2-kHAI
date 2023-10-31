using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Core.Models;
using GroupManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.ViewModels
{
    public class DeleteRequestCertificateViewModel:Screen
    {
        public Student CurrentStudent { get; set; }
        public Group CurrentGroup { get; set; }
        public Certificate Certificate { get; set; }
        IRepository<Student> studentRepository;
        IRepository<Certificate> certificateRepo;
        IRepository<Parents> parentsRepository;
        public DeleteRequestCertificateViewModel(IRepository<Student> _student,
            IRepository<Certificate>_certificateRepository,
            IRepository<Parents> parentsRepository)
        {
            this.studentRepository = _student;
            this.certificateRepo = _certificateRepository;
            this.parentsRepository = parentsRepository;
        }
        public void DeleteCertificate()
        {
            if (Certificate is null)
                return;

            certificateRepo.Delete(Certificate);
            ReturnBack();
        }
        public void ReturnBack()
        {
            var aboutStudentViewModel = IoC.Get<AboutStudentViewModel>();
            aboutStudentViewModel.ViewMode = Mode.ReadOnly;
            aboutStudentViewModel.CurrentStudent = CurrentStudent;
            aboutStudentViewModel.CurrentGroup = CurrentGroup;
            aboutStudentViewModel.StudentPriveleges = new BindableCollection<string>
                (CurrentStudent.Privileges.Select(x => x.Header));
            aboutStudentViewModel.Parents = new BindableCollection<Parents>(
                    parentsRepository.GetAll().Where(x => x.StudentId == CurrentStudent.Id));
            aboutStudentViewModel.ReadOnlyTextBoxes = true;
            Switcher.SwitchAsync(aboutStudentViewModel, new System.Threading.CancellationToken());
        }
    }
}
