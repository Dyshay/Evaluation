using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Repository;

namespace Caisse_Televie.Model.Global.Entity
{
    public class Produits 
    {
        public int CategorieId { get; set; }
        public int ProduitId { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
    }
}
