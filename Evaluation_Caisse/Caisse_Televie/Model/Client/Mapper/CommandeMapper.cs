using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G = Caisse_Televie.Model.Global.Entity;
using C = Caisse_Televie.Model.Client.Entity;


namespace Caisse_Televie.Model.Client.Mapper
{
    public static class CommandeMapper
    {
        public static C.Commande ToClient(this G.Commande Entity)
        {
            return new C.Commande(Entity.Id,Entity.Date, Entity.Benevol);
        }
        public static G.Commande ToGlobal(this C.Commande Entity)
        {
            return new G.Commande()
            {
                Id = Entity.Id,
                Date = Entity.Date,
                Benevol = Entity.Benevol
            };
        }
    }
}
