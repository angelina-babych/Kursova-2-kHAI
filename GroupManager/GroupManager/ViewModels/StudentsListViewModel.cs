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
using System.Windows;

namespace GroupManager.ViewModels
{
    public class StudentsListViewModel:Screen
    {
        public Group CurrentGroup { get; set; }
        IRepository<Student> _studentsRepository;
        IRepository<Certificate> _certificateRepository;
        IRepository<Parents> _parentsRepository;

        BindableCollection<Student> _students;
        public BindableCollection<Student> Students 
        { 
            get=>_students;

            set { 
                _students= value;
                NotifyOfPropertyChange(nameof(Students));
            }
        
        }

        int selectedIndex;
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex=value;
                if (selectedIndex == 3)
                {
                    PlaceLiveVisibility = Visibility.Visible;
                }
                else PlaceLiveVisibility= Visibility.Hidden;

                if (selectedIndex == 2)
                {
                    EndPassportDateVisible = Visibility.Visible;
                }
                else EndPassportDateVisible=Visibility.Hidden;
                NotifyOfPropertyChange(nameof(SelectedIndex));
            }
        }
        int selectedFilterIndex;
        public int SelectedFilterIndex
        {
            get => selectedFilterIndex;
            set
            {
                selectedFilterIndex=value;
                if (selectedFilterIndex == 0)
                {
                    Students = new BindableCollection<Student>(
                            (_studentsRepository.GetAll())
                               .Where(x => x.PlaceLiveType.ToLower().Contains("Місто")));
                }
                else if (selectedFilterIndex == 1)
                {
                    Students = new BindableCollection<Student>(
                            (_studentsRepository.GetAll())
                               .Where(x => x.PlaceLiveType.ToLower().Contains("Село")));
                }
                NotifyOfPropertyChange(nameof(SelectedFilterIndex));
            }
        }
        Visibility endPassportDateVisible;
        public Visibility EndPassportDateVisible
        {
            get => endPassportDateVisible;
            set
            {
                endPassportDateVisible=value;
                NotifyOfPropertyChange(nameof(EndPassportDateVisible));
            }
        }
        Visibility placeLiveVisibility;
        public Visibility PlaceLiveVisibility
        {
            get=> placeLiveVisibility;
            set
            {
                placeLiveVisibility=value;
                NotifyOfPropertyChange(nameof(PlaceLiveVisibility));
            }
        }



        public Student SelectedStudent { get; set; }
        public StudentsListViewModel(
            IRepository<Student> _studentsRepository,
            IRepository<Certificate> certificateRepository,
            IRepository<Parents>parentsRepository)
        {
            this._studentsRepository = _studentsRepository;
            _certificateRepository = certificateRepository;
            this._parentsRepository = parentsRepository;
            SelectedIndex= 0;
            SelectedFilterIndex= -1;
        }
        private void UploadStudents()
        {
            if (CurrentGroup!=null)
            {
                Students = new BindableCollection<Student>(_studentsRepository.GetAll()
                    .Include(x => x.Privileges)
                    .Where(x=>x.GroupId==CurrentGroup.Id));
                //var priv = Students[0].Privileges;
            }
        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            UploadStudents();
        }

        //public bool CanSearchByLastName(string lastname)
        //{
        //    return //!string.IsNullOrEmpty(lastname);
        //}

        public async void SearchByLastName(string str)
        {
            if (str == String.Empty)
            {
                Students = new BindableCollection<Student>(
                        (await _studentsRepository.GetAllAsync()));
                return;
            }
            switch (SelectedIndex)
            {
                case 0:
                    {
                        Students = new BindableCollection<Student>(
                             (await _studentsRepository.GetAllAsync())
                                .Where(x => x.Lastname.ToLower().Contains(str.ToLower())));
                    }
                    break;
                case 1:
                    {
                        Students = new BindableCollection<Student>(
                            (await _studentsRepository.GetAllAsync())
                               .Where(x => x.DateOfBirth.Contains(str.ToLower())));
                    }
                    break;
                case 2:
                    {

                        Students = new BindableCollection<Student>(
                            (await _studentsRepository.GetAllAsync())
                               .Where(x => x.PassportEndDate.ToLower().Contains(str.ToLower())));
                    }
                    break;
            }
          
        }
        public void AddNewStudent()
        {
            var aboutStudentViewModel=IoC.Get<AboutStudentViewModel>();
            aboutStudentViewModel.ViewMode = Mode.Update;
            aboutStudentViewModel.CurrentGroup = CurrentGroup;
            aboutStudentViewModel.ReadOnlyTextBoxes = false;
            Switcher.SwitchAsync(aboutStudentViewModel,new System.Threading.CancellationToken());
        }
        public void AboutStudent()
        {
            if (SelectedStudent != null)
            {
                var aboutStudentViewModel = IoC.Get<AboutStudentViewModel>();
                aboutStudentViewModel.ViewMode = Mode.ReadOnly;
                aboutStudentViewModel.CurrentStudent = SelectedStudent;
                aboutStudentViewModel.CurrentGroup = CurrentGroup;
                aboutStudentViewModel.StudentPriveleges= new BindableCollection<string>
                    (SelectedStudent.Privileges.Select(x=>x.Header));
                aboutStudentViewModel.Parents = new BindableCollection<Parents>(
                        _parentsRepository.GetAll().Where(x => x.StudentId == SelectedStudent.Id));
                aboutStudentViewModel.ReadOnlyTextBoxes = true;
                Switcher.SwitchAsync(aboutStudentViewModel, new System.Threading.CancellationToken());
            }
        }


        public void DeleteStudent()
        {
            if (SelectedStudent is null)
                return;
            var req = IoC.Get<DeleteRequestViewModel>();
            req.CurrentStudent = SelectedStudent;
            req.CurrentGroup = CurrentGroup;
            Switcher.SwitchAsync(req,new System.Threading.CancellationToken());

            //if (SelectedStudent is null)
            //    return;
            
            //_studentsRepository.Delete(SelectedStudent);
            //Students = new BindableCollection<Student>(_studentsRepository.GetAll());
        }
        public void Back()
        {
            var mainViewModel=IoC.Get<MainViewModel>();
            Switcher.SwitchAsync(mainViewModel, new System.Threading.CancellationToken());
        }
        public void DisableFilters()
        {
            SelectedFilterIndex= -1;
            UploadStudents();
        }
    }
}
