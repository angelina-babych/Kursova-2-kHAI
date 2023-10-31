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
    public class ChooseCharacteristicViewModel:Screen
    {
        IRepository<Parents> _parentsRepository;
        public Group CurrentGroup { get; set; }
        public Student CurrentStudent { get; set; }
        public CharacteristicMode ModeCh { get; set; }

        public ChooseCharacteristicViewModel(IRepository<Parents>_parents)
        {
            _parentsRepository = _parents;
        }
        public void MilitaryMode()
        {
            ModeCh = CharacteristicMode.ForMilitary;
            OpenCharacteristicView();

        }
        public void PromMode()
        {
            ModeCh = CharacteristicMode.ForProm;
            OpenCharacteristicView();
        }

        public void OpenCharacteristicView()
        {
            var createCharacteristic = IoC.Get<CharacteristicFormViewModel>();
            createCharacteristic.CurrentGroup = CurrentGroup;
            createCharacteristic.CurrentStudent = CurrentStudent;
            createCharacteristic.ModeCh = ModeCh;
            Switcher.SwitchAsync(createCharacteristic, new System.Threading.CancellationToken());
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
    }
}
