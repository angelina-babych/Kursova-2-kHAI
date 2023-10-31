using Caliburn.Micro;
using GroupManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroupManager.ViewModels
{
    public class AboutViewModel:Screen
    {
        public void Back()
        {
            var mainViewModel = IoC.Get<MainViewModel>();
            Switcher.SwitchAsync(mainViewModel, new CancellationToken());
        }
    }
}
