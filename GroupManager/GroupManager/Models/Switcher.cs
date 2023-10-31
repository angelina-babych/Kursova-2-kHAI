using Caliburn.Micro;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GroupManager.Models
{
    public class Switcher
    {
        public static Conductor<object> Conductor { get; set; }
        public static async void SwitchAsync(object item,CancellationToken token)
        {
            await Conductor?.ActivateItemAsync(item, token);
        }
        public static async void CloseItemAsync(object item, CancellationToken token,bool close)
        {
            await Conductor.DeactivateItemAsync(item, close, token);
           // Conductor.Deac
        }
    }
}
