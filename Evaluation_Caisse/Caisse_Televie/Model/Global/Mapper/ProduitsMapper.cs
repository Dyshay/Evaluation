using Caisse_Televie.Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Global.Mapper
{
    internal static class ProduitsMapper
    {
        public static Produits ToProduits(this IDataRecord data)
        {
            if (data == null) throw new ArgumentNullException();
            return new Produits()
            {
                CategorieId = (int)data["CategorieId"],
                Nom = (string)data["Nom"],
                Prix = (double)data["Prix"],
                ProduitId = (int)data["ProduitId"]
            };
        }
    }
}
