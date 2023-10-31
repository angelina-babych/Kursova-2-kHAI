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
    public class IndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridRow item = value as DataGridRow;
            DataGrid listView = ItemsControl.ItemsControlFromItemContainer(item) as DataGrid;
            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
            return (index + 1).ToString()+". ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

