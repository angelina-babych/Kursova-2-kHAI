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
    /// Interaction logic for AddCertificateView.xaml
    /// </summary>
    public partial class AboutCertificateView : UserControl
    {
        public AboutCertificateView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DateCertificate.Text == "дд.мм.рррр")
            {
                DateCertificate.Foreground = Brushes.Gray;
            }
        }

        private void DateCertificate_LostFocus(object sender, RoutedEventArgs e)
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

        private void DateCertificate_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "дд.мм.рррр")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }
    }
}
