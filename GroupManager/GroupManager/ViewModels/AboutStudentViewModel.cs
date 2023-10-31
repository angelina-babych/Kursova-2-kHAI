using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Core.Models;
using GroupManager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup.Localizer;

namespace GroupManager.ViewModels
{
    public enum Mode
    {
        Update,
        ReadOnly
    }
    public class AboutStudentViewModel:Screen
    {
        bool readOnlyTextBoxes;
        public bool ReadOnlyTextBoxes 
        { 
            get=>readOnlyTextBoxes;

            set
            {
                readOnlyTextBoxes = value;
                NotifyOfPropertyChange(() => ReadOnlyTextBoxes);
            } 
        }
        BindableCollection<string> allPriveleges;
        public BindableCollection<string> AllPriveleges
        {
            get => allPriveleges;
            set
            {
                allPriveleges = value;
                NotifyOfPropertyChange(() => AllPriveleges);
            }
        }
        BindableCollection<string> studentPriveleges;
        public BindableCollection<string> StudentPriveleges
        {
            get => studentPriveleges;
            set
            {
                studentPriveleges = value;
                NotifyOfPropertyChange(() =>StudentPriveleges);
            }
        }

        BindableCollection<Parents> parents;
        public BindableCollection<Parents> Parents 
        { 
            get=>parents;
            set
            {
                parents=value;
                NotifyOfPropertyChange(()=>Parents);
            } 
        
        }
        string currentAvatarPath;
        public string CurrentAvatarPath 
        {
            get
            {
                return currentAvatarPath;
            }

            set {
                currentAvatarPath = value;
                NotifyOfPropertyChange(nameof(CurrentAvatarPath));
            } 
        
        }
        Mode viewMode;
        public Mode ViewMode 
        {
            get
            {
                return viewMode;
            }

            set
            {
                viewMode = value;
                switch (viewMode)
                {
                    case Mode.Update:
                        {
                            UpdateVisibility = Visibility.Visible;
                            ReadonlyVisibility = Visibility.Collapsed;
                        }
                        break;
                    case Mode.ReadOnly:
                        {
                            UpdateVisibility = Visibility.Collapsed;
                            ReadonlyVisibility = Visibility.Visible;
                        }
                        break;
                }
                NotifyOfPropertyChange(nameof(ViewMode));
            }
        }
        string privilege;
        public string Privilege
        {
            get => privilege;
            set
            {
                privilege = value;
                NotifyOfPropertyChange(() => Privilege);
            }
        }

        Parents parent;
        public Parents Parent { 
            get=>parent;
            set
            {
                parent=value;
                NotifyOfPropertyChange(()=>Parent);
            }
        }
        public Group CurrentGroup { get; set; }

        Student currentStudent;
        public Student CurrentStudent {
            get=>currentStudent;
            set
            {
                currentStudent = value;
                CurrentAvatarPath =currentStudent.Avatar;
                //StudentPriveleges = new BindableCollection<string>
                //    (currentStudent.Privileges?.Select(x => x.Header));
                NotifyOfPropertyChange(nameof(CurrentStudent));
            } 
        
        }
        IRepository<Student> _studentRepository;
        IRepository<Parents> _parentsRepository;
        IRepository<Privilege> _privilegeRepository;

        Visibility updateVisibility;
        public Visibility UpdateVisibility
        {
            get => updateVisibility;
            set
            {
                updateVisibility = value;
                NotifyOfPropertyChange(nameof(UpdateVisibility));
            }
        }

        Visibility readonlyVisibility;
        public Visibility ReadonlyVisibility
        {
            get => readonlyVisibility;
            set
            {
                readonlyVisibility = value;
                NotifyOfPropertyChange(nameof(ReadonlyVisibility));
            }
        }

        Visibility addCertificate;
        public Visibility AddCertificate
        {
            get=> addCertificate;
            set
            {
                addCertificate = value;
                NotifyOfPropertyChange(nameof(AddCertificate));
            }
        }


        BindableCollection<Certificate> _certificates;
        public BindableCollection<Certificate> Certificates
        {
            get => _certificates;
            set
            {
                _certificates = value;
                NotifyOfPropertyChange(() => Certificates);
            }
        }

        Certificate currentCertificate;
        public Certificate CurrentCertificate 
        {
            get
            {
                return currentCertificate;
            }
            set
            {
                currentCertificate = value;
                NotifyOfPropertyChange(() => CurrentCertificate);
            }
        }






