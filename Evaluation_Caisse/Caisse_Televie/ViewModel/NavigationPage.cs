using Caisse_Televie.Model.Client.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.MVVM.ViewModels;

namespace Caisse_Televie.ViewModel
{
    public class NavigationPage : ViewModelBase
    {
        private NavigationPage _CurrentView;
        public NavigationPage CurrentView
        {
            get { return _CurrentView; }
            set { _CurrentView = value; RaisePropertyChanged(); }
        }
        public void SwitchView(NavigationPage obj)
        {
            CurrentView = obj;
        }
    }
}
