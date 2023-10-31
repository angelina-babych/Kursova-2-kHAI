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
using System.Windows;

namespace GroupManager.ViewModels
{
    public class CharacteristicFormViewModel:Screen
    {
        CharacteristicModel characteristic;
        public CharacteristicModel CharacteristicModel
        {
            get => characteristic;
            set
            {
                characteristic= value;
                NotifyOfPropertyChange(() => CharacteristicModel);
            }
        }
        public Group CurrentGroup { get; set; }
        Student currentStudent;
        public Student CurrentStudent
        {
            get
            {
                return currentStudent;
            }

            set
            {
                currentStudent= value;
                CharacteristicModel.Student= value;
                CharacteristicModel.Name=currentStudent.Name;
                CharacteristicModel.Lastname=currentStudent.Lastname;
                CharacteristicModel.Patronymic=currentStudent.Patronymic;
                CharacteristicModel.StartStudyDate = currentStudent.StartStudyYear;
                NotifyOfPropertyChange(() => CurrentStudent);
            }
        }
        CharacteristicMode mode;
        public CharacteristicMode ModeCh 
        {
            get => mode;
            set
            {
                mode= value;
                if (mode == CharacteristicMode.ForMilitary)
                {
                    MilitaryVisibility= Visibility.Visible;
                    PromVisibility= Visibility.Collapsed;
                }
                else
                {
                    MilitaryVisibility = Visibility.Collapsed;
                    PromVisibility = Visibility.Visible;
                }
                NotifyOfPropertyChange(() => ModeCh);
            }
        }

        Visibility militaryVisibility;
        public Visibility MilitaryVisibility
        {
            get => militaryVisibility;
            set
            {
                militaryVisibility = value;
                NotifyOfPropertyChange(nameof(MilitaryVisibility));
            }
        }

        Visibility promVisibility;
        public Visibility PromVisibility
        {
            get => promVisibility;
            set
            {
                promVisibility = value;
                NotifyOfPropertyChange(nameof(PromVisibility));
            }
        }

        IRepository<Student> _studRepos;
        IRepository<Parents> _parentsRepos;


        public CharacteristicFormViewModel(
            IRepository<Student> _studRepository,
            IRepository<Parents> _parRepository)
        {
            this._studRepos = _studRepository;
            this._parentsRepos = _parRepository;
            CharacteristicModel=new CharacteristicModel();

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
                    _parentsRepos.GetAll().Where(x => x.StudentId == CurrentStudent.Id));
            aboutStudentViewModel.ReadOnlyTextBoxes = true;
            Switcher.SwitchAsync(aboutStudentViewModel, new System.Threading.CancellationToken());
        }
        public void MoveToNext()
        {
            var radio = IoC.Get<RadioCharacteristicFormViewModel>();
            CharacteristicModel.Student = CurrentStudent;
            radio.CharacteristicModel = CharacteristicModel;
            radio.CurrentStudent = CurrentStudent;
            radio.CurrentGroup = CurrentGroup;
            radio.ModeCh = ModeCh;
            Switcher.SwitchAsync(radio, new System.Threading.CancellationToken());
        }
    }
}
