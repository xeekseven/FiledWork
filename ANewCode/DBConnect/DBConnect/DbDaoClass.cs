using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Huike.Core.Dao;

namespace DBConnect
{
    class DbDaoClass : BaseDao
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns>所有信息集</returns>
        public DataSet GetData()
        {
            string sqlStr = string.Format("SELECT *  FROM   Boy ");
            return this.ExecuteQuery(sqlStr, "TestTable");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">ＩＤ号</param>
        public void DeleteData(int id)
        {
            string sqlStr = string.Format("DELETE FROM  Boy WHERE ID ={0}", id);
            this.ExecuteNonQuery(sqlStr);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="Name">名字</param>
        /// <param name="Tel">电话号码</param>
        /// <param name="Adress">住址</param>
        public void InsertData(string Name, string Tel, string Adress)
        {
            string sqlStr = string.Format("INSERT INTO TestTable(Name,Tel,Adress) Values('{0}','{1}','{2}')", Name, Tel, Adress);
            this.ExecuteNonQuery(sqlStr);
        }
    }
}
