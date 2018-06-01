using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using G = Caisse_Televie.Model.Global.Entity;
using C = Caisse_Televie.Model.Client.Entity;


namespace Caisse_Televie.Model.Client.Mapper
{
    public static class LigneDeCommandeMapper
    {
        public static C.LigneDeCommande ToClient(this G.LigneDeCommande Entity)
        {
            return new C.LigneDeCommande(Entity.CommandId, Entity.ProduitId, Entity.Quantite, Entity.PrixGlobal);
        }
        public static G.LigneDeCommande ToGlobal(this C.LigneDeCommande Entity)
        {
            return new G.LigneDeCommande()
            {
                ProduitId = Entity.ProduitId,
                CommandId = Entity.CommandId,
                PrixGlobal = Entity.PrixGlobal,
                Quantite = Entity.Quantite
            };
        }
    }
}
