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
        /// 获取关于模块信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAboutInfo(string userId)
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

        public DataTable GetAboutOther(int userId)
        {
            DataTable dt = new DataTable();
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
            string sql = @"SELECT * FROM S_Blogs b JOIN S_Users u ON u.Id=b.UserId WHERE u.Id="+userId+" ORDER BY b.OrderId";
            dt = _handle.ExecuteQuery(sql);
            return dt;
        }
    }
}