using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using G = Caisse_Televie.Model.Global.Entity;
using C = Caisse_Televie.Model.Client.Entity;


namespace Caisse_Televie.Model.Client.Mapper
{
    public static class ProduitMapper
    {
        public static C.Produit ToClient(this G.Produits Entity)
        {
            return new C.Produit(Entity.ProduitId, Entity.Nom, Entity.Prix,Entity.CategorieId);
        }
        public static G.Produits ToGlobal(this C.Produit Entity)
        {
            return new G.Produits()
            {
                ProduitId = Entity.ProduitId,
                Nom = Entity.Nom,
                Prix = Entity.Prix,
                CategorieId = Entity.CategorieId
            };
        }
    }
}
