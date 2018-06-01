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
    public class CommandService : IDataService<int, C.Commande>
    {

        public IEnumerable<C.Commande> Get()
        {
            return SG.ServiceGlobalLocator.Instance.Command.Get().Select(a => a.ToClient());
        }

        public C.Commande Get(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.Command.Get(ID)?.ToClient();
        }

        public C.Commande Insert(C.Commande Entity)
        {
            return SG.ServiceGlobalLocator.Instance.Command.Insert(Entity.ToGlobal()).ToClient();
        }

        public bool Update(C.Commande Entity)
        {
            return SG.ServiceGlobalLocator.Instance.Command.Update(Entity.ToGlobal());
        }
        public bool Delete(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.Command.Delete(ID);
        }
    }
}