        public AboutStudentViewModel(
            IRepository<Student> _studentRepository, 
            IRepository<Parents> parentsRepository,
            IRepository<Privilege>privelegeRepository)
        {
            this._studentRepository = _studentRepository;
            this._privilegeRepository = privelegeRepository;
            CurrentStudent = new Student();
            Parent= new Parents();
            string path=Directory.GetCurrentDirectory();
            CurrentAvatarPath = path + "\\StudentsAvatars\\empty.png";
            
            _parentsRepository = parentsRepository;

            AllPriveleges = new BindableCollection<string>
                (_privilegeRepository.GetAll().Select(x => x.Header));
        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            if (ViewMode == Mode.Update)
                return;
            UploadCertificates();
        }



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


        private void UploadCertificates()
        {
            if (CurrentStudent != null)
            {
                Certificates = new BindableCollection<Certificate>(
                    _studentRepository.GetAll()
                    .Include(x => x.Certificates)
                    .Where(x => x.Id == CurrentStudent.Id).First()?.Certificates);

               
            }
        }







        public void Back()
        {
            var studentsListView = IoC.Get<StudentsListViewModel>();
            studentsListView.CurrentGroup = CurrentGroup;
            Switcher.SwitchAsync(studentsListView,new System.Threading.CancellationToken());
        }
        public void UploadAvatar()
        {
            if (ViewMode == Mode.Update)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png";

                if ((bool)openFileDialog.ShowDialog())
                {
                    CurrentAvatarPath = openFileDialog.FileName;
                }
            }
        }
        public void AddParent()
        {
            if (CurrentStudent.Id == Guid.Empty)
            {
                if (Parents is null)
                {
                    Parents = new BindableCollection<Parents>();
                }
                Parents.Add(Parent);
                Parent = new Parents();

            }
            else
            {
                //if (CurrentStudent.Id == Guid.Empty)
                //{
                //    CurrentStudent.Id = Guid.NewGuid();
                //    CurrentStudent.GroupId = CurrentGroup.Id;
                //    _studentRepository.Add(CurrentStudent);
                //}
                if (Parents is null)
                {
                    Parents = new BindableCollection<Parents>();
                }
                Parents.Add(Parent);
                Parent.Id = Guid.NewGuid();
                Parent.StudentId = CurrentStudent.Id;
                _parentsRepository.Add(Parent);

                Parent = new Parents();
            }
        }
        public void AddPrivelege()
        {
            if (CurrentStudent.Id == Guid.Empty)
            {
                if (StudentPriveleges is null)
                {
                    StudentPriveleges = new BindableCollection<string>();
                }
                StudentPriveleges.Add(Privilege);
                Privilege = "";
            }
            else
            {

                //if (CurrentStudent.Id == Guid.Empty)
                //{
                //    CurrentStudent.Id = Guid.NewGuid();
                //    CurrentStudent.GroupId = CurrentGroup.Id;
                //    _studentRepository.Add(CurrentStudent);
                //    CurrentStudent.Privileges= new List<Privilege>();
                //}
                if (StudentPriveleges is null)
                {
                    StudentPriveleges = new BindableCollection<string>();
                }
                StudentPriveleges.Add(Privilege);
                var priv = _privilegeRepository.GetAll()
                    .Include(x => x.Students)
                    .FirstOrDefault(x => x.Header == Privilege);
                if (priv is null)
                    return;
                priv.Students.Add(CurrentStudent);
                CurrentStudent.Privileges.Add(priv);
                _privilegeRepository.Update(priv);
                _studentRepository.Update(CurrentStudent);
                Privilege = "";
            }
        }

        public void MoveToNext()
        {
            var students = _studentRepository.GetAll()
                .Include(x=>x.Parents)
                .Include(x=>x.Privileges)
                .Where(x => x.GroupId == CurrentGroup.Id)
                .ToArray();
            int index = Array.FindIndex(students, x => x.Id == CurrentStudent.Id);
            if (index == students.Length - 1)
                return;
            CurrentStudent = students[index + 1];
            Parents = new BindableCollection<Parents>(
                CurrentStudent.Parents);
            StudentPriveleges = new BindableCollection<string>(
                CurrentStudent.Privileges.Select(x => x.Header)
                );


        }
        public void MoveToPrevious()
        {
            var students = _studentRepository.GetAll()
                 .Include(x => x.Parents)
                .Include(x => x.Privileges)
                .Where(x => x.GroupId == CurrentGroup.Id)
                .ToArray();
            int index = Array.FindIndex(students, x => x.Id == CurrentStudent.Id);
            if (index == 0)
                return;
            CurrentStudent = students[index - 1];
            Parents = new BindableCollection<Parents>(
              CurrentStudent.Parents);
            StudentPriveleges = new BindableCollection<string>(
                CurrentStudent.Privileges.Select(x => x.Header)
                );
        }




