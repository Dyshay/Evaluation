using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Commands;
using ToolBox.Patterns.Mediators;
using ToolBox.Patterns.MVVM.Commands;

namespace Caisse_Televie.ViewModel
{
    public class ProduitViewModel : NavigationPage
    {
        private int _ProduitId;

        public int ProduitId
        {
            get { return _ProduitId; }
            set { _ProduitId = value; }
        }
        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }
        private double _Prix;

        public double Prix
        {
            get { return _Prix; }
            set { _Prix = value;RaisePropertyChanged(); }
        }
        private int _CategorieId;

        public int CategorieId
        {
            get { return _CategorieId; }
            set { _CategorieId = value; }
        }
        private int _Quantite;

        public int Quantite
        {
            get { return _Quantite; }
            set {
                _Quantite = value;
                RaisePropertyChanged();
            }
        }
        private double _TestPrix;

        public double TestPrix
        {
            get { return _TestPrix; }
            set { _TestPrix = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<ProduitViewModel> _ListGlobal;
        public ObservableCollection<ProduitViewModel> ListGlobal
        {
            get { return _ListGlobal ?? (_ListGlobal = new ObservableCollection<ProduitViewModel>()); }
        }

        private ICommand _Test;
        public ICommand Test
        {
            get { return _Test ?? (_Test = new RelayCommandPara(param => TestExec(param))); }
        }

        private void TestExec(object param)
        {
            Mediator<int>.Instance.Send((int)param);
        }
    }
}
