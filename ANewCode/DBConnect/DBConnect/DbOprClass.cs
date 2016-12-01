using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBConnect;

namespace DBConnect
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    class DbOprClass
    {
        public DataSet GetData()
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("DBConnect.DbDaoClass");
                return dao.GetData();
            }
        }

        public bool DeleteData(int id)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("DBConnect.DbDaoClass");
                dao.DeleteData(id);
                return pm.Submit();
            }
        }

        public bool InsertData(string Name, string Tel, string Adress)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("DBConnect.DbDaoClass");
                dao.InsertData(Name, Tel, Adress);
                return pm.Submit();
            }
        }
    }
}
