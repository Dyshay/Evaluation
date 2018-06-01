using Caisse_Televie.Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Global.Mapper
{
    internal static class LigneDeCommandeMapper
    {
        public static LigneDeCommande ToLigneCommande(this IDataRecord Data)
        {
            if (Data == null) throw new ArgumentNullException();
            return new LigneDeCommande()
            {
                CommandId = (int)Data["CommandId"],
                ProduitId = (int)Data["ProduitId"],
                PrixGlobal = (double)Data["PrixGlobal"],
                Quantite = (int)Data["Quantite"]
            };
        }
    }
}
