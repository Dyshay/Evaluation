using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C = Caisse_Televie.Model.Client.Entity;
using SG = Caisse_Televie.Model.Global.Services;
using G = Caisse_Televie.Model.Global.Entity;
using Caisse_Televie.Model.Client.Mapper;
using ToolBox.Patterns.Repository;

namespace Caisse_Televie.Model.Client.Services
{
    public class ProduitService : IDataService<int, C.Produit>
    {

        public IEnumerable<C.Produit> Get()
        {
            return SG.ServiceGlobalLocator.Instance.Produit.Get().Select(a => a.ToClient());
        }

        public C.Produit Get(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.Produit.Get(ID)?.ToClient();
        }

        public C.Produit Insert(C.Produit Entity)
        {
            return SG.ServiceGlobalLocator.Instance.Produit.Insert(Entity.ToGlobal()).ToClient();
        }

        public bool Update(C.Produit Entity)
        {
            return SG.ServiceGlobalLocator.Instance.Produit.Update(Entity.ToGlobal());
        }
        public bool Delete(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.Produit.Delete(ID);
        }
    }
}
