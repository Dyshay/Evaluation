using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Client.Entity
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int CategorieId { get; set; }

        public Produit(int id,string nom,double prix,int categorie)
        {
            this.ProduitId = id;
            this.Nom = nom;
            this.Prix = prix;
            this.CategorieId = categorie;
        }
    }
}
