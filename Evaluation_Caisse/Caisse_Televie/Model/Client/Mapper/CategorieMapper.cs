using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using G = Caisse_Televie.Model.Global.Entity;
using C = Caisse_Televie.Model.Client.Entity;

namespace Caisse_Televie.Model.Client.Mapper
{
    public static class CategorieMapper
    {
        public static C.Categorie ToClient(this G.Categorie Entity)
        {
            return new C.Categorie(Entity.CategorieId, Entity.Nom);
        }
        public static G.Categorie ToGlobal(this C.Categorie Entity)
        {
            return new G.Categorie()
            {
                CategorieId = Entity.CategorieId,
                Nom = Entity.Nom,
            };
        }
    }
}
