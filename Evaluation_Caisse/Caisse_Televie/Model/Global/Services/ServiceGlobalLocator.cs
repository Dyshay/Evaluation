using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Locator;

namespace Caisse_Televie.Model.Global.Services
{
    public class ServiceGlobalLocator : LocatorBase
    {
        private static ServiceGlobalLocator _Instance;
        public static ServiceGlobalLocator Instance
        {
            get { return _Instance ?? (_Instance = new ServiceGlobalLocator()); }
        }
        private ServiceGlobalLocator()
        {
            Container.Register<CommandService>();
            Container.Register<ProduitService>();
            Container.Register<LigneDeCommandeService>();
            Container.Register<CategorieService>();
        }
        public CommandService Command
        {
            get { return Container.GetInstance<CommandService>(); }
        }
        public ProduitService Produit
        {
            get { return Container.GetInstance<ProduitService>(); }
        }
        public LigneDeCommandeService LigneCommande
        {
            get { return Container.GetInstance<LigneDeCommandeService>(); }
        }
        public CategorieService Categorie
        {
            get { return Container.GetInstance<CategorieService>(); }
        }
    }
}
