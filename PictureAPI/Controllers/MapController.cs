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

namespace PictureAPI.Controllers
{
    public class MapController : ApiController
    {
        private MapHandle _handle = null;

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
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "city";
                    features.primaryFieldName = "code";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dt));//(Contact[])ls.ToArray();
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
