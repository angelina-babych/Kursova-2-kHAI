using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupManager.ViewModels
{
    public class RadioCharacteristicFormViewModel:Screen
    {
        public Group CurrentGroup { get; set; }
        public Student CurrentStudent { get; set; }
        public CharacteristicModel CharacteristicModel { get; set; }
        CharacteristicManager manager;


        CharacteristicMode mode;
        public CharacteristicMode ModeCh
        {
            get => mode;
            set
            {
                mode = value;
                if (mode == CharacteristicMode.ForMilitary)
                {
                    MilitaryVisibility = Visibility.Visible;
                    PromVisibility = Visibility.Collapsed;
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


        public RadioCharacteristicFormViewModel(CharacteristicManager manager) { 
            this.manager = manager;
        }
        public void Back()
        {
            var res = IoC.Get<CharacteristicFormViewModel>();
            res.CharacteristicModel= CharacteristicModel;
            res.CurrentGroup= CurrentGroup;
            res.CurrentStudent= CurrentStudent;
            res.ModeCh=ModeCh;
            Switcher.SwitchAsync(res, new System.Threading.CancellationToken());
        }
        public void CreateCharacteristic()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Doc file (.doc)|*.doc";
            if (saveFileDialog.ShowDialog() == true)
            {
                manager.CreateCharacteristic(CharacteristicModel,saveFileDialog.FileName);
            }
        }
    }
}
