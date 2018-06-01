using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections;
using ToolBox.Patterns.Repository;

namespace Caisse_Televie.Model.Global.Services
{
    public abstract class ServiceBase<TKey, TEntity> : IDataService<TKey, TEntity>
    {
        private const string CONNEXION_STRING = @"Server=DESKTOP-IRE6555\SQLEXPRESS;Database=Caisse;Trusted_Connection=True;";

        protected Connection Context;

        public ServiceBase()
        {
            Context = new Connection("system.data.sqlclient", CONNEXION_STRING);
        }

        protected abstract TEntity MapperToGlobal(System.Data.IDataRecord data);

        public abstract IEnumerable<TEntity> Get();
        public abstract TEntity Get(TKey ID);
        public abstract TEntity Insert(TEntity Entity);
        public abstract bool Update(TEntity Entity);
        public abstract bool Delete(TKey ID);
    }
}
