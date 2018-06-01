using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse_Televie.Model.Client.Entity
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Benevol { get; set; }

        public Commande(bool benevol)
        {
            this.Benevol = benevol;
        }
        public Commande(int id,DateTime date,bool benevol)
        {
            this.Id = id;
            this.Date = date;
            this.Benevol = benevol;
        }
    }
}
