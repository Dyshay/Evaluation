using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Client.Entity
{
    public class LigneDeCommande
    {
        public int ProduitId { get; set; }
        public int CommandId { get; set; }
        public int Quantite { get; set; }
        public double PrixGlobal { get; set; }
        
        public LigneDeCommande(int commandid,int produitid,int quantite,double prix)
        {
            this.CommandId = commandid;
            this.ProduitId = produitid;
            this.Quantite = quantite;
            this.PrixGlobal = prix;
        }
    }
}
