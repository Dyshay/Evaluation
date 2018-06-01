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
    public class CommandService : ServiceBase<int, Commande>, IDataService<int, Commande>
    {

        public override IEnumerable<Commande> Get()
        {
            Command cmd = new Command("SELECT * FROM Commande");
            return Context.ExecuteReader(cmd, MapperToGlobal);
        }

        public override Commande Get(int ID)
        {
            throw new NotImplementedException();
        }

        public override Commande Insert(Commande Entity)
        {
            Command cmd = new Command("INSERT INTO Commande (Benevol) OUTPUT inserted.CommandId VALUES (@Benevol)");
            cmd.AddParameter("Benevol", Entity.Benevol);
            Entity.Id = (int)Context.ExecuteScalar(cmd);
            return Entity;
            
        }

        public override bool Update(Commande Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }
        protected override Commande MapperToGlobal(IDataRecord data)
        {
            return data.ToCommande();
        }
    }
}
