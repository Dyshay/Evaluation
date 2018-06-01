using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Repository;

using SG = Caisse_Televie.Model.Global.Services;
using G = Caisse_Televie.Model.Global.Entity;
using C = Caisse_Televie.Model.Client.Entity;
using Caisse_Televie.Model.Client.Mapper;

namespace Caisse_Televie.Model.Client.Services
{
    public class CategorieService : IDataService<int, C.Categorie>
    {

        public IEnumerable<C.Categorie> Get()
        {
            return SG.ServiceGlobalLocator.Instance.Categorie.Get().Select(a => a.ToClient());
        }

        public C.Categorie Get(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.Categorie.Get(ID).ToClient();
        }

        public C.Categorie Insert(C.Categorie Entity)
        {
            return SG.ServiceGlobalLocator.Instance.Categorie.Insert(Entity.ToGlobal()).ToClient();
        }

        public bool Update(C.Categorie Entity)
        {
            return SG.ServiceGlobalLocator.Instance.Categorie.Update(Entity.ToGlobal());
        }
        public bool Delete(int ID)
        {
            return SG.ServiceGlobalLocator.Instance.Categorie.Delete(ID);
        }
    }
}
