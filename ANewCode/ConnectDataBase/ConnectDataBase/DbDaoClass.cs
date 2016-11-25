using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Huike.Core.Dao;
using System.Data;

namespace ConnectDataBase
{
    class DbDaoClass:BaseDao
    {
        public DataSet GetData()
        {
            string sqlStr = string.Format("select * from Boy");
            if (this != null)
            {
                return this.ExecuteQuery(sqlStr);
            }
            return this.ExecuteQuery(sqlStr);

        }
        public void DeleteData(int id)
        {
            string sqlStr = string.Format("Delete from Boy where Id={0} ", id);
            this.ExecuteNonQuery(sqlStr);
        }
        public void InsertData(int id,string Name)
        {
            string sqlStr = string.Format("Insert into Boy (Id,name) values({0},{1})", id, Name);
            this.ExecuteNonQuery(sqlStr);
        }
    }
}
