using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DbHelper;

namespace PictureAPI.Handle.Util
{
    public class DBHandle
    {
        //数据库连接字符串
        private static readonly string _con = @"Data Source=" + System.Web.Hosting.HostingEnvironment.MapPath("~/") + "Data\\system.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

        private readonly string _dbType = "SQLite";

        private DBHelper _handle = null;

        public DBHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHelper(_con,_dbType);
            }
        }

        /// <summary>
        /// 数据库执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = null;
            if (_handle != null)
            {
                dt = _handle.ExecuteQuery(sql);
            }
            return dt;
        }

        /// <summary>
        /// 数据库执行增删改操作
        /// </summary>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            int handCount = 0;
            if(_handle != null)
            {
                handCount = _handle.ExecuteSql(sql);
            }
            return handCount;
        }
    }
}