using Caisse_Televie.Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Global.Mapper
{
    internal static class CategorieMapper
    {
        public static Categorie ToCategorie(this IDataRecord data)
        {
            if (data == null) throw new ArgumentNullException();
            return new Categorie()
            {
                CategorieId = (int)data["CategorieId"],
                Nom = (string)data["Nom"]
            };
        }
    }
}
