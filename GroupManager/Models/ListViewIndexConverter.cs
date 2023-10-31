using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GroupManager.Models
{
    public class ListViewIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ListViewItem item = value as ListViewItem;
            ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
            return (index + 1).ToString() + ". ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
