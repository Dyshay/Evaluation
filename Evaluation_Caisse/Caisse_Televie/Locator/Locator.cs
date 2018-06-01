using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Locator;

namespace Caisse_Televie.ViewModel
{
    public class Locator : LocatorBase
    {
        private static Locator _Instance;
        public static Locator Instance
        {
            get { return _Instance ?? (_Instance = new Locator()); }
        }
        private Locator()
        {
            Container.Register<ListeProduits>();
            Container.Register<MainWindowViewModel>();
            Container.Register<ProduitViewModel>();
            Container.Register<BoissonViewModel>();
            Container.Register<PanierViewModel>();
            Container.Register<HistoriqueViewModel>();
        }
        public BoissonViewModel Boisson
        {
            get { return Container.GetInstance<BoissonViewModel>(); }
        }
        public ListeProduits Liste
        {
            get { return Container.GetInstance<ListeProduits>(); }
        }
        public PanierViewModel Panier
        {
            get { return Container.GetInstance<PanierViewModel>(); }
        }
        public ProduitViewModel Produit
        {
            get { return Container.GetInstance<ProduitViewModel>(); }
        }
        public MainWindowViewModel Main
        {
            get { return Container.GetInstance<MainWindowViewModel>(); }
        }
        public HistoriqueViewModel Historique
        {
            get { return Container.GetInstance<HistoriqueViewModel>(); }
        }
    }
}
