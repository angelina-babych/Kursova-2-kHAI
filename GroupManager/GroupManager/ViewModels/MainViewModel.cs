using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Model;
using GroupManager.Models;
using GroupManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GroupManager.ViewModels
{
    public class MainViewModel:Screen
    {
        IRepository<Group> _groupRepository;
        public UserControl CalendarItem { get; set; }
        BindableCollection<Group> _groups { get; set; }
        public BindableCollection<Group> Groups
        {
            get => _groups;
            set
            {
                _groups= value;
                NotifyOfPropertyChange(() => Groups);
            }
        }
        string groupName;
        public string GroupName
        {
            set
            {
                groupName= value;
                NotifyOfPropertyChange(() => GroupName);
            }
            get
            {
                return groupName;
            }
        }
        public string Date { get; set; }
        Group selectedGroup;
        public Group SelectedGroup { 
            get=>selectedGroup;
            set {
                selectedGroup = value;
                NotifyOfPropertyChange(() => SelectedGroup);
            }
        }
        public MainViewModel(
            IRepository<Group> repository)
        {
            string strDate = DateTime.UtcNow.ToString("dddd, dd MMMM");
            Date = char.ToUpper(strDate[0]) + strDate.Substring(1);
            _groupRepository = repository;
            CalendarItem = new CustomControls.Calendar();
            UploadGroups();
        }
        private async void UploadGroups()
        {
            var reverseList = (await _groupRepository.GetAllAsync())
                .ToArray()
                .Reverse();
            Groups=new BindableCollection<Group>(reverseList);
        }

        public async void AddGroup()
        {
            if (SelectedGroup == null)
            {
                Group newGroup = new Group
                {
                    Name = GroupName,
                    Id = Guid.NewGuid(),
                };
                _groupRepository.Add(newGroup);
                GroupName = "";
                Groups.Clear();
                var groupsList = (await _groupRepository.GetAllAsync())
                    .ToArray()
                    .Reverse();
                Groups.AddRange(groupsList);
            }
            else
            {
                SelectedGroup.Name=GroupName;
                _groupRepository.Update(SelectedGroup);
                Groups.Clear();
                var reverseList = (await _groupRepository.GetAllAsync())
                    .ToArray()
                    .Reverse();
                Groups.AddRange(reverseList);
            }
        }
        public async void RemoveGroup()
        {
            if (SelectedGroup != null)
            {
                await _groupRepository.RemoveAsync(SelectedGroup);
                Groups.Clear();
                var groupsList = (await _groupRepository.GetAllAsync())
                    .ToArray()
                    .Reverse();
                Groups.AddRange(groupsList);
            }
        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            //MainView shellView = (MainView)view;
            //shellView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete,RemoveGroup));
        }
        public void GroupClicked()
        {
            if (SelectedGroup != null)
            {
                var studentsList = IoC.Get<StudentsListViewModel>();
                studentsList.CurrentGroup = SelectedGroup;
                Switcher.SwitchAsync(studentsList, new System.Threading.CancellationToken());
            }
        }
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
           
        }
        public void ExitProgram()
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void AboutProgram()
        {
            var viewModel = IoC.Get<AboutViewModel>();
            Switcher.SwitchAsync(viewModel, new System.Threading.CancellationToken());
        }
    }
}
