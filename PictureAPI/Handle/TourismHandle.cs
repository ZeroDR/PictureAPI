using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PictureAPI.Handle.Util;

namespace PictureAPI.Handle
{
    public class TourismHandle
    {
        private DBHandle  _handle = null;
        

        public TourismHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
        }

        /// <summary>
        /// 获取各洲列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListState()
        {
            if (_handle == null)
                _handle = new DBHandle();
            string sql = @"SELECT a.Id id,a.Name name,a.AliasName aliasname FROM S_State a";
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
                _handle = new DBHandle();
            }
            string sql = @"SELECT a.Id id,a.Name name,a.PathName pathname,b.AliasName aliasname FROM S_ScenicSpot a join S_State b on a.InState=b.Id where " + (instate == -1 ? "1=1" : ("b.Id=" + instate));
            DataTable dt = _handle.ExecuteQuery(sql);
            return dt;
        }
    }
}