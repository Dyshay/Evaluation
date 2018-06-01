using Caisse_Televie.Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Global.Mapper
{
    internal static class CommandeMapper
    {
        public static Commande ToCommande(this IDataRecord Data)
        {
            if (Data == null) throw new ArgumentNullException();
            return new Commande()
            {
                Id = (int)Data["CommandId"],
                Date = (DateTime)Data["Heure"],
                Benevol = (bool)Data["Benevol"]
            };
        }
    }
}
