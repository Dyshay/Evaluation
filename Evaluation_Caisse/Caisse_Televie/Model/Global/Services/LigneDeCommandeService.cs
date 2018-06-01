using Caisse_Televie.Model.Global.Entity;
using Caisse_Televie.Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections;
using ToolBox.Patterns.Repository;

namespace Caisse_Televie.Model.Global.Services
{
    public class LigneDeCommandeService : ServiceBase<int, LigneDeCommande>, IDataService<int, LigneDeCommande>
    {

        public override IEnumerable<LigneDeCommande> Get()
        {
            Command cmd = new Command("SELECT * FROM OrderLine C INNER JOIN Commande Cmd ON Cmd.CommandId = C.CommandId");
            return Context.ExecuteReader(cmd, MapperToGlobal);
        }

        public override LigneDeCommande Get(int ID)
        {
            throw new NotImplementedException();
        }

        public override LigneDeCommande Insert(LigneDeCommande Entity)
        {
            Command CmdSelectId = new Command("SELECT MAX(CommandId) FROM Commande");
            int Commandtemp = (int)Context.ExecuteScalar(CmdSelectId);
            Command cmd = new Command("INSERT INTO OrderLine (CommandId,ProduitId,PrixGlobal,Quantite) VALUES (@CommandId,@ProduitId,@PrixGlobal,@Quantite)");
            cmd.AddParameter("PrixGlobal", Entity.PrixGlobal);
            cmd.AddParameter("Quantite", Entity.Quantite);
            cmd.AddParameter("ProduitId", Entity.ProduitId);
            cmd.AddParameter("CommandId", Commandtemp);
            Context.ExecuteNonQuery(cmd);
            return Entity;
        }

        public override bool Update(LigneDeCommande Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }
        protected override LigneDeCommande MapperToGlobal(IDataRecord data)
        {
            return data.ToLigneCommande();
        }
    }
}
