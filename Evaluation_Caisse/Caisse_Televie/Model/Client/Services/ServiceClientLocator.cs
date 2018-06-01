using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Locator;

namespace Caisse_Televie.Model.Client.Services
{
    public class ServiceClientLocator : LocatorBase
    {
        private static ServiceClientLocator _Instance;
        public static ServiceClientLocator Instance
        {
            get { return _Instance ?? (_Instance = new ServiceClientLocator()); }
        }
        private ServiceClientLocator()
        {
            Container.Register<CommandService>();
            Container.Register<LigneDeCommand>();
            Container.Register<ProduitService>();
            Container.Register<CategorieService>();
        }
        public ProduitService Produit
        {
            get { return Container.GetInstance<ProduitService>(); }
        }
        public LigneDeCommand LigneDeCommand
        {
            get { return Container.GetInstance<LigneDeCommand>(); }
        }
        public CommandService Commande
        {
            get { return Container.GetInstance<CommandService>(); }
        }
        public CategorieService Categorie
        {
            get { return Container.GetInstance<CategorieService>(); }
        }
    }
}
