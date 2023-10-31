using GroupManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupManager.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void GroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                var mainViewModel = (DataContext as MainViewModel);
                mainViewModel.AddGroup();
                AddGroupToggleButton.IsChecked = false;
            }
        }

        private void OpenTextBoxUpdateGroup(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (DataContext as MainViewModel);
            mainViewModel.GroupName = mainViewModel.SelectedGroup.Name;
            AddGroupToggleButton.IsChecked = true;
        }

        private void AddGroupToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (DataContext as MainViewModel);
            mainViewModel.GroupName = "";
            mainViewModel.SelectedGroup = null;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (DataContext as MainViewModel);
            mainViewModel.RemoveGroup();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void DataGridTextColumn_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