        public void SaveStudent()
        {
            try
            {
                if (CurrentAvatarPath != CurrentStudent.Avatar)
                {
                    if (!string.IsNullOrEmpty(CurrentStudent.Avatar))
                    {
                       // File.Delete(CurrentStudent.Avatar);
                    }
                    string path = Path.GetFileName(CurrentAvatarPath);
                    string str=Directory.GetCurrentDirectory();
                    CurrentStudent.Avatar = $"{str}/StudentsAvatars/{path}";
                    File.Copy(CurrentAvatarPath, CurrentStudent.Avatar);
                }
            }
            catch { }
            if (CurrentStudent.Id == Guid.Empty)
            {
                CurrentStudent.Id = Guid.NewGuid();
                CurrentStudent.GroupId = CurrentGroup.Id;
                _studentRepository.Add(CurrentStudent);

                if (Parents != null)
                {
                    foreach(var item in Parents)
                    {
                        item.Id = Guid.NewGuid();
                        item.StudentId = CurrentStudent.Id;
                        _parentsRepository.Add(item);
                    }
                }
                if (StudentPriveleges != null)
                {
                    foreach(var item in StudentPriveleges)
                    {
                        var priv = _privilegeRepository.GetAll()
                                .Include(x => x.Students)
                                .FirstOrDefault(x => x.Header == item);
                        if (priv is null)
                            continue;
                        priv.Students.Add(CurrentStudent);
                        if(CurrentStudent.Privileges==null)
                            CurrentStudent.Privileges= new List<Privilege>();
                        CurrentStudent.Privileges.Add(priv);
                        _privilegeRepository.Update(priv);
                        _studentRepository.Update(CurrentStudent);
                    }
                }
                var backPage = IoC.Get<StudentsListViewModel>();
                backPage.CurrentGroup = CurrentGroup;
                Switcher.SwitchAsync(backPage, new System.Threading.CancellationToken());

            }
            else {
                _studentRepository.Update(CurrentStudent);
                ViewMode = Mode.ReadOnly;
                ReadOnlyTextBoxes = true;
            }
        }
        public void CreateCharacteristic()
        {
            var chooseCharacteristic=IoC.Get<ChooseCharacteristicViewModel>();
            chooseCharacteristic.CurrentGroup= CurrentGroup;
            chooseCharacteristic.CurrentStudent= CurrentStudent;
            Switcher.SwitchAsync(chooseCharacteristic, new System.Threading.CancellationToken());

            //var createCharacteristic = IoC.Get<CharacteristicFormViewModel>();
            //createCharacteristic.CurrentGroup = CurrentGroup;
            //createCharacteristic.CurrentStudent = CurrentStudent;
            //Switcher.SwitchAsync(createCharacteristic, new System.Threading.CancellationToken());
        }
        public void OpenEditMode()
        {
            ViewMode = Mode.Update;
            ReadOnlyTextBoxes = false;
        }

        public void OpenAddCertificate()
        {
            var addCertificatePage = IoC.Get<AboutCertificateViewModel>();
            addCertificatePage.CurrentGroup = CurrentGroup;
            addCertificatePage.CurrentStudent = CurrentStudent;
            addCertificatePage.ViewMode = Mode.Update;
            Switcher.SwitchAsync(addCertificatePage, new System.Threading.CancellationToken());
        }
        public void AboutCertificate()
        {
            if (CurrentCertificate != null)
            {
                var addCertificatePage = IoC.Get<AboutCertificateViewModel>();
                addCertificatePage.CurrentGroup = CurrentGroup;
                addCertificatePage.CurrentStudent = CurrentStudent;
                addCertificatePage.CurrentCertificate= CurrentCertificate;
                addCertificatePage.ViewMode = Mode.ReadOnly;
                addCertificatePage.ReadOnlyTextBoxes = true;
                Switcher.SwitchAsync(addCertificatePage, new System.Threading.CancellationToken());
            }
        }
    }
}
