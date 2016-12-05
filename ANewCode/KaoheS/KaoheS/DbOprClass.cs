using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KaoheS;

namespace KaoheS
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    class DbOprClass
    {
        public DataSet GetData(string Id=null)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("KaoheS.DbDaoClass");
                return dao.GetData(Id);
            }
        }

        public bool DeleteData(int id)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("KaoheS.DbDaoClass");
                dao.DeleteData(id);
                return pm.Submit();
            }
        }

        public bool InsertData(string Id, string nameOpcItemName, string ItemValue, string State)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("KaoheS.DbDaoClass");
                dao.InsertData(Id, nameOpcItemName, ItemValue, State);
                return pm.Submit();
            }
        }
        public bool UpDateData(string Id, string nameOpcItemName, string ItemValue, string State)
        {
            using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            {
                DbDaoClass dao = (DbDaoClass)pm.BuildDao("KaoheS.DbDaoClass");
                dao.UpdateData(Id,nameOpcItemName, ItemValue, State);
                return pm.Submit();
            }
        }
        public bool InsertOrUpdateData(string Id = null, string nameOpcItemName = null, string ItemValue = null, string State = null)
        {
            //using (Huike.Core.Dao.PersistentManager pm = new Huike.Core.Dao.PersistentManager("A"))
            //{
            //    DbDaoClass dao = (DbDaoClass)pm.BuildDao("KaoheS.DbDaoClass");
            //    dao.InsertOrUpdateData(Id, nameOpcItemName, ItemValue, State);
            //    return pm.Submit();
            //}
            return true;
        }
    }
}
