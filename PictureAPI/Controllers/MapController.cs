using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;
using PictureAPI.Models;
using PictureAPI.Handle;
using PictureAPI.Handle.Util;

namespace PictureAPI.Controllers
{
    /// <summary>
    /// 地图Controller
    /// </summary>
    public class MapController : ApiController
    {
        //操作对象
        private MapHandle _handle = null;

        /// <summary>
        /// 构造函数并实例化操作对象
        /// </summary>
        public MapController()
        {
            if (_handle == null)
            {
                _handle = new MapHandle();
            }
        }

        /// <summary>
        /// 根据国家标识获取国家城市列表
        /// </summary>
        /// <param name="t">国家类型，默认值CN</param>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetCitysByType(string t = "CN")
        {
            if (_handle == null)
            {
                _handle = new MapHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {   
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetCitysByType(t);
                if (dt != null)
                {
                    List<CityModel> lsCity = dt.DataTableToList<CityModel>();
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "city";
                    features.primaryFieldName = "code";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsCity));//(Contact[])ls.ToArray();
                    responseModel.response = features;
                }
            }
            catch (Exception ex)
            {
                responseModel.description = ex.Message.ToString();
                responseModel.success = false;
                responseModel.response = JsonConvert.DeserializeObject("{}");
            }
            return responseModel;
        }
    }
}
