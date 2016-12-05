using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Huike.Core.Dao;
using KaoheS;

namespace KaoheS
{
    class DbDaoClass : BaseDao
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns>所有信息集</returns>
        public DataSet GetData(string Id)
        {
            string sqlStr;
            if (Id == null)
            {
                sqlStr = string.Format("SELECT *  FROM   sm_PLCData  ");
            }
            else
            {
                sqlStr = string.Format("SELECT *  FROM   sm_PLCData Where ID={0} ",int.Parse(Id));
            }
            
            return this.ExecuteQuery(sqlStr);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">ＩＤ号</param>
        public void DeleteData(int id)
        {
            string sqlStr = string.Format("DELETE FROM  sm_PLCData  WHERE ID ={0}", id);
            this.ExecuteNonQuery(sqlStr);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="Name">名字</param>
        /// <param name="Tel">电话号码</param>
        /// <param name="Adress">住址</param>
        public void InsertData(string Id, string nameOpcItemName, string ItemValue, string State)
        {
            string sqlText = string.Format("select max(id) from sm_PLCData");
            Id = this.ExecuteScalar(sqlText).ToString();
            string sqlStr = string.Format("INSERT INTO sm_PLCData(Id,OpcItemName, ItemValue, State) Values({0},'{1}',{2},{3})", 1+int.Parse(Id), nameOpcItemName, int.Parse(ItemValue), State);
            this.ExecuteNonQuery(sqlStr);
        }
        public void UpdateData(string Id, string nameOpcItemName,string ItemValue,string State)
        {
            string sqlStr = string.Format("UPDATE  sm_PLCData set ID={0},OpcItemName='{1}',ItemValue={2},State={3}  where ID={4}", int.Parse(Id),nameOpcItemName,int.Parse(ItemValue),State,int.Parse(Id));
            this.ExecuteNonQuery(sqlStr);
        }
        //public void InsertOrUpdateData(string Id = null, string nameOpcItemName = null, string ItemValue = null, string State = null)
        //{
        //    if (Id == null)
        //    {
        //        Id = (-1).ToString();
        //    }
        //    DataSet ds=this.GetData(Id);

        //    //if (ds.Tables[0].Rows[0][0] != null)
        //    //{
        //    //    this.UpdateData(Id, nameOpcItemName, ItemValue, State);
        //    //}
        //    //else
        //    //{
        //        string sqlText = "select max(id) from sm_PLCData";
        //        ds=this.ExecuteQuery(sqlText);
        //        Id = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
        //        nameOpcItemName = "one";
        //        State = (0).ToString();
        //        this.InsertData(Id, nameOpcItemName, ItemValue, State);
        //    //}
        //}

    }
}
