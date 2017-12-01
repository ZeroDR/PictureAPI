using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PictureAPI.Handle.Util;

namespace PictureAPI.Handle
{
    public class CatesHandle
    {
        private DBHandle _handle = null;

        public CatesHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
        }

        /// <summary>
        /// 获取各菜系列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListCate()
        {
            if (_handle == null)
                _handle = new DBHandle();
            string sql = @"SELECT a.Id id,a.Name name,a.AliasName aliasname FROM S_Food a";
            DataTable dt = _handle.ExecuteQuery(sql);
            return dt;
        }
    }
}