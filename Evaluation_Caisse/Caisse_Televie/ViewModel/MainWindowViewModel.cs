using Caisse_Televie.Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Mediators;
using ToolBox.Patterns.MVVM.Commands;

namespace Caisse_Televie.ViewModel
{
    public class MainWindowViewModel : NavigationPage
    {
        private bool _Ischecked;

        public bool Ischecked
        {
            get {  return _Ischecked; }
            set { _Ischecked = value; RaisePropertyChanged();
            }
        }

        private ObservableCollection<ProduitViewModel> _Panier;
        public ObservableCollection<ProduitViewModel> Panier
        {
            get { return _Panier ?? (_Panier = new ObservableCollection<ProduitViewModel>()); }
        }

        private ICommand _BoissonBtn;
        public ICommand BoissonBtn
        {
            get { return _BoissonBtn ?? (_BoissonBtn = new RelayCommand(BoissonExec)); }
        }
        private ICommand _BiereBtn;
        public ICommand BiereBtn
        {
            get { return _BiereBtn ?? (_BiereBtn = new RelayCommand(BiereExec)); }
        }
        private ICommand _VinBtn;
        public ICommand VinBtn
        {
            get { return _VinBtn ?? (_VinBtn = new RelayCommand(VinExec)); }
        }
        private ICommand _BouffeBtn;
        public ICommand BouffeBtn
        {
            get { return _BouffeBtn ?? (_BouffeBtn = new RelayCommand(BouffeExec)); }
        }
        private void BouffeExec()
        {
            Mediator<NavigationPage>.Instance.Send(new BouffeViewModel());
        }

        private void VinExec()
        {
            Mediator<NavigationPage>.Instance.Send(new VinViewModel());
        }

        private void BiereExec()
        {
            Mediator<NavigationPage>.Instance.Send(new BiereViewModel());
        }

        private void BoissonExec()
        {
            Mediator<NavigationPage>.Instance.Send(new BoissonViewModel());
        }

        public MainWindowViewModel()
        {
            Mediator<NavigationPage>.Instance.Register(SwitchView);
            Mediator<NavigationPage>.Instance.Send(new BoissonViewModel());
        }
    }
}
