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
    public class CategorieService : ServiceBase<int, Categorie>, IDataService<int, Categorie>
    {

        public override IEnumerable<Categorie> Get()
        {
            Command cmd = new Command("SELECT * FROM Categorie");
            return Context.ExecuteReader(cmd, MapperToGlobal);
        }

        public override Categorie Get(int ID)
        {
            Command cmd = new Command("SELECT * FROM Categorie WHERE CategorieId = @ID");
            cmd.AddParameter("ID", ID);
            return Context.ExecuteReader(cmd, MapperToGlobal).SingleOrDefault();
        }

        public override Categorie Insert(Categorie Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Categorie Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }
        protected override Categorie MapperToGlobal(IDataRecord data)
        {
            return data.ToCategorie();
        }
    }
}
