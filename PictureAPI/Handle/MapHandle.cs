using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PictureAPI.Handle.Util;

namespace PictureAPI.Handle
{
    public class MapHandle
    {
        private DBHandle _handle = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MapHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
        }


        /// <summary>
        /// 根据类型获取城市列表
        /// </summary>
        /// <param name="t">类型</param>
        /// <returns></returns>
        public DataTable GetCitysByType(string t)
        {
            DataTable dt = new DataTable();
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
            string sql = @"SELECT c.Id id, c.City city,c.CityCode code, c.Lat lat,c.Lon lon FROM S_Citys c where c.CityCode like '%"+t+"%'";
            dt = _handle.ExecuteQuery(sql);
            return dt;
        }
    }
}