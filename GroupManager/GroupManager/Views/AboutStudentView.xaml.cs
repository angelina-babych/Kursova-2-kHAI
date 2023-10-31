using GroupManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AboutStudentView.xaml
    /// </summary>
    public partial class AboutStudentView : UserControl
    {
        int previousIndex = -1;
        public AboutStudentView()
        {
            InitializeComponent();
        }

        private void AddParent_Click(object sender, RoutedEventArgs e)
        {
            this.AddStudentParents.IsChecked = false;
            var dt = DataContext as AboutStudentViewModel;
            dt.AddParent();
            //ParentsForm.Height= 0;
        }

        private void AddPrivelege_Click(object sender, RoutedEventArgs e)
        {
            this.AddPrivelegesButton.IsChecked = false;
            var dt = DataContext as AboutStudentViewModel;
            dt.AddPrivelege();
        }

        private void StudentsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as StudentsListViewModel;
            dataContext.AboutStudent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = (mainTab.SelectedItem as TabItem);
                if (item != null)
                {
                    var dc = (DataContext as AboutStudentViewModel);
                    int index = mainTab.SelectedIndex;
                    if (index != previousIndex)
                    {
                        if (index == 0)
                        {
                            dc.AddCertificate = Visibility.Collapsed;
                            if (dc.ViewMode == Mode.Update)
                            {
                                dc.ReadonlyVisibility = Visibility.Collapsed;
                                dc.UpdateVisibility = Visibility.Visible;
                            }
                            else
                            {
                                dc.ReadonlyVisibility = Visibility.Visible;
                                dc.UpdateVisibility = Visibility.Collapsed;
                            }
                        }
                        else if (index == 1)
                        {
                            if (dc.ViewMode == Mode.ReadOnly)
                            {
                                dc.AddCertificate = Visibility.Visible;
                                dc.ReadonlyVisibility = Visibility.Collapsed;
                                dc.UpdateVisibility = Visibility.Collapsed;
                            }
                            else
                            {
                                dc.AddCertificate = Visibility.Collapsed;
                                dc.ReadonlyVisibility = Visibility.Collapsed;
                                dc.UpdateVisibility = Visibility.Collapsed;
                            }
                        }
                        previousIndex = index;
                    }
                }
            }
            catch(Exception ex) { }

        }

        private void StudentsList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as AboutStudentViewModel;
            dataContext.AboutCertificate();
        }

        private void Lost_focus(object sender, KeyEventArgs e)
        {
            
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox input = (sender as TextBox);
            string pattern = @"^(0[1-9]|1[0-9]|2[0-9]|3[01])\.(0[1-9]|1[012])\.((19|20)\d\d)$";
            bool isValidDate = Regex.IsMatch(input.Text, pattern);
            if (!isValidDate)
            {
                input.Text = "дд.мм.рррр";
                input.Foreground = Brushes.Gray;
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox input = (sender as TextBox);
            string pattern = @"^\d{10}$";
            bool isValidDate = Regex.IsMatch(input.Text, pattern);
            if (!isValidDate)
            {
                input.Text = "";
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DateOfBirth.Text == "дд.мм.рррр")
            {
                DateOfBirth.Foreground = Brushes.Gray;
            }
            if (PassportEndDate.Text == "дд.мм.рррр")
            {
                PassportEndDate.Foreground= Brushes.Gray;
            }
            if (PassportIssueDate.Text == "дд.мм.рррр")
            {
                PassportIssueDate.Foreground = Brushes.Gray;
            }
            
        }

        private void DateOfBirth_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox=sender as TextBox;
            if(textBox.Text== "дд.мм.рррр")
            {
                textBox.Text = "";
                textBox.Foreground= Brushes.Black;
            }

        }
    }
}
