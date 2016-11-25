using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Huike.Core.Dao;
using System.Data;

namespace ConnectDataBase
{
    class DbOprClass
    {
        public DataSet GetData()
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("ConnectDataBase.DbDaoClass");
                return dao.GetData();
            }
        }
        public bool DeleteData(int id)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("ConnectionStringA"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("ConnectDataBase.DbDaoClass");
                dao.DeleteData(id);
                return pm.Submit();
            }
        }
        public bool InsertData(int id, string name)
        {
            using (Huike.Core.Dao.PersistentManager pm = new PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("ConnectDataBase.DbDaoClass");
                dao.InsertData(id, name);
                return pm.Submit();
            }
        }
    }
}

