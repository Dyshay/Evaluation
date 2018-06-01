using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Global.Entity
{
    public class LigneDeCommande
    {
        public int CommandId { get; set; }
        public int ProduitId { get; set; }
        public int Quantite { get; set; }
        public double PrixGlobal { get; set; }
    }
}
