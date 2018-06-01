using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Client.Entity
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string Nom { get; set; }

        public Categorie(int categorieid,string nom)
        {
            this.CategorieId = categorieid;
            this.Nom = nom;
        }
    }
}
