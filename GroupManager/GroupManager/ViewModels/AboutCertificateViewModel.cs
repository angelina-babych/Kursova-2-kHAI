using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Core.Models;
using GroupManager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupManager.ViewModels
{
    public class AboutCertificateViewModel:Screen
    {
        IRepository<Student> _studentsRepository;
        IRepository<Certificate> _certificateRepository;
        IRepository<Parents> _parentsRepository;
        bool readOnlyTextBoxes;

        public AboutCertificateViewModel(
            IRepository<Student>_studentRepository,
            IRepository<Certificate>_certificateRepository,
            IRepository<Parents>_parentsRepository
            )
        {
            this._studentsRepository = _studentRepository;
            this._certificateRepository= _certificateRepository;
            this._parentsRepository = _parentsRepository;
            CurrentCertificate = new Certificate();

            string path = Directory.GetCurrentDirectory();
            CurrentAvatarPath = path + "\\CertificatesAvatar\\empty.png";
        }
        public bool ReadOnlyTextBoxes
        {
            get => readOnlyTextBoxes;

            set
            {
                readOnlyTextBoxes = value;
                NotifyOfPropertyChange(() => ReadOnlyTextBoxes);
            }
        }
        string currentAvatarPath;
        public string CurrentAvatarPath
        {
            get
            {
                return currentAvatarPath;
            }

            set
            {
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
        public Group CurrentGroup { get; set; }
        public Student CurrentStudent { get; set; }
        Certificate currentCertificate;
        public Certificate CurrentCertificate 
        {
            get { 
                return currentCertificate;
            }

            set
            {
                currentCertificate = value;
                CurrentAvatarPath = currentCertificate.CertificatePhoto;
                NotifyOfPropertyChange(() => CurrentCertificate);
            }
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


        public void SaveStudent()
        {
            try
            {
                if (CurrentAvatarPath != CurrentCertificate.CertificatePhoto)
                {
                    string path = Path.GetFileName(CurrentAvatarPath);
                    string str = Directory.GetCurrentDirectory();
                    CurrentCertificate.CertificatePhoto = $"{str}/CertificatesAvatar/{path}";
                    File.Copy(CurrentAvatarPath, CurrentCertificate.CertificatePhoto);
                }
            }
            catch { }
            if (CurrentCertificate.Id == Guid.Empty)
            {
                CurrentCertificate.Id = Guid.NewGuid();
                CurrentCertificate.StudentId = CurrentStudent.Id;
                _certificateRepository.Add(CurrentCertificate);

                Back();
            }
            else
            {
                _certificateRepository.Update(CurrentCertificate);
                ViewMode = Mode.ReadOnly;
                ReadOnlyTextBoxes = true;
            }
        }

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
        public void OpenEditMode()
        {
            ViewMode = Mode.Update;
            ReadOnlyTextBoxes = false;
        }
    }
}
