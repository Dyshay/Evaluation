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
    public class LigneDeCommand : IDataService<int, C.LigneDeCommande>
    {

        public IEnumerable<C.LigneDeCommande> Get()
        {
            return SG.ServiceGlobalLocator.Instance.LigneCommande.Get().Select(a => a.ToClient());
        }

        public C.LigneDeCommande Get(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.LigneCommande.Get(ID)?.ToClient();
        }

        public C.LigneDeCommande Insert(C.LigneDeCommande Entity)
        {
            return SG.ServiceGlobalLocator.Instance.LigneCommande.Insert(Entity.ToGlobal()).ToClient();
        }

        public bool Update(C.LigneDeCommande Entity)
        {
            return SG.ServiceGlobalLocator.Instance.LigneCommande.Update(Entity.ToGlobal());
        }
        public bool Delete(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.LigneCommande.Delete(ID);
        }
    }
}
