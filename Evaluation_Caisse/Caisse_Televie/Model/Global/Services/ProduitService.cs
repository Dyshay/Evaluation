using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.Repository;
using Caisse_Televie.Model.Global.Entity;
using System.Data;
using ToolBox.Connections;
using Caisse_Televie.Model.Global.Mapper;

namespace Caisse_Televie.Model.Global.Services
{
    public class ProduitService : ServiceBase<int,Produits> , IDataService<int, Produits>
    {

        public override IEnumerable<Produits> Get()
        {
            Command cmd = new Command("SELECT * FROM Produit");
            return Context.ExecuteReader(cmd, MapperToGlobal);
        }

        public override Produits Get(int ID)
        {
            Command cmd = new Command("SELECT * FROM Produit WHERE ProduitId = @Id");
            cmd.AddParameter("Id", ID);
            return Context.ExecuteReader(cmd, MapperToGlobal).SingleOrDefault();
        }

        public override Produits Insert(Produits Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Produits Entity)
        {
            throw new NotImplementedException();
        }
        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        protected override Produits MapperToGlobal(IDataRecord data)
        {
            return data.ToProduits();
        }
    }
}
