using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PictureAPI.Handle.Util;

namespace PictureAPI.Handle
{
    public class AboutHandle
    {
        private DBHandle _handle = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AboutHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
        }

        /// <summary>
        /// 根据用户标识获取用户相关信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetUserInfo(string userId)
        {
            DataTable dt = new DataTable();
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
            string sql = @"SELECT u.Id id,u.Name name,u.AliasName aliasname,u.Description description FROM S_Users u WHERE u.Id="+userId;
            dt = _handle.ExecuteQuery(sql);
            return dt;
        }

        /// <summary>
        /// 获取关于模块信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAboutInfo(int userId)
        {
            DataTable dt = new DataTable();
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
            string sql = @"SELECT u.Id id,a.Name name,a.AliasName aliasname,a.DisplayValue display FROM S_Users u JOIN S_About a ON u.Id=a.UserId WHERE u.Id="+userId+" ORDER BY a.OrderId";
            dt = _handle.ExecuteQuery(sql);
            return dt;
        }


        /// <summary>
        /// 获取关于其他相关信息
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public DataTable GetAboutOther(int userId)
        {
            DataTable dt = new DataTable();
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
            string sql = @"SELECT u.Id id,b.Id bid,b.Name name,b.Type type,b.Description description FROM S_Blogs b JOIN S_Users u ON u.Id=b.UserId WHERE u.Id=" + userId+" ORDER BY b.OrderId";
            dt = _handle.ExecuteQuery(sql);
            return dt;
        }
    }
}