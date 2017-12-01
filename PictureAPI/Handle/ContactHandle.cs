using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DbHelper;

namespace PictureAPI.Handle
{
    public class ContactHandle
    {
        //数据库连接字符串
        private static readonly string _con = @"Data Source=" + System.Web.Hosting.HostingEnvironment.MapPath("~/") + "Data\\system.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

        private readonly string _dbType = "SQLite";

        private DBHelper _handle = null;

        public ContactHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHelper(_con, _dbType);
            }
        }

        /// <summary>
        /// 获取各洲列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListState()
        {
            if (_handle == null)
                _handle = new DBHelper(_con, _dbType);
            string sql = @"SELECT a.Id id,a.Name name,a.AliasName aliasname FROM S_State a";
            DataTable dt = _handle.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 获取各民族列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListFamily()
        {
            if (_handle == null)
                _handle = new DBHelper(_con, _dbType);
            string sql = @"SELECT a.Id id,a.Name name,a.AliasName aliasname FROM S_Family a";
            DataTable dt = _handle.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 获取各菜系列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListFood()
        {
            if (_handle == null)
                _handle = new DBHelper(_con, _dbType);
            string sql = @"SELECT a.Id id,a.Name name,a.AliasName aliasname FROM S_Food a";
            DataTable dt = _handle.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 根据数据类型获取指定的景点，默认1=1
        /// </summary>
        /// <param name="instate">所属洲编号</param>
        /// <returns></returns>
        public DataTable GetSource(int instate)
        {
            if (_handle == null)
            {
                _handle = new DBHelper(_con, _dbType);
            }
            string sql = @"SELECT a.Id id,a.Name name,a.PathName pathname,b.AliasName aliasname FROM S_ScenicSpot a join S_State b on a.InState=b.Id where " + (instate == -1 ? "1=1" : ("b.Id=" + instate));
            DataTable dt = _handle.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 根据模块标识和子选项标识获取描述信息
        /// </summary>
        /// <param name="module">模块标识</param>
        /// <param name="id">选项标识</param>
        /// <returns></returns>
        public DataTable GetDescriptionById(int moduleId,int childId)
        {
            if (_handle == null)
            {
                _handle = new DBHelper(_con, _dbType);
            }
            DataTable dt = null;
            if (moduleId > 0 && childId > 0)
            {
                string dtName = moduleId == 1 ? "S_ScenicSpot" : (moduleId==2? "S_Family" : (moduleId==3? "S_Food" : (moduleId==4?"S_Map":(moduleId==5?"S_About":null))));
                string sql = @"SELECT a.Id id,b.Name name,a.Title title,a.Description description FROM S_Description a join "+dtName+" b on a.Relation=b.Id where a.Type="+moduleId+" and a.Relation="+childId;
                if(dtName != null)
                    dt = _handle.ExecuteQuery(sql);
            }
            return dt;
        }
    }
}