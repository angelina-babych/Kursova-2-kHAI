using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace GroupManager.CustomControls
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
          
        }

        private void PART_PreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomCalendar_SelectionModeChanged(object sender, EventArgs e)
        {
            if(CustomCalendar.DisplayMode!=CalendarMode.Month)
            {
                var changeEvent = (sender as CalendarModeChangedEventArgs);
                CustomCalendar.DisplayMode = changeEvent.OldMode;
            }
        }

     
    }
}
