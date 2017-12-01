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
    public class NationsController : ApiController
    {
        private NationsHandle _handle = null;

        public NationsController()
        {
            if (_handle == null)
            {
                _handle = new NationsHandle();
            }
        }

        /// <summary>
        /// 获取56个民族列表
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListFamily()
        {
            if (_handle == null)
            {
                _handle = new NationsHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetListFamily();
                if (dt != null)
                {
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
                    features.primaryFieldName = "id";
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
