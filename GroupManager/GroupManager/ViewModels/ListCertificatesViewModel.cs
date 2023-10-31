using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Core.Models;
using GroupManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.ViewModels
{
    internal class ListCertificatesViewModel:Screen
    {
        public Group CurrentGroup { get; set; }
        IRepository<Student> _studentsRepository;
        IRepository<Certificate> _certificateRepository;
        IRepository<Parents> _parentsRepository;

        BindableCollection<Certificate> _certificates;
        public BindableCollection<Certificate> Certificates
        {
            get => _certificates;

            set
            {
                _certificates = value;
                NotifyOfPropertyChange(()=>Certificates);
            }

        }
        public Student CurrentStudent { get; set; }
        public Certificate CurrentCertificate { get; set; }
        public ListCertificatesViewModel(
            IRepository<Student> _studentsRepository,
            IRepository<Certificate> certificateRepository,
            IRepository<Parents> parentsRepository)
        {
            this._studentsRepository = _studentsRepository;
            _certificateRepository = certificateRepository;
            this._parentsRepository = parentsRepository;
        }
        private void UploadCertificates()
        {
            if (CurrentStudent != null)
            {
                Certificates = new BindableCollection<Certificate>(
                    _studentsRepository.GetAll()
                    .Include(x => x.Certificates)
                    .Where(x => x.Id == CurrentStudent.Id).First().Certificates);

                //var priv = Students[0].Privileges;
            }
        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            UploadCertificates();
        }

        //public bool CanSearchByLastName(string lastname)
        //{
        //    return //!string.IsNullOrEmpty(lastname);
        //}

        public async void SearchByCertificateName(string str)
        {
            if (str == String.Empty)
            {
                Certificates = new BindableCollection<Certificate>(
                        (await _certificateRepository.GetAllAsync()));

            }
            else
            {
                Certificates = new BindableCollection<Certificate>(
                        (await _certificateRepository.GetAllAsync())
                        .Where(x => x.Header.ToLower().Contains(str.ToLower()))
                    );
            }
        }
        public void AddNewCertificates()
        {
            var addCertificatePage = IoC.Get<AboutCertificateViewModel>();
            addCertificatePage.ViewMode = Mode.Update;
            addCertificatePage.CurrentGroup = CurrentGroup;
            addCertificatePage.CurrentStudent = CurrentStudent;
            addCertificatePage.CurrentCertificate = CurrentCertificate;
            Switcher.SwitchAsync(addCertificatePage, new System.Threading.CancellationToken());
            //var aboutStudentViewModel = IoC.Get<AboutStudentViewModel>();
            //aboutStudentViewModel.ViewMode = Mode.Update;
            //aboutStudentViewModel.CurrentGroup = CurrentGroup;
            //aboutStudentViewModel.ReadOnlyTextBoxes = false;
            //Switcher.SwitchAsync(aboutStudentViewModel, new System.Threading.CancellationToken());
        }
        //public void AboutStudent()
        //{
        //    if (SelectedStudent != null)
        //    {
        //        var aboutStudentViewModel = IoC.Get<AboutStudentViewModel>();
        //        aboutStudentViewModel.ViewMode = Mode.ReadOnly;
        //        aboutStudentViewModel.CurrentStudent = SelectedStudent;
        //        aboutStudentViewModel.CurrentGroup = CurrentGroup;
        //        aboutStudentViewModel.StudentPriveleges = new BindableCollection<string>
        //            (SelectedStudent.Privileges.Select(x => x.Header));
        //        aboutStudentViewModel.Parents = new BindableCollection<Parents>(
        //                _parentsRepository.GetAll().Where(x => x.StudentId == SelectedStudent.Id));
        //        aboutStudentViewModel.ReadOnlyTextBoxes = true;
        //        Switcher.SwitchAsync(aboutStudentViewModel, new System.Threading.CancellationToken());
        //    }
        //}
        public void DeleteCertificate()
        {
            if (CurrentCertificate is null)
                return;
            var reqPage = IoC.Get<DeleteRequestCertificateViewModel>();
            reqPage.CurrentStudent = CurrentStudent;
            reqPage.CurrentGroup = CurrentGroup;
            reqPage.Certificate = CurrentCertificate;
            Switcher.SwitchAsync(reqPage, new System.Threading.CancellationToken());
        }

        //public void DeleteStudent()
        //{
        //    if (SelectedStudent is null)
        //        return;
        //    var req = IoC.Get<DeleteRequestViewModel>();
        //    req.CurrentStudent = SelectedStudent;
        //    req.CurrentGroup = CurrentGroup;
        //    Switcher.SwitchAsync(req, new System.Threading.CancellationToken());

        //    //if (SelectedStudent is null)
        //    //    return;

        //    //_studentsRepository.Delete(SelectedStudent);
        //    //Students = new BindableCollection<Student>(_studentsRepository.GetAll());
        //}
        public void Back()
        {
            var aboutStudentViewModel = IoC.Get<AboutStudentViewModel>();
            aboutStudentViewModel.ViewMode = Mode.ReadOnly;
            aboutStudentViewModel.CurrentStudent = CurrentStudent;
            aboutStudentViewModel.CurrentGroup = CurrentGroup;
            aboutStudentViewModel.StudentPriveleges = new BindableCollection<string>
                (CurrentStudent.Privileges.Select(x => x.Header));
            aboutStudentViewModel.Parents = new BindableCollection<Parents>(
                    _parentsRepository.GetAll().Where(x => x.StudentId == CurrentStudent.Id));
            aboutStudentViewModel.ReadOnlyTextBoxes = true;
            Switcher.SwitchAsync(aboutStudentViewModel, new System.Threading.CancellationToken());
        }
    }
}
