using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToolBox.Patterns.Commands;
using ToolBox.Patterns.Mediators;
using ToolBox.Patterns.MVVM.Commands;

namespace Caisse_Televie.ViewModel
{
    public class BoissonViewModel : NavigationPage
    {
        private ObservableCollection<ProduitViewModel> _ProductList;
        public ObservableCollection<ProduitViewModel> ProductList
        {
            get { return _ProductList ?? (_ProductList = new ObservableCollection<ProduitViewModel>()); }
        }

        private ICommand _Test;
        public ICommand Test
        {
            get { return _Test ?? (_Test = new RelayCommandPara(param => TestExec(param))); }
        }

        private void TestExec(object ProductId)
        {
            Mediator<int>.Instance.Send((int)ProductId);
        }

        public BoissonViewModel()
        {
            Locator.Instance.Liste.RecuperationProduit(ProductList,2);
        }
    }
}
