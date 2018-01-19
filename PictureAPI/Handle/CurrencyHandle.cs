using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PictureAPI.Handle.Util;

namespace PictureAPI.Handle
{
    public class CurrencyHandle
    {
        private DBHandle _handle = null;

        public CurrencyHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
        }

        /// <summary>
        /// 根据模块标识和子选项标识获取描述信息
        /// </summary>
        /// <param name="module">模块标识</param>
        /// <param name="id">选项标识</param>
        /// <returns></returns>
        public DataTable GetDescriptionById(int moduleId, int childId)
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
            DataTable dt = null;
            if (moduleId > 0 && childId > 0)
            {
                string dtName = moduleId == 1 ? "S_ScenicSpot" : (moduleId == 2 ? "S_Family" : (moduleId == 3 ? "S_Food" : (moduleId == 4 ? "S_Map" : (moduleId == 5 ? "S_About" : null))));
                string sql = @"SELECT a.Id id,b.Name name,a.Title title,a.Description description FROM S_Description a join " + dtName + " b on a.Relation=b.Id where a.Type=" + moduleId + " and a.Relation=" + childId;
                if (dtName != null)
                    dt = _handle.ExecuteQuery(sql);
            }else
            {
                string sql = @"SELECT a.Id id,a.Title title,a.Description description FROM S_Description a where a.Type="+moduleId+" and a.Relation="+childId;
                dt = _handle.ExecuteQuery(sql);
            }
            return dt;
        }
    }
}