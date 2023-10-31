using GroupManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
    /// Interaction logic for StudentsListView.xaml
    /// </summary>
    public partial class StudentsListView : UserControl
    {
        public StudentsListView()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            placeholderTextBlock.Visibility= Visibility.Collapsed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox=sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                placeholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void placeholderTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock=sender as TextBlock;
            textBlock.Visibility= Visibility.Collapsed;
            searchTextBox.Focus();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StudentsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as StudentsListViewModel;
            dataContext.AboutStudent();
        }
    }
}
