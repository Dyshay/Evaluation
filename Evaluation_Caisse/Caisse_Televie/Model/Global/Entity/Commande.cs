using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Repository;

namespace Caisse_Televie.Model.Global.Entity
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Benevol { get; set; }
    }
}
